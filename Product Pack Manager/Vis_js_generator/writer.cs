using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product_Pack_Manager
{
    public class writer
    {
        string concate;
        public void writerall(string packid) 
        {
            Nodemanager nodemanager = new Nodemanager();
            Linkmanager linkmanager = new Linkmanager();
            concate = @"
var nodes = 
	{0}
;
var edges = 
	{1}
;";
            System.IO.File.WriteAllText("H:/TPI/Product Pack Manager/Product Pack Manager/Web/Script/Nodeandedge.js", string.Format(concate, nodemanager.Serealise(packid), linkmanager.Serealise(packid)));
        }
    }
}