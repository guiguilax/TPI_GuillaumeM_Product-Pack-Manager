using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product_Pack_Manager
{
    public class Elementparameter
    {
        public string Name { get; set; }
        public string Categorie { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public bool UseExisting { get; set; }
        public bool UseChecker { get; set; }
        public bool UsePriority { get; set; }
        public int PriorityLevel { get; set; }
        public bool IOI { get; set; } //Ignore On Invoice
        public bool DIOI { get; set; } //Display Item On Invoice
        public bool DPOI { get; set; } //Display Price On Invoice
        public bool DOP { get; set; } //Define Official Price
        public string DependOn { get; set; }

        public Elementparameter(int id, int packid,int SectionId, string sectionname, int elementtype, int elementid, string elementname, int min, int max, bool useexisting, bool usechecker, bool usepriority, int prioritylevel, bool ignoreoninvoice, bool displayitemoninvoice, bool displaypriceoninvoice, bool defineofficialprice)
        {
            Name = elementname;
            Categorie = sectionname;
            Min = min;
            Max = max;
            UseExisting = useexisting;
            UseChecker = usechecker;
            UsePriority = usepriority;
            PriorityLevel = prioritylevel;
            IOI = ignoreoninvoice;
            DIOI = displayitemoninvoice;
            DPOI = displaypriceoninvoice;
            DOP = defineofficialprice;
            DependOn = "";
        }
    }
}