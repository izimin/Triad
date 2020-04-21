using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TriadPad;
using TriadCompiler;
using DrawingPanel;
using System.IO;

using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.ComponentModel;
using TriadNSim.Ontology;

namespace TriadNSim.Forms
{
    //========================  frmEditIP ==================
    public class frmEditIP : frmEditBase
    {
        private string CompiledFileName = ".\\NewIP.txt";
        public InfProcedure IProcedure = null;
        private InfProcedure EditIP = null;

        public frmEditIP()
        {
            this.splitContainer1.Panel2Collapsed = false;
        }

        public void SetIP(InfProcedure proc)
        {
            EditIP = proc;
            Code = proc.Code;
            Description = proc.Description;
        }

        protected override void CompileCode(IOErrorListener io)
        {
            CompilerFacade.CompileIProcedureToTxt(io, this.CompiledFileName);
        }

        protected override bool OnOk()
        {
            IProcedure = new InfProcedure((CompilerFacade.GetDesignTypeInfo() as IPInfo).IPType, false);
            IProcedure.Description = Description;
            IProcedure.Code = Code;

            bool bFind = false;
            foreach (InfProcedure proc in frmMain.Instance.userIProcedures)
            {
                if (proc.Name == IProcedure.Name && EditIP != proc)
                {
                    bFind = true;
                    break;
                }
            }
            if (bFind)
                MessageBox.Show(this, "ИП с таким именем уже существует", "Ошибка", MessageBoxButtons.OK);
            else
            {
                // ?????????????????
                {
                    string sFileName = IProcedure.Name + ".dll";
                    if (File.Exists(sFileName))
                        File.Delete(sFileName);
                    CompilerParameters compilerParameters = new CompilerParameters();
                    compilerParameters.CompilerOptions = "/t:library";
                    compilerParameters.GenerateInMemory = false;
                    compilerParameters.OutputAssembly = sFileName;
                    compilerParameters.ReferencedAssemblies.Add("system.dll");
                    compilerParameters.ReferencedAssemblies.Add("TriadCore.dll");
                    new CSharpCodeProvider().CompileAssemblyFromFile(compilerParameters, CompiledFileName);
                }
            }
            return !bFind;
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerText)).BeginInit();
            this.splitContainerText.Panel1.SuspendLayout();
            this.splitContainerText.Panel2.SuspendLayout();
            this.splitContainerText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerText
            // 
            // 
            // splitContainer
            // 
            // 
            // splitContainer1
            // 
            // 
            // frmEditIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(488, 326);
            this.Name = "frmEditIP";
            this.Text = "Edit IP";
            this.splitContainerText.Panel1.ResumeLayout(false);
            this.splitContainerText.Panel1.PerformLayout();
            this.splitContainerText.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerText)).EndInit();
            this.splitContainerText.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }

    //========================  frmChangeRoutine ==================
    public class frmChangeRoutine : frmEditBase
    {
        private DrawingPanel.DrawingPanel drawingPanel;
        private NetworkObject obj;
        public static string CompiledFileName = ".\\NewRoutine.txt";
        public List<Polus> Poluses;
        public List<IExprType> Variables;
        public List<IExprType> Parameters;
        public List<string> RoutineEvents;
        public Routine ResultRoutine { private set; get; }
        public event CancelEventHandler OnNameChecked;

        public frmChangeRoutine(DrawingPanel.DrawingPanel panel)
        {
            drawingPanel = panel;
            Poluses = new List<Polus>();
            Variables = new List<IExprType>();
            Parameters = new List<IExprType>();
            RoutineEvents = new List<string>();
            this.Text = "Изменение поведения";
        }

        public static void SaveLastCompiledRoutine(string sPath)
        {
            if (File.Exists(frmChangeRoutine.CompiledFileName))
            {
				if (File.Exists(sPath))
					File.Delete(sPath);
                CompilerParameters compilerParameters = new CompilerParameters();
                compilerParameters.CompilerOptions = "/t:library";
                compilerParameters.GenerateInMemory = false;
                compilerParameters.OutputAssembly = sPath;
                compilerParameters.ReferencedAssemblies.Add("system.dll");
                compilerParameters.ReferencedAssemblies.Add("TriadCore.dll");
                new CSharpCodeProvider().CompileAssemblyFromFile(compilerParameters, frmChangeRoutine.CompiledFileName);
            }
        }

        public void SetObject(NetworkObject obj)
        {
            this.obj = obj;
            this.Code = obj != null ? obj.Routine.Text : "";
        }

        protected override void CompileCode(IOErrorListener io)
        {
            CompilerFacade.CompileRoutineToTxt(io, frmChangeRoutine.CompiledFileName);
        }

        protected override bool OnOk()
        {
            {
                Poluses.Clear();
                Variables.Clear();
                RoutineEvents.Clear();
                Parameters.Clear();
                RoutineInfo info = CompilerFacade.GetDesignTypeInfo() as RoutineInfo;
                if (info != null)
                {
                    if (info.Poluses != null)
                    {
                        foreach (IPolusType polus in info.Poluses)
                            Poluses.Add(new Polus(polus));
                    }
                    if (info.Variables != null)
                        Variables.AddRange(info.Variables);
                    if (info.Events != null)
                        RoutineEvents.AddRange(info.Events);
                    if (info.Parameters != null)
                        Parameters.AddRange(info.Parameters);
                }
            }

            bool bFind = false;
            foreach(BaseObject shape in drawingPanel.Shapes)
            {
                NetworkObject networkObj = shape as NetworkObject;
                if (networkObj != null && (networkObj.Type != ENetworkObjectType.UserObject || networkObj == obj))
                    continue;
				if (networkObj != null && networkObj.Routine != null && networkObj.Routine.Name == DesignTypeName)
                {
                    bFind = true;
                    break;
                }
            }
            CancelEventArgs args = new CancelEventArgs();
            OnNameChecked(this, args);
            bool bRes = false;
            if (bFind || args.Cancel)
            {
                MessageBox.Show(this, "Рутина с таким именем уже существует", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                frmEditParam param = null;
                if (Parameters.Count > 0)
                    param = new frmEditParam(Parameters);
                this.Visible = false;
                if (param == null || param.ShowDialog() == DialogResult.OK)
                {
                    this.ResultRoutine = obj != null ? obj.Routine : new Routine();
                    this.ResultRoutine.Text = Code;
                    this.ResultRoutine.Name = DesignTypeName;
                    this.ResultRoutine.Poluses = Poluses;
                    this.ResultRoutine.Variables = Variables;
                    this.ResultRoutine.Events = RoutineEvents;
                    this.ResultRoutine.Parameters = Parameters;
                    if (param != null)
                    {
                        this.ResultRoutine.ParameterValues = param.Values;
                        this.ResultRoutine.ParamDescription = param.Descriptions.ToList();
                    }
                    if (obj != null || new frmEditPolus(ResultRoutine).ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        bRes = true;
                }
                if (!bRes)
                    Visible = true;
            }
            return bRes;
        }
    }

    public class frmChangeSimCondition : frmEditBase
    {
        public static string CompiledFileNameTxt = "SimCondition.txt";
        public static string CompiledFileNameDll = "SimCondition.dll";
        private SimCondition simCond;

        public frmChangeSimCondition()
        {
            this.Text = "Изменение УМ";
            this.splitContainer1.Panel2Collapsed = false;
        }

        public void SetSimCondition(SimCondition simCondition)
        {
            simCond = simCondition;
            Code = simCond.Code;
            Description = simCond.Description;
        }

        protected override bool OnOk()
        {
            bool bFind = false;
            foreach (SimCondition simCond in frmMain.Instance.simConditions)
            {
                if (simCond.Name == DesignTypeName && this.simCond != simCond)
                {
                    bFind = true;
                    break;
                }
            }
            if (bFind)
                MessageBox.Show(this, "УМ с таким именем уже существует", "Ошибка", MessageBoxButtons.OK);
            return !bFind;
        }

        protected override void CompileCode(IOErrorListener io)
        {
            CompileTo(string.Empty, frmChangeSimCondition.CompiledFileNameTxt, io);
            //CompilerFacade.CompileIConditionToTxt(io, frmChangeSimCondition.CompiledFileNameTxt);
        }

        public static bool CompileTo(string sCode, string sFileName, IOErrorListener io = null)
        {
            bool bDll = Path.GetExtension(sFileName) == "dll";
            if (File.Exists(sFileName))
                File.Delete(sFileName);
            
            if (io == null)
            {
                RichTextBox inputRtb = new RichTextBox();
                inputRtb.Text = sCode;
                InputRichEdit input = new InputRichEdit(inputRtb);
                OutputRichEdit output = new OutputRichEdit(new RichTextBox());
                io = new IOErrorListener(input, output);
            }

            CommonArea.CreateNewArea();
            {
                //рутины
                COWLOntologyManager manager = frmMain.Instance.OntologyManager;
                foreach (var indiv in manager.GetIndividuals(manager.GetClass("ComputerNetworkRoutine")))
                {
                    Routine r = manager.CreateRoutine(indiv);
                    DesignTypeType designTypeType = new DesignTypeType(r.Name, DesignTypeCode.Routine);
                    foreach (var param in r.Parameters)
                        designTypeType.AddParameter(new TriadCompiler.VarType(param.Code, param.Name));
                    CommonArea.Instance.Register(designTypeType);
                }

                //IP
                foreach (InfProcedure iprocedure in frmMain.Instance.userIProcedures)
                {
                    IProcedureType proc = new IProcedureType(iprocedure.Name, iprocedure.ReturnCode);
                    foreach (IPParam param in iprocedure.Params)
                    {
                        ISpyType type = null;
                        if (param.IsPolus)
                            type = new PolusType(true, true);
                        else if (param.IsEvent)
                            type = new EventType(string.Empty);
                        else
                            type = new VarType(param.Code);
                        type.IsSpyObject = true;
                        proc.AddParameter(type);
                    }
                    CommonArea.Instance.Register(proc);
                }
            }
            CompilerFacade.NeedClearArea = false;

            if (bDll)
                CompilerFacade.CompileIConditionToDll(io, sFileName);
            else
                CompilerFacade.CompileIConditionToTxt(io, sFileName);
            return io.getRegisteredErrors().Length == 0;
        }
    }
}