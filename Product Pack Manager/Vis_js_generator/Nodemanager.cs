﻿using Newtonsoft.Json;

namespace Product_Pack_Manager
{
    public class Nodemanager
    {
        Sql sql = new Sql();
        public string Serealise(string packid)
        {
            return JsonConvert.SerializeObject(sql.requestnode(packid), Formatting.Indented);
        }
    }
}

