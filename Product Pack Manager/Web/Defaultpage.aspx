<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Defaultpage.aspx.cs" Inherits="Product_Pack_Manager.Web.Defaultpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/Main.css"/>
    <script type="text/javascript" src="Script/DeleteButton.js<% %>"></script>


    
</head>
<body>
    <div id="mynetwork"></div>
    <div id="Midzone">
        <form id="form1" runat="server">
            
            <asp:DropDownList ID="Dropdownpacklist" runat="server"></asp:DropDownList>
            <br/>
            <asp:Button CssClass="button" ID="Displaypackbutton" runat="server" Text="Display the pack" /> <br />
            <p>selected element: </p><br />
            <asp:DropDownList ID="selectedelement" runat="server"></asp:DropDownList>
            <p>Adding element</p><br />

            <asp:RadioButtonList CssClass="Radioelementtype" ID="Radio1" runat="server" GroupName="Addserv1" onchange="Prestationselect()">
                <asp:ListItem onclick="Prestationselect()">Prestations</asp:ListItem>
                <asp:ListItem>Articles</asp:ListItem>
                <asp:ListItem>Hardware</asp:ListItem>
            </asp:RadioButtonList>

            <asp:DropDownList CssClass="dropdownghost" ID="AddingelementPrestation" runat="server"></asp:DropDownList>
            <asp:DropDownList CssClass="dropdownghost" ID="AddingelementArticles" runat="server"></asp:DropDownList>
            <asp:DropDownList CssClass="dropdownghost" ID="AddingelementHardware" runat="server"></asp:DropDownList> 
            <br/>
            
            <div class="checkboxes">
                <p>More rules</p>
                <input type="checkbox" class="checkbox arrow-button" id="arrowButton" onclick="hiderule()">
                <label for="arrowButton" class="label arrow-button-label">    </label>
            </div>
            <div id="Morerulediv">
                <p>Max and Minumum element</p>
                <asp:TextBox ID="Minelement" runat="server" placeholder="Minimum"></asp:TextBox><br />
                <asp:TextBox ID="Maxelement" runat="server" placeholder="Maximum"></asp:TextBox>
                <asp:CheckBox ID="Usechecker" runat="server" />
                <asp:CheckBox ID="Usepriority" runat="server" />
                <asp:TextBox ID="PriorityLevel" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator" ControlToValidate="PriorityLevel" ValidationExpression="^\d+$" ErrorMessage="Please Enter Numbers Only" Display="Dynamic" SetFocusOnError="True" />
                <asp:CheckBox ID="IgniorineOnInvoice" runat="server" />
                <asp:CheckBox ID="test" runat="server" />
                <asp:CheckBox ID="DisplaypriceOnInvoice" runat="server" />
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

            </div>

            <div id="add_modificateur">
                <asp:CheckBox ID="alwayscreate" runat="server"/>
                <div class="tooltip">Always create
                    <span class="tooltiptext">If not checked it will count as reuse if existing</span>
                </div>
            
            </div>



            <br /><asp:Button CssClass="button" ID="addelement" runat="server" Text="Add" /><br />
            <!--<p>Replace element</p><br />
            <asp:DropDownList ID="Modifylist" runat="server"></asp:DropDownList><asp:CheckBox ID="alwayscreatemodify" runat="server"/>
            <div class="tooltip">Always create
                <span class="tooltiptext">If not checked it will count as reuse if existing</span>
            </div><br/>-->
            <asp:Button CssClass="button" ID="Modify" runat="server" Text="Modify" /><br />
            <!--<p>Change the total price</p> <br />
            <asp:TextBox ID="pricebox" runat="server" placeholder="New price"></asp:TextBox><br />
            <asp:Button ID="NewPrice" runat="server" Text="Change price" CssClass="button"/><br />  -->
            <p>Delete element from pack</p><br />
            <label for="myCheck">Delete:</label> 
            <input type="checkbox" id="deletecheck" onclick="hidebutton()"/>

            <asp:Button ID="buttondelete" CssClass="button" style="display:none; background-color: #ff0000; margin-left: 16%" runat="server" Text="Delete pack" />
            <br /><!--
            <p>Create a new pack</p><br />
            <asp:TextBox ID="newpacktext" placeholder="New packname" runat="server"></asp:TextBox><br />
            <asp:Button ID="newpackbutton" runat="server" Text="Add" CssClass="button"/>-->
        </form>
    </div>
</body>
</html>
