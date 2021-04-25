using Newtonsoft.Json;

namespace Product_Pack_Manager
{
    public class Linkmanager
    {
        Sql sql = new Sql();
        public string Serealise(string packid)
        {
            return JsonConvert.SerializeObject(sql.requestedge(packid), Formatting.Indented);
        }
    }
}