using Newtonsoft.Json;

namespace Product_Pack_Manager
{
    public class Elementclass
    {
        [JsonProperty("id")]
        public int Id;
        [JsonProperty("label")]
        public string Label;
        [JsonProperty("color")]
        public string Color;
        [JsonProperty("shape")]
        public string Shape;
        [JsonProperty("font")]
        public Font Font;

        public Elementclass(int id, int packid,string sectionname, int elementtype, int elementid, string elementname, int prioritylevel)
        {
            Font font = new Font();
            Id = id;
            Label = elementname + "\n id " + id + " elementid " + elementid;
            font.Color = "#f4eee8";
            //give the right color (and text color) to normal node
            //empty and end node have a name change
            switch (elementtype)
            {
                case 1:
                    Color = "#810000";
                    break;
                case 2:
                    Color = "#007580";
                    break;
                case 3:
                    Color = "#fed049";
                    font.Color = "#114e60";
                    break;
                case 4:
                    Color = "#81b214";
                    Label = "End";
                    break;
                case 5:
                    Label = "(empty) id:" + id;
                    Color = "#150e56";
                    break;
            }
            Shape = "box";
            Font = font;

        }
    }
    public class Font 
    {
        [JsonProperty("color")]
        public string Color { get; set; }
    }
}