using Newtonsoft.Json;
using System.Collections.Generic;

namespace Product_Pack_Manager
{
    public class Nodemanager
    {
        Sql sql = new Sql();
        //return the list of node to set in the vis.js config file
        public string Serealise(string packid)
        {
            return JsonConvert.SerializeObject(sql.requestnode(packid), Formatting.Indented);
        }
        public string GetNodeParameter(int id) 
        {
            return JsonConvert.SerializeObject(sql.GetElementDetail(id));
            /////ici tu doit tout mettre dans une seul string et séparé tout dans js avec les espaces
            //return "£" + parameterlist[0].Name + "£" + parameterlist[0].Categorie + "£" + parameterlist[0].Min + "£" + parameterlist[0].Max + "£" + parameterlist[0].UseExisting + "£" + parameterlist[0].UseChecker + "£" + parameterlist[0].UsePriority + "£" + parameterlist[0].PriorityLevel + "£" + parameterlist[0].IOI + "£" + parameterlist[0].DIOI + "£" + parameterlist[0].DPOI + "£" + parameterlist[0].DOP + "£" + parameterlist[0].DependOn + "£";
        }
    }
}

