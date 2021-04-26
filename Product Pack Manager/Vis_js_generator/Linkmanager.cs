using Newtonsoft.Json;

namespace Product_Pack_Manager
{
    public class Linkmanager
    {
        Sql sql = new Sql();
        //return the list of link to set in the vis.js config file
        public string Serealise(string packid)
        {
            return JsonConvert.SerializeObject(sql.requestedge(packid), Formatting.Indented);
        }
    }
}