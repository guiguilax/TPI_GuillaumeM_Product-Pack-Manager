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
            //create the template
            concate = @"
var nodes = 
	{0}
;
var edges = 
	{1}
;";
            //overwrite file with new data
            System.IO.File.WriteAllText("Web/Script/Nodeandedge.js", string.Format(concate, nodemanager.Serealise(packid), linkmanager.Serealise(packid)));
        }
    }
}