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
            //take all the pack (formated in Dropdownpack) and put it in Dropdownpacklist
            if (!IsPostBack) 
            {
                Sql sql = new Sql();
                List<Dropdownpack> Packlist = sql.Packlistandid();
                Dropdownpacklist.DataSource = Packlist;
                Dropdownpacklist.DataValueField = "Id";
                Dropdownpacklist.DataTextField = "IdandName";  
                Dropdownpacklist.DataBind();
                sql.end();

            }
        }
        //adding element in dropdown 
        public void elementdropdown(DropDownList List, List<Elementfrompack> Selectedpackelement) 
        {
            List.DataSource = Selectedpackelement;
            List.DataValueField = "Elementid";
            List.DataTextField = "Elementname";
            List.DataBind();
        }
        //take the selected pack and update the nodeandlink.js file  
        protected void Displaypackbutton_Click(object sender, EventArgs e)
        {
            //take the pack and create the js file with all the nodes
            string Selectedpack = Dropdownpacklist.Text;
            writer writer = new writer();
            writer.writerall(Selectedpack);
            //dropdown part
            Sql sql = new Sql();
            //request all element from selected pack and put it in the dropdownlist
            List<Elementfrompack> Selectedpackelement = sql.selectedelement(Dropdownpacklist.Text);
            elementdropdown(selectedelement, Selectedpackelement);
            elementdropdown(ElementFrom, Selectedpackelement);
            elementdropdown(ElementTo, Selectedpackelement);
            //request all link from the selected pack and put it in Existinglink
            List<Linkclassdropdown> existinglink = sql.requestedgedropdown(Dropdownpacklist.Text);
            Existinglink.DataSource = existinglink;
            Existinglink.DataValueField = "Id";
            Existinglink.DataTextField = "Label";
            Existinglink.DataBind();
            sql.end();


        }
        //to reload js file on every postback
        public int Randomnumber() 
        {
            System.Random random = new System.Random();
            return (random.Next(1, 999));
        }
        //add element when button pressed
        protected void addelement_Click(object sender, EventArgs e)
        {
            string Selectedpack = Dropdownpacklist.Text;
            string Elementtype = Radio1.SelectedValue;
            string Elementid;
            //take the good id by looking witch radio is checked
            if (Elementtype == "1")
            {
                Elementid = AddingelementPrestation.Text;
            }
            else if (Elementtype == "2")
            {
                Elementid = AddingelementArticles.Text;
            }
            else
            {
                Elementid = AddingelementHardware.Text;
            }
            string Min = Minelement.Text;
            string Max = Maxelement.Text;
            bool Useexisting = Use_Existing.Checked;
            bool Usechecker = Use_checker.Checked;
            bool Usepriority = Use_priority.Checked;
            string Prioritylevel = PriorityLevel.Text;
            bool Ignoreonvoice = IgnoreOnInvoice.Checked;
            bool Displayitemoninvoice = DisplayItemOnInvoice.Checked;
            bool Displaypriceoninvoice = DisplayPriceOnInvoice.Checked;
            bool Defineofficialprice = DefineOfficialPrice.Checked;
            string Dependon = DependOn.Text;
            string SelectionId = Selectionid.Text;
            Sql sql = new Sql();
            //sql command to add
            string error = sql.addelement(Selectedpack, SelectionId, Elementtype, Elementid, Min, Max, Useexisting, Usechecker, Usepriority, Prioritylevel, Ignoreonvoice, Displayitemoninvoice, Displaypriceoninvoice, Defineofficialprice, Dependon);
            sql.end();
            if (error != "") 
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alerte", "alert('" + error + "')", true);
            }
        }
        //modify element when button pressed
        protected void Modify_Click(object sender, EventArgs e)
        {
            string Selectedpack = Dropdownpacklist.Text;
            string Elementid = selectedelement.Text;
            string Min = Minelement.Text;
            string Max = Maxelement.Text;
            bool Useexisting = Use_Existing.Checked;
            bool Usechecker = Use_checker.Checked;
            bool Usepriority = Use_priority.Checked;
            string Prioritylevel = PriorityLevel.Text;
            bool Ignoreonvoice = IgnoreOnInvoice.Checked;
            bool Displayitemoninvoice = DisplayItemOnInvoice.Checked;
            bool Displaypriceoninvoice = DisplayPriceOnInvoice.Checked;
            bool Defineofficialprice = DefineOfficialPrice.Checked;
            string Dependon = DependOn.Text;
            string SelectionId = Selectionid.Text;

            //send the sql querry
            Sql sql = new Sql();
            string error = sql.modifyelement(Selectedpack, SelectionId, Elementid, Min, Max, Useexisting, Usechecker, Usepriority, Prioritylevel, Ignoreonvoice, Displayitemoninvoice, Displaypriceoninvoice, Defineofficialprice, Dependon);
            sql.end();

            if (error != "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alerte", "alert('" + error + "')", true);
            }
        }
        //delete an element when pressed
        protected void buttondelete_Click(object sender, EventArgs e)
        {
            string Selectedpack = Dropdownpacklist.Text;
            string Elementid = selectedelement.Text;            //POURQUOI SA ME PREND LE PREMIER ET PAS L'ID DU SELECTIONNé
            Sql sql = new Sql();
            string error = sql.deleteelement(Selectedpack, Elementid);
            sql.end();
            if (error != "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alerte", "alert('" + error + "')", true);
            }
        }

        protected void Addlink_Click(object sender, EventArgs e)
        {
            string Selectedpack = Dropdownpacklist.Text;
            string from = ElementFrom.Text;
            string to = ElementTo.Text;
            string condition = LinkCondition.Text;
            string actiontrue = ActionWhenTrue.SelectedValue;
            string actionfalse = ActionWhenFalse.SelectedValue;
            Sql sql = new Sql();
            string error = sql.linkadd(Selectedpack, from, to, condition, actiontrue, actionfalse);
            sql.end();
            if (error != "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alerte", "alert('" + error + "')", true);
            }

        }

        protected void Modifylink_Click(object sender, EventArgs e)
        {
            string Selectedpack = Dropdownpacklist.Text;
            string selectedlink = Existinglink.Text;
            string condition = LinkCondition.Text;
            string actiontrue = ActionWhenTrue.SelectedValue;
            string actionfalse = ActionWhenFalse.SelectedValue;
            Sql sql = new Sql();
            string error = sql.linkmodify(selectedlink, Selectedpack, condition, actiontrue, actionfalse);
            sql.end();
            if (error != "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alerte", "alert('" + error + "')", true);
            }
        }

        protected void deltelink_Click(object sender, EventArgs e)
        {
            string Selectedpack = Dropdownpacklist.Text;
            string selectedlink = Existinglink.Text;
            Sql sql = new Sql();
            string error = sql.linkdelete(selectedlink, Selectedpack);
            sql.end();
            if (error != "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alerte", "alert('" + error + "')", true);
            }
        }
    }
}