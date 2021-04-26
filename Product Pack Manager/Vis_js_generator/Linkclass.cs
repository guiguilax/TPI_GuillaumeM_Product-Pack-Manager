using Newtonsoft.Json;

namespace Product_Pack_Manager
{
    public class Linkclass
    {
        [JsonProperty("from")]
        public int From;
        [JsonProperty("to")]
        public int To;
        [JsonProperty("label")]
        public string Label;

        public Linkclass(int id, int packid, int elementidfrom, int elementidto, string linkcondition, string actionwhentrue, string actionwhenfalse)
        {
            From = elementidfrom;
            To = elementidto;
            if (linkcondition == "")
            {
                Label = "";
            }
            else 
            {
                Label = actionwhentrue + "/" + actionwhenfalse;
            }
        }
    }

    public class Linkclassdropdown
    {
        public string Label { get; set; }

        public int Id { get; set; }

        public Linkclassdropdown(int id, int packid, int elementidfrom, int elementidto, string linkcondition, string actionwhentrue, string actionwhenfalse)
        {
            Label = "from "+elementidfrom + ", to "+ elementidto;
            Id = id;
        }
    }
    public class fromtolink
    {
        public int From { get; set; }
        public int To { get; set; }

        public fromtolink(int idelementfrom, int idelementto) 
        {
            From = idelementfrom;
            To = idelementto;
        }


    }
}