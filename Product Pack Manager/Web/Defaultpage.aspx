<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Defaultpage.aspx.cs" Inherits="Product_Pack_Manager.Web.Defaultpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/Main.css">
    <script type="text/javascript" src="Script/DeleteButton.js"></script>


    
</head>
<body>
    <div id="mynetwork"></div>
    <div id="leftzone">
        <form id="form1" runat="server">
            <asp:DropDownList ID="Dropdownpacklist" runat="server"></asp:DropDownList>
            <br/>
            <asp:Button CssClass="button" ID="Displaypackbutton" runat="server" Text="Display the pack" /> <br />
            <p>selected element: </p><br />
            <p>Adding element</p><br />
            <asp:DropDownList ID="Addingelement" runat="server"></asp:DropDownList> <asp:CheckBox ID="alwayscreate" runat="server"/>

            <div class="tooltip">Always create
                <span class="tooltiptext">If not checked it will count as reuse if existing</span>
            </div>



            <br /><asp:Button CssClass="button" ID="addelement" runat="server" Text="Add" /><br />
            <p>Replace element</p><br />
            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList><asp:CheckBox ID="alwayscreatemodify" runat="server"/>
            <div class="tooltip">Always create
                <span class="tooltiptext">If not checked it will count as reuse if existing</span>
            </div><br/>
            <asp:Button CssClass="button" ID="Modify" runat="server" Text="Modify" /><br />
            <p>Change the total price</p> <br />
            <asp:TextBox ID="pricebox" runat="server" placeholder="New price"></asp:TextBox><br />
            <asp:Button ID="Button1" runat="server" Text="Button" CssClass="button"/><br />  
            <p>Delete element from pack</p><br />
            <label for="myCheck">Delete:</label> 
            <input type="checkbox" id="deletecheck" onclick="hidebutton()">

            <asp:Button ID="buttondelete" CssClass="button" style="display:none; background-color: #ff0000; margin-left: 16%" runat="server" Text="Delete pack" />
            <br />
            <p>Create a new pack</p><br />
            <asp:TextBox ID="newpacktext" placeholder="New packname" runat="server"></asp:TextBox><br />
            <asp:Button ID="newpackbutton" runat="server" Text="Add" CssClass="button"/>
        </form>
    </div>
</body>
</html>
