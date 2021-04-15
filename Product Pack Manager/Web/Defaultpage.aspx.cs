using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Product_Pack_Manager.Web
{
    public partial class Defaultpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Sql sql = new Sql();
            
        }

        protected void Displaypackbutton_Click(object sender, EventArgs e)
        {
            string Selectedpack = Dropdownpacklist.Text;
            
        }
    }
}