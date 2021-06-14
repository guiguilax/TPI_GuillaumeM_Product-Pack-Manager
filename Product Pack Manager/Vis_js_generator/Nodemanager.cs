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
        public string nodeparameter(string id) 
        {
            List<Elementparameter> parameterlist;
            parameterlist = sql.elementdetail(id);
            
            string mytest = parameterlist[0].Name;
            
            return ';
        }
    }
}

