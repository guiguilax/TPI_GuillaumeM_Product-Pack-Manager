namespace Product_Pack_Manager
{
    public class Elementfrompack
    {
        public int Elementid { get; set; }
        public string Elementname { get; set; }

        public Elementfrompack(int id, int packid, string sectionname, int elementtype, int elementid, string elementname, int prioritylevel)
        {
            if (elementtype != 4)
            {
                Elementid = id;
                Elementname = elementname;
            }
            if (elementtype == 5)
            {
                //element id is always 0 if elementtype == 5 so we take id to work with
                Elementid = id;
                Elementname = "(empty) id:" + id;
            }
            if (elementtype == 4)
            {
                Elementid = id;
                Elementname = "end";
            }
        }
    }
    public class Elementidandtype
    { 
        public int Id { get; set; }
        public int Type { get; set; }
        public Elementidandtype(int id, int packid, int sectionid, string sectionname, int elementtype, int elementid, string elementname, int min, int max, bool useexisting, bool usechecker, bool usepriority, int prioritylevel, bool ignoreoninvoice, bool displayitemoninvoice, bool displaypriceoninvoice, bool defineofficialprice) 
        {
            Id = elementid;
            Type = elementtype;
        }
    }
}