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
            {/*
                //take only the first letter to display it on the edge
                if ((actionwhentrue == "CREATE") || (actionwhentrue == "GETEXISTING"))
                {
                    actionwhentrue = actionwhentrue.Substring(0, 1);
                }
                //same for --ASK but since there two "-" i manualy set it to "A"
                else if (actionwhentrue == "--ASK")
                {
                    actionwhentrue = "A";
                }
                //for CREATEORREUSE since "C" already used i manualy put "CoR" 
                else 
                {
                    actionwhentrue = "CoR";
                }
                //same part but for false
                //take only the first letter to display it on the edge
                if ((actionwhenfalse == "CREATE") || (actionwhenfalse == "GETEXISTING"))
                {
                    actionwhenfalse = actionwhenfalse.Substring(0, 1);
                }
                //same for --ASK but since there two "-" i manualy set it to "A"
                else if (actionwhenfalse == "--ASK")
                {
                    actionwhenfalse = "A";
                }
                //for CREATEORREUSE since "C" already used i manualy put "CoR" 
                else
                {
                    actionwhenfalse = "CoR";
                }
                */


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