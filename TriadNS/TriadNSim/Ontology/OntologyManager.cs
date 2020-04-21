using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using org.semanticweb.owlapi.model;
using org.semanticweb.owlapi.util;
using org.semanticweb.owlapi.apibinding;
using JIO = java.io;
using java.util;
using org.semanticweb.owlapi.vocab;
using TriadCompiler;
using System.Diagnostics;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace TriadNSim.Ontology
{
    public interface IOWLClass
    {
        string Name { get; }
        string Comment { set; get; }
        object InnerObject { get; }
        IOWLClass SuperClass { get; }
    }

    class COWLClass : IOWLClass
    {
        private OWLClass cls;
        private OWLOntology ontology;
        private OWLOntologyManager manager;
        private OWLDataFactory factory;

        private COWLClass()
        {
        }

        public COWLClass(OWLOntology ontology, OWLClass cls)
        {
            this.ontology = ontology;
            this.manager = ontology.getOWLOntologyManager();
            this.cls = cls;
        }

        private OWLDataFactory Factory
        {
            get
            {
                if (factory == null)
                    factory = manager.getOWLDataFactory();
                return factory;
            }
        }

        public IOWLClass SuperClass
        {
            get
            {
                Set s = cls.getSuperClasses(ontology);
                if (!s.isEmpty())
                {
                    OWLClass superClass = s.iterator().next() as OWLClass;
                    return new COWLClass(ontology, superClass);
                }
                return null;
            }
        }

        public object InnerObject
        {
            get
            {
                return cls;
            }
        }

        public string Name
        {
            get
            {
                return cls.getIRI().getFragment();
            }
        }

        public string Comment
        {
            get
            {
                string sRes = string.Empty;
                Set annotations = cls.getAnnotations(ontology, Factory.getOWLAnnotationProperty(OWLRDFVocabulary.RDFS_COMMENT.getIRI()));
                if (!annotations.isEmpty())
                {
                    OWLAnnotation ann = annotations.iterator().next() as OWLAnnotation;
                    if (ann.getValue() is OWLLiteral)
                    {
                        OWLLiteral lit = ann.getValue() as OWLLiteral;
                        sRes = lit.getLiteral();
                    }
                }
                return sRes;
            }
            set
            {
                OWLAnnotation commentAnno = Factory.getOWLAnnotation(factory.getOWLAnnotationProperty(OWLRDFVocabulary.RDFS_COMMENT.getIRI()),
                                                    Factory.getOWLLiteral(value));
                OWLAxiom ax = factory.getOWLAnnotationAssertionAxiom(cls.getIRI(), commentAnno);
                manager.applyChange(new AddAxiom(ontology, ax));
            }
        }
    }

    public class COWLOntologyManager
    {
        private OWLOntologyManager manager;
        private OWLOntology ontology;
        private OWLOntology mainOntology;
        private OWLDataFactory factory;
        private PrefixManager pm;
        public OWLDataProperty dataPropAssemblyPath;

        public COWLOntologyManager(string sOntologyPath)
        {
            manager = OWLManager.createOWLOntologyManager();
            //manager.setSilentMissingImportsHandling(true);
            factory = manager.getOWLDataFactory();
            mainOntology = manager.loadOntologyFromOntologyDocument(new JIO.File("Ontologies//TriadNetCommon.owl"));
            ontology = manager.loadOntologyFromOntologyDocument(new JIO.File(sOntologyPath));
            pm = new DefaultPrefixManager(ontology.getOntologyID().getOntologyIRI().toString() + "#");
            dataPropAssemblyPath = factory.getOWLDataProperty(IRI.create("http://www.psu.ru/ontologies/2009/4/TriadNetCommon.owl#assemblyPath"));
        }


        public List<OWLNamedIndividual> GetIndividuals(IOWLClass cls, bool bWithSubClasses = true)
        {
            List<OWLNamedIndividual> individuals = new List<OWLNamedIndividual>();
            Set s = (cls.InnerObject as OWLClass).getIndividuals(ontology);
            Iterator it = s.iterator();
            while (it.hasNext())
            {
                OWLIndividual indiv = it.next() as OWLIndividual;
                if (indiv.isNamed())
                    individuals.Add(indiv.asOWLNamedIndividual());
            }
            if (bWithSubClasses)
            {
                foreach (IOWLClass subClass in GetSubClasses(cls))
                    individuals.AddRange(GetIndividuals(subClass, false));
            }
            return individuals;
        }

        public IOWLClass GetIndividualClass(OWLNamedIndividual indiv)
        {
            OWLClassAssertionAxiom ax = ontology.getClassAssertionAxioms(indiv).iterator().next() as OWLClassAssertionAxiom;
            return new COWLClass(ontology, ax.getClassExpression().asOWLClass());
        }

        public Dictionary<NetworkObject, OWLNamedIndividual> CompletedNodes;
        public string sCompleteError = string.Empty;
        public bool Complete(SimulationInfo info)
        {
            CompletedNodes = new Dictionary<NetworkObject, OWLNamedIndividual>();
            sCompleteError = string.Empty;
            if (!CompleteNode(info, 0))
                return false;

            DefineRoutines();

            return true;
        }

        public bool CompleteNode(SimulationInfo info, NetworkObject obj, OWLNamedIndividual indiv)
        {
            CompletedNodes = new Dictionary<NetworkObject, OWLNamedIndividual>();
            if (!TryComplete(info, obj, indiv))
                return false;
            DefineRoutines();
            return true;
        }

        public string GetStrIndividualProp(OWLNamedIndividual indiv, OWLDataProperty prop)
        {
            Map map = indiv.getDataPropertyValues(ontology);
            Set s = (Set)map.get(prop);
            return s == null || s.isEmpty() ? null : (s.iterator().next() as OWLLiteral).getLiteral();
        }

        public Routine CreateRoutine(OWLNamedIndividual indiv)
        {
            OWLDataProperty dataPropHasName = factory.getOWLDataProperty(IRI.create("http://www.psu.ru/ontologies/2009/4/TriadNetCommon.owl#hasName"));
            OWLDataProperty dataPropParamIndex = factory.getOWLDataProperty(IRI.create("http://www.psu.ru/ontologies/2009/4/TriadNetCommon.owl#hasParameterIndex"));
            OWLDataProperty dataPropParamType = factory.getOWLDataProperty(IRI.create("http://www.psu.ru/ontologies/2009/4/TriadNetCommon.owl#hasParameterType"));
            OWLDataProperty dataPropParamDefaultValue = factory.getOWLDataProperty(IRI.create("http://www.psu.ru/ontologies/2009/4/TriadNetCommon.owl#hasParameterDefaultValue"));

            Routine res = new Routine();
            Map map = indiv.getDataPropertyValues(ontology);
            OWLLiteral name = ((Set)map.get(dataPropHasName)).iterator().next() as OWLLiteral;
            Set s = (Set)map.get(dataPropAssemblyPath);
            string sLocalPath = string.Empty;
            string assemblyPath = (s == null || s.isEmpty()) ? string.Empty :
                Application.StartupPath + "\\" + (s.iterator().next() as OWLLiteral).getLiteral();
            if (assemblyPath.Length > 0)
            {
                sLocalPath = Application.StartupPath + "\\" + Path.GetFileName(assemblyPath);
                if (!File.Exists(sLocalPath))
                    File.Copy(assemblyPath, sLocalPath);
            }
            res.Name = name.getLiteral();
            res.AssemblyPath = sLocalPath;
            res.Type = GetIndividualClass(indiv).Name;

            List<OWLNamedIndividual> routParams = GetRoutineParams(indiv);
            for (int i = 0; i < routParams.Count; i++)
            {
                res.Parameters.Add(null);
                res.ParameterValues.Add(null);
                res.ParamDescription.Add(null);
            }
            foreach(OWLNamedIndividual param in routParams)
            {
                Map paramProperties = param.getDataPropertyValues(ontology);
                OWLLiteral paramName = ((Set)paramProperties.get(dataPropHasName)).iterator().next() as OWLLiteral;
                OWLLiteral paramIndex = ((Set)paramProperties.get(dataPropParamIndex)).iterator().next() as OWLLiteral;
                OWLLiteral paramType = ((Set)paramProperties.get(dataPropParamType)).iterator().next() as OWLLiteral;
                OWLLiteral paramValue = ((Set)paramProperties.get(dataPropParamDefaultValue)).iterator().next() as OWLLiteral;
                string sAnno = string.Empty;
                Set anno = param.getAnnotations(ontology, factory.getOWLAnnotationProperty(OWLRDFVocabulary.RDFS_COMMENT.getIRI()));
                if (!anno.isEmpty())
                {
                    OWLAnnotation ann = anno.iterator().next() as OWLAnnotation;
                    if (ann.getValue() is OWLLiteral)
                    {
                        OWLLiteral lit = ann.getValue() as OWLLiteral;
                        sAnno = lit.getLiteral();
                    }
                }

                IExprType type = new VarType(GetTypeCode(paramType.getLiteral()), paramName.getLiteral());
                int index = paramIndex.parseInteger();
                res.Parameters[index] = type;
                res.ParameterValues[index] = paramValue.getLiteral();
                res.ParamDescription[index] = sAnno;
            }

            //????
            {
                Assembly assembly = res.AssemblyPath.Length > 0 ? Assembly.LoadFile(res.AssemblyPath) : Assembly.GetExecutingAssembly();
                Type RoutineType = assembly.GetType("TriadCore."+ res.Name, true, true);
                foreach (FieldInfo fi in RoutineType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
                {
                    TriadCompiler.TypeCode typecode = GetTypeCode(fi.FieldType.ToString());
                    if (typecode != TriadCompiler.TypeCode.UndefinedType)
                        res.Variables.Add(new VarType(typecode, fi.Name));
                }
            }
            res.Poluses.AddRange(GetPoluses(indiv));
            return res;
        }

        private void DefineRoutines()
        {
            foreach (KeyValuePair<NetworkObject, OWLNamedIndividual> pair in CompletedNodes)
            {
                NetworkObject obj = pair.Key;
                OWLNamedIndividual indiv = pair.Value;
                obj.Routine = CreateRoutine(indiv); 
            }
        }

        private TriadCompiler.TypeCode GetTypeCode(string sType)
        {
            TriadCompiler.TypeCode res = TriadCompiler.TypeCode.UndefinedType;
            switch (sType)
            {
                case "Integer":
                case "System.Int32":
                    res = TriadCompiler.TypeCode.Integer;
                    break;
                case "Boolean":
                case "System.Boolean":
                    res = TriadCompiler.TypeCode.Boolean;
                    break;
                case "String":
                case "System.String":
                    res = TriadCompiler.TypeCode.String;
                    break;
                case "Real":
                case "System.Double":
                    res = TriadCompiler.TypeCode.Real;
                    break;
            };
            return res;
        }

        private bool CompleteNode(SimulationInfo info, int N)
        {
            if (info.Nodes.Count == N)
                return true;

            NetworkObject obj = info.Nodes[N] as NetworkObject;
            if (obj.Routine != null)
                return CompleteNode(info, N + 1);

            IOWLClass cl = new COWLClass(ontology, factory.getOWLClass(":" + obj.SemanticType, pm));
            foreach (OWLNamedIndividual indiv in GetIndividuals(cl))
            {
                if (!TryComplete(info, obj, indiv))
                    continue;

                if (CompleteNode(info, N + 1))
                    return true;
            }

            if (sCompleteError.Length == 0)
                sCompleteError = "Не удалось доопределить '" + obj.Name + "'";

            return false;
        }

        private bool TryComplete(SimulationInfo info, NetworkObject obj, OWLNamedIndividual indiv)
        {
            CompletedNodes[obj] = indiv;
            List<Polus> poluses = GetPoluses(indiv);
            long nRequiredCount = 0;
            foreach (Polus polus in poluses)
            {
                if (polus.IsRequired)
                    nRequiredCount++;
            }

            List<Link> links = info.NodeLinks[obj];
            if (links.Count < nRequiredCount || poluses.Count < links.Count)
                return false;

            foreach (Link link in links)
            {
                NetworkObject neighbor = (link.FromCP.Owner == obj ? link.ToCP.Owner : link.FromCP.Owner) as NetworkObject;
                if (neighbor.Routine != null)
                {
                    string polusName = link.FromCP.Owner == obj ? link.PolusTo : link.PolusFrom;
                    Polus neighborPolus = neighbor.Routine.GetPolus(polusName);
                    IOWLClass indivClass = GetIndividualClass(indiv);
                    IOWLClass canConnectedWith = GetClass(neighborPolus.CanConnectedWith);
                    if (indivClass.Name != canConnectedWith.Name && !IsSubclassOf(indivClass, canConnectedWith))
                        return false;
                }
            }

            int nReqCount = 0;
            return CompleteNodeLink(info, obj, poluses, 0, ref nReqCount);
        }

        private bool CompleteNodeLink(SimulationInfo info, NetworkObject obj, List<Polus> poluses, int N, ref int nReqCount)
        {
            List<Link> links = info.NodeLinks[obj];
            if (links.Count == N)
            {
                long nRequiredCount = 0;
                foreach (Polus polus in poluses)
                {
                    if (polus.IsRequired)
                        nRequiredCount++;
                }
                return nReqCount == nRequiredCount;
            }

            Link link = links[N];
            string prevPolus = link.FromCP.Owner == obj ? link.PolusFrom : link.PolusTo;
            for (int i = 0; i < poluses.Count; i++)
            {
                Polus polus = poluses[i];
                if (polus.CanConnectedWith.Length > 0)
                {
                    NetworkObject neighbor = (link.FromCP.Owner == obj ? link.ToCP.Owner : link.FromCP.Owner) as NetworkObject;
                    IOWLClass routClass = GetClass(polus.CanConnectedWith);
                    if (CompletedNodes.ContainsKey(neighbor))
                    {
                        OWLNamedIndividual indiv = CompletedNodes[neighbor];
                        if (!GetIndividuals(routClass).Contains(indiv))
                            continue;
                    }
                    else
                    {
                        IOWLClass neighborClass = GetClass(neighbor.Routine == null ? neighbor.SemanticType : neighbor.Routine.Type);
                        IRI iri = (routClass.InnerObject as OWLClass).getIRI();
                        if (iri != (neighborClass.InnerObject as OWLClass).getIRI())
                        {
                            if (!IsSubclassOf(neighborClass, routClass) &&
                                (neighbor.Routine != null || !IsSubclassOf(routClass, neighborClass)))
                                continue;
                        }
                    }
                }
                if (link.FromCP.Owner == obj)
                    link.PolusFrom = polus.Name;
                else
                    link.PolusTo = polus.Name;

                List<Polus> newList = new List<Polus>(poluses);
                newList.Remove(polus);
                if (CompleteNodeLink(info, obj, newList, N + 1, ref nReqCount))
                {
                    if (polus.IsRequired)
                        nReqCount++;
                    return true;
                }
            }
            if (link.FromCP.Owner == obj)
                link.PolusFrom = prevPolus;
            else
                link.PolusTo = prevPolus;
            return false;
        }

        private bool IsSubclassOf(IOWLClass cls1, IOWLClass cls2)
        {
            IRI iri = (cls1.InnerObject as OWLClass).getIRI();
            foreach (IOWLClass cls in GetSubClasses(cls2))
            {
                if ((cls.InnerObject as OWLClass).getIRI() == iri)
                    return true;
            }
            return false;
        }

        private List<OWLNamedIndividual> GetRoutinePoluses(OWLNamedIndividual RoutineInvidiv)
        {
            List<OWLNamedIndividual> res = new List<OWLNamedIndividual>();
            OWLObjectProperty objPropHasRoutinePole = factory.getOWLObjectProperty(IRI.create("http://www.psu.ru/ontologies/2009/4/TriadNetCommon.owl#hasRoutinePole"));
            Set s = RoutineInvidiv.getObjectPropertyValues(objPropHasRoutinePole, ontology);
            Iterator PolusIter = s.iterator();
            while (PolusIter.hasNext())
            {
                OWLNamedIndividual pol = PolusIter.next() as OWLNamedIndividual;
                res.Add(pol);
            }
            return res;
        }

        private List<OWLNamedIndividual> GetRoutineParams(OWLNamedIndividual routIndiv)
        {
            List<OWLNamedIndividual> res = new List<OWLNamedIndividual>();
            OWLObjectProperty objPropHasRoutineParam = factory.getOWLObjectProperty(IRI.create("http://www.psu.ru/ontologies/2009/4/TriadNetCommon.owl#hasRoutineParameter"));
            Set s = routIndiv.getObjectPropertyValues(objPropHasRoutineParam, ontology);
            Iterator ParamIter = s.iterator();
            while (ParamIter.hasNext())
            {
                OWLNamedIndividual param = ParamIter.next() as OWLNamedIndividual;
                res.Add(param);
            }
            return res;
        }

        private List<Polus> GetPoluses(OWLNamedIndividual RoutineInvidiv)
        {
            OWLDataProperty dataPropHasName = factory.getOWLDataProperty(IRI.create("http://www.psu.ru/ontologies/2009/4/TriadNetCommon.owl#hasName"));
            OWLDataProperty dataPropIsRequired = factory.getOWLDataProperty(IRI.create("http://www.psu.ru/ontologies/2009/4/ComputerNetwork.owl#isRequired"));
            List<Polus> res = new List<Polus>();
            foreach (OWLNamedIndividual pol in GetRoutinePoluses(RoutineInvidiv))
            {
                Map map = pol.getDataPropertyValues(ontology);
                OWLLiteral name = ((Set)map.get(dataPropHasName)).iterator().next() as OWLLiteral;
                OWLLiteral isRequired = ((Set)map.get(dataPropIsRequired)).iterator().next() as OWLLiteral;
                OWLClassAssertionAxiom ax = ontology.getClassAssertionAxioms(pol).iterator().next() as OWLClassAssertionAxiom;
                OWLClass routPolusClass = ax.getClassExpression().asOWLClass();

                Polus polus = new Polus(name.getLiteral());
                polus.IsRequired = isRequired.parseBoolean();
                polus.CanConnectedWith = GetRoutineCanConnectedWith(routPolusClass).getIRI().getFragment();
                if (polus.UpperBounds.Count == 1) //!!!пока так
                {
                    for (int i = 0; i < polus.UpperBounds[0]; i++)
                    {
                        Polus p = new Polus(polus.Name);
                        p.Name = polus.Name + "[" + i.ToString() + "]";
                        p.IsRequired = polus.IsRequired;
                        p.CanConnectedWith = polus.CanConnectedWith;
                        res.Add(p);
                    }
                }
                else
                    res.Add(polus);
            }
            return res;
        }


        public void SaveOntology(string sPath)
        {
            JIO.File file = new JIO.File(sPath);
            manager.saveOntology(ontology, IRI.create(file.toURI()));
        }

        public IOWLClass AddClass(string sName)
        {
            OWLClass cls = factory.getOWLClass(":" + sName, pm);
            OWLDeclarationAxiom ax = factory.getOWLDeclarationAxiom(cls);
            manager.applyChange(new AddAxiom(ontology, ax));
            return new COWLClass(ontology, cls);
        }

        public void RemoveClass(IOWLClass cls)
        {
            if (cls == null)
                return;
            OWLEntityRemover remover = new OWLEntityRemover(manager, Collections.singleton(ontology));

            foreach (OWLNamedIndividual indiv in GetIndividuals(cls, false))
            {
                foreach (OWLNamedIndividual polIndiv in GetRoutinePoluses(indiv))
                    polIndiv.accept(remover);
                foreach (OWLNamedIndividual paramIndiv in GetRoutineParams(indiv))
                    paramIndiv.accept(remover);
                indiv.accept(remover);
            }

            IOWLClass routClass = GetRoutineClass(cls);
            if (routClass != null)
                RemoveClass(routClass);
            
            OWLClass polusClass = GetPolusCanConnectedWith(cls.InnerObject as OWLClass);
            if (polusClass != null)
                RemoveClass(new COWLClass(ontology, polusClass));
            
            foreach (IOWLClass subClass in GetSubClasses(cls, false))
                RemoveClass(subClass);
            
            (cls.InnerObject as OWLClass).accept(remover);
            
            manager.applyChanges(remover.getChanges());
        }

        public IOWLClass GetClass(string sName)
        {
            IOWLClass res = null;
            Set set = ontology.getDeclarationAxioms(factory.getOWLClass(":" + sName, pm));
            if (set.size() == 1)
            {
                OWLDeclarationAxiom ax = set.iterator().next() as OWLDeclarationAxiom;
                OWLClass cls = ax.getEntity().asOWLClass();
                if (cls != null)
                    res = new COWLClass(ontology, cls);
            }
            return res;
        }

        public List<IOWLClass> GetSubClasses(IOWLClass cls, bool bWithSubClasses = true)
        {
            List<IOWLClass> res = new List<IOWLClass>();
            Set subClasses = (cls.InnerObject as OWLClass).getSubClasses(ontology);
            Iterator it = subClasses.iterator();
            while (it.hasNext())
            {
                IOWLClass subClass = new COWLClass(ontology, it.next() as OWLClass);
                res.Add(subClass);
                if (bWithSubClasses)
                    res.AddRange(GetSubClasses(subClass));
            }
            return res;
        }

        public List<IOWLClass> GetComputerNetworkElements()
        {
            OWLClass superClass = factory.getOWLClass(":PetriNetNode", pm);
            return GetSubClasses(new COWLClass(ontology, superClass));
        }

        public void AddSubClass(IOWLClass subClass, IOWLClass superClass)
        {
            OWLSubClassOfAxiom ax = factory.getOWLSubClassOfAxiom(subClass.InnerObject as OWLClass, superClass.InnerObject as OWLClass);
            manager.applyChange(new AddAxiom(ontology, ax));
            //OWLClass cl = factory.getOWLClass(":ComputerNetworkRoutine", pm);
        }

        public IOWLClass AddRoutine(IOWLClass superClass, IOWLClass nodeClass, string sName)
        {
            IOWLClass routClass = AddClass(sName + "Routine");
            AddSubClass(routClass, superClass);
            AddPutsProperty(routClass, nodeClass);
            AddRoutinePolusClass(routClass.InnerObject as OWLClass);
            return routClass;
        }

        public IOWLClass GetRoutineClass(IOWLClass nodeClass)
        {
            OWLClass subClass = nodeClass.InnerObject as OWLClass;
            OWLObjectProperty pr = factory.getOWLObjectProperty(IRI.create("http://www.psu.ru/ontologies/2009/4/TriadNetCommon.owl#putsOn"));
            Set s = pr.getReferencingAxioms(ontology);
            Iterator it = s.iterator();
            while (it.hasNext())
            {
                OWLAxiom obj = it.next() as OWLAxiom;
                if (obj.getAxiomType() == AxiomType.SUBCLASS_OF)
                {
                    OWLSubClassOfAxiom sax = obj as OWLSubClassOfAxiom;
                    if (sax.getSuperClass() is OWLObjectAllValuesFrom)
                    {
                        OWLObjectAllValuesFrom restr = sax.getSuperClass() as OWLObjectAllValuesFrom;
                        if ((restr.getFiller() as OWLEntity).getIRI() == subClass.getIRI())
                            return new COWLClass(ontology, sax.getSubClass().asOWLClass());
                    }
                }
            }
            return null;
        }

        public void AddPutsProperty(IOWLClass routClass, IOWLClass nodeClass)
        {
            OWLObjectProperty pr = factory.getOWLObjectProperty(IRI.create("http://www.psu.ru/ontologies/2009/4/TriadNetCommon.owl#putsOn"));
            OWLClassExpression putsOnNode = factory.getOWLObjectAllValuesFrom(pr, nodeClass.InnerObject as OWLClass);
            OWLSubClassOfAxiom ax = factory.getOWLSubClassOfAxiom(routClass.InnerObject as OWLClass, putsOnNode);
            manager.applyChange(new AddAxiom(ontology, ax));
        }

        public void AddInstance(IOWLClass routClass, Routine rout)
        {
            List changes;
            OWLClass superClass = routClass.InnerObject as OWLClass;
            OWLClass routineClass = factory.getOWLClass(":" + rout.Name, pm);
            OWLSubClassOfAxiom subClassOfAx = factory.getOWLSubClassOfAxiom(routineClass, superClass);
            changes = manager.addAxiom(ontology, subClassOfAx);

            OWLIndividual routineIndiv = CreateIndividual(ontology, routineClass);
            OWLDataProperty dataPropName = factory.getOWLDataProperty(IRI.create("http://www.psu.ru/ontologies/2009/4/TriadNetCommon.owl#hasName"));

            //name
            OWLDataPropertyAssertionAxiom dataPropAssertionAx = factory.getOWLDataPropertyAssertionAxiom(dataPropName, routineIndiv, rout.Name);
            changes.addAll(manager.addAxiom(ontology, dataPropAssertionAx));

            //assembly
            OWLDataProperty propAssembly = factory.getOWLDataProperty(IRI.create("http://www.psu.ru/ontologies/2009/4/TriadNetCommon.owl#assemblyPath"));
            dataPropAssertionAx = factory.getOWLDataPropertyAssertionAxiom(propAssembly, routineIndiv, 
                                            factory.getOWLLiteral(rout.Name + ".dll", OWL2Datatype.XSD_ANY_URI));
            changes.addAll(manager.addAxiom(ontology, dataPropAssertionAx));

            //poluses
            OWLObjectProperty objPropHasRoutinePole = factory.getOWLObjectProperty(IRI.create("http://www.psu.ru/ontologies/2009/4/TriadNetCommon.owl#hasRoutinePole"));
            OWLDataProperty dataPropRequired = factory.getOWLDataProperty(":isRequired", pm);
            OWLObjectProperty objPropCanConnectedWith = factory.getOWLObjectProperty(":canConnectedWith", pm);
            OWLObjectProperty objPropHasRoutinePoleInvert = objPropHasRoutinePole.getInverses(mainOntology).iterator().next() as OWLObjectProperty;
            OWLClass mainRoutPolusClass = factory.getOWLClass(":ComputerNetworkRoutinePole", pm);

            //add polus
            OWLClass routPolusClass = AddRoutinePolusClass(routineClass);

            for (int i = 0, nCount = rout.Poluses.Count; i < nCount; i++)
            {
                Polus polus = rout.Poluses[i];
                OWLClass canConnectedWithPolusClass = mainRoutPolusClass;
                IOWLClass routCanConnected = GetClass(polus.CanConnectedWith);
                if (routCanConnected != null)
                    canConnectedWithPolusClass = GetPolusCanConnectedWith(routCanConnected.InnerObject as OWLClass) ?? mainRoutPolusClass;
                OWLIndividual indiv = CreateIndividual(ontology, canConnectedWithPolusClass, polus.Name);

                //name
                dataPropAssertionAx = factory.getOWLDataPropertyAssertionAxiom(dataPropName, indiv, polus.FullName);
                changes.addAll(manager.addAxiom(ontology, dataPropAssertionAx));

                //isRequired
                bool bIsRequired = polus.IsRequired;
                dataPropAssertionAx = factory.getOWLDataPropertyAssertionAxiom(dataPropRequired, indiv, bIsRequired);
                changes.addAll(manager.addAxiom(ontology, dataPropAssertionAx));

                //hasRoutine
                OWLObjectPropertyAssertionAxiom objectPropAssertionAx = factory.getOWLObjectPropertyAssertionAxiom(objPropHasRoutinePole, routineIndiv, indiv);
                changes.addAll(manager.addAxiom(ontology, objectPropAssertionAx));

                objectPropAssertionAx = factory.getOWLObjectPropertyAssertionAxiom(objPropHasRoutinePoleInvert, indiv, routineIndiv);
                changes.addAll(manager.addAxiom(ontology, objectPropAssertionAx));
            }

            //parameters
            OWLObjectProperty propHasRoutineParam = factory.getOWLObjectProperty(IRI.create("http://www.psu.ru/ontologies/2009/4/TriadNetCommon.owl#hasRoutineParameter"));
            OWLObjectProperty propHasRoutineParamInvert = propHasRoutineParam.getInverses(mainOntology).iterator().next() as OWLObjectProperty;
            OWLDataProperty propParamIndex = factory.getOWLDataProperty(IRI.create("http://www.psu.ru/ontologies/2009/4/TriadNetCommon.owl#hasParameterIndex"));
            OWLDataProperty propParamType = factory.getOWLDataProperty(IRI.create("http://www.psu.ru/ontologies/2009/4/TriadNetCommon.owl#hasParameterType"));
            OWLDataProperty propParamValue = factory.getOWLDataProperty(IRI.create("http://www.psu.ru/ontologies/2009/4/TriadNetCommon.owl#hasParameterDefaultValue"));
            OWLClass routParam = factory.getOWLClass(IRI.create("http://www.psu.ru/ontologies/2009/4/TriadNetCommon.owl#RoutineParameter"));
            for (int i = 0, nCount = rout.Parameters.Count; i < nCount; i++)
            {
                IExprType type = rout.Parameters[i];
                OWLIndividual indiv = CreateIndividual(ontology, routParam, type.Name);

                OWLAnnotation commentAnno = factory.getOWLAnnotation(factory.getOWLAnnotationProperty(OWLRDFVocabulary.RDFS_COMMENT.getIRI()),
                                                factory.getOWLLiteral(rout.ParamDescription[i]));
                changes.addAll(manager.addAxiom(ontology, factory.getOWLAnnotationAssertionAxiom(indiv.asOWLNamedIndividual().getIRI(), commentAnno)));

                //name
                dataPropAssertionAx = factory.getOWLDataPropertyAssertionAxiom(dataPropName, indiv, type.Name);
                changes.addAll(manager.addAxiom(ontology, dataPropAssertionAx));

                //index
                dataPropAssertionAx = factory.getOWLDataPropertyAssertionAxiom(propParamIndex, indiv, i);
                changes.addAll(manager.addAxiom(ontology, dataPropAssertionAx));

                //type
                dataPropAssertionAx = factory.getOWLDataPropertyAssertionAxiom(propParamType, indiv, type.Code.ToString());
                changes.addAll(manager.addAxiom(ontology, dataPropAssertionAx));

                //value
                dataPropAssertionAx = factory.getOWLDataPropertyAssertionAxiom(propParamValue, indiv, rout.ParameterValues[i].ToString());
                changes.addAll(manager.addAxiom(ontology, dataPropAssertionAx));

                //hasRoutineParameter
                OWLObjectPropertyAssertionAxiom objectPropAx = factory.getOWLObjectPropertyAssertionAxiom(propHasRoutineParam, routineIndiv, indiv);
                changes.addAll(manager.addAxiom(ontology, objectPropAx));

                objectPropAx = factory.getOWLObjectPropertyAssertionAxiom(propHasRoutineParamInvert, indiv, routineIndiv);
                changes.addAll(manager.addAxiom(ontology, objectPropAx));
            }
            manager.applyChanges(changes);
        }

        private OWLClass GetPolusCanConnectedWith(OWLClass routineClass)
        {
            OWLObjectProperty objPropCanConnectedWith = factory.getOWLObjectProperty(":canConnectedWith", pm);
            OWLClass polusClass = null;
            Set s = objPropCanConnectedWith.getReferencingAxioms(ontology);
            Iterator it = s.iterator();
            while (it.hasNext())
            {
                OWLAxiom ax = it.next() as OWLAxiom;
                if (ax.getAxiomType() == AxiomType.SUBCLASS_OF)
                {
                    OWLSubClassOfAxiom sax = ax as OWLSubClassOfAxiom;
                    if (((sax.getSuperClass() as OWLObjectAllValuesFrom).getFiller() as OWLEntity).getIRI() == routineClass.getIRI())
                    {
                        polusClass = sax.getSubClass().asOWLClass();
                        break;
                    }
                }
            }
            return polusClass;
        }

        private OWLClass GetRoutineCanConnectedWith(OWLClass polusClass)
        {
            OWLObjectProperty objPropCanConnectedWith = factory.getOWLObjectProperty(":canConnectedWith", pm);
            OWLClass routineClass = null;
            Set s = objPropCanConnectedWith.getReferencingAxioms(ontology);
            Iterator it = s.iterator();
            while (it.hasNext())
            {
                OWLAxiom ax = it.next() as OWLAxiom;
                if (ax.getAxiomType() == AxiomType.SUBCLASS_OF)
                {
                    OWLSubClassOfAxiom sax = ax as OWLSubClassOfAxiom;
                    if ((sax.getSubClass() as OWLEntity).getIRI() == polusClass.getIRI())
                    {
                        routineClass = (sax.getSuperClass() as OWLObjectAllValuesFrom).getFiller() as OWLClass;
                        break;
                    }
                }
            }
            Debug.Assert(routineClass != null);
            return routineClass;
        }

        private OWLClass AddRoutinePolusClass(OWLClass cls)
        {
            OWLClass superClass = (new COWLClass(ontology, cls)).SuperClass.InnerObject as OWLClass;
            OWLObjectProperty objPropCanConnectedWith = factory.getOWLObjectProperty(":canConnectedWith", pm);
            OWLClass superRoutPolusClass = GetPolusCanConnectedWith(superClass) ?? factory.getOWLClass(":ComputerNetworkRoutinePole", pm);
            OWLClass routPolusClass = factory.getOWLClass(":" + cls.getIRI().getFragment() + "Polus", pm);
            manager.applyChange(new AddAxiom(ontology, factory.getOWLSubClassOfAxiom(routPolusClass, superRoutPolusClass)));
            OWLClassExpression expr = factory.getOWLObjectAllValuesFrom(objPropCanConnectedWith, cls);
            manager.applyChange(new AddAxiom(ontology, factory.getOWLSubClassOfAxiom(routPolusClass, expr)));
            return routPolusClass;
        }

        private OWLIndividual CreateIndividual(OWLOntology ontology, OWLClass cls, string sName = "")
        {
            string sIRI = ontology.getOntologyID().getOntologyIRI().toString() + "#";
            sIRI += (sName.Length > 0 ? sName : cls.getIRI().getFragment());
            OWLIndividual res;
            int nIndex = 1;
            IRI iri = IRI.create(sName.Length > 0 ? sIRI : sIRI + nIndex++.ToString());
            while(ontology.containsEntityInSignature(iri, true))
                iri = IRI.create(sIRI + nIndex++.ToString());
            res = factory.getOWLNamedIndividual(iri);
            OWLClassAssertionAxiom ax = factory.getOWLClassAssertionAxiom(cls, res);
            manager.applyChange(new AddAxiom(ontology, ax));
            return res;
        }
            
    }

}
