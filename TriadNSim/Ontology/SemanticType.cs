using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using OwlDotNetApi;

namespace TriadNSim.Ontology
{
    /// <summary>
    /// Семантический тип
    /// </summary>
    public class SemanticType
    {
        ///// <summary>
        ///// Ссылка на вершину в графе OWL
        ///// </summary>
        //private IOwlNode owlNodeLink;

        ///// <summary>
        ///// Ссылка на менеджер онтологий, к графу которого принадлежит вершина
        ///// </summary>
        //private OntologyManager ontologyManager;

        ///// <summary>
        ///// Родительские элементы
        ///// </summary>
        //private List<SemanticType> parentTypes;

        ///// <summary>
        ///// Дочерние элементы
        ///// </summary>
        //private List<SemanticType> childTypes;

        ///// <summary>
        ///// Конструктор
        ///// </summary>
        ///// <param name="owlNodeLink"></param>
        ///// <param name="manager"></param>
        //public SemanticType(IOwlNode owlNodeLink, OntologyManager manager)
        //{
        //    this.owlNodeLink = owlNodeLink;
        //    this.ontologyManager = manager;
        //    this.parentTypes = new List<SemanticType>();
        //    this.childTypes = new List<SemanticType>();
        //}

        ///// <summary>
        ///// Вернуть ссылку на вершину
        ///// </summary>
        ///// <returns></returns>
        //public IOwlNode getOwlNodeLink()
        //{
        //    return owlNodeLink;
        //}

        ///// <summary>
        ///// Идентификатор вершины онтолгиий, соответствующей семантическому типу
        ///// </summary>
        ///// <returns></returns>
        //public string getOwlNodeId()
        //{
        //    return owlNodeLink.ID;
        //}

        ///// <summary>
        ///// Наименование семантического типа
        ///// </summary>
        ///// <returns></returns>
        //public string getName()
        //{
        //    return owlNodeLink.ID.Split(new char[] { '#' })[1];
        //}

        ///// <summary>
        ///// Получить комментарий
        ///// </summary>
        ///// <returns></returns>
        //public string getComment()
        //{
        //    IOwlEdgeList commentEdges =
        //        (IOwlEdgeList)owlNodeLink.ChildEdges["http://www.w3.org/2000/01/rdf-schema#comment"];
        //    if (commentEdges != null && commentEdges.Count > 0)
        //        return commentEdges[0].ChildNode.ID;
        //    else
        //        return "Нет комментария";
        //}

        ///// <summary>
        ///// Получить список родительских типов
        ///// </summary>
        ///// <returns></returns>
        //public List<SemanticType> getParentTypes()
        //{
        //    return parentTypes;
        //}

        ///// <summary>
        ///// Установить список родительских типов
        ///// </summary>
        ///// <param name="parentTypes"></param>
        //public void setParentTypes(List<SemanticType> parentTypes)
        //{
        //    this.parentTypes = parentTypes;
        //}

        ///// <summary>
        ///// Получить дочерние типы
        ///// </summary>
        ///// <returns></returns>
        //public List<SemanticType> getChildTypes()
        //{
        //    return this.childTypes;
        //}

        ///// <summary>
        ///// Установить дочерние типы
        ///// </summary>
        ///// <param name="childTypes"></param>
        //public void setChildTypes(List<SemanticType> childTypes)
        //{
        //    this.childTypes = childTypes;
        //}
    }
}
