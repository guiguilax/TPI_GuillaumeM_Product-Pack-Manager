﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Defaultpage.aspx.cs" Inherits="Product_Pack_Manager.Web.Defaultpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://visjs.github.io/vis-network/standalone/umd/vis-network.min.js" type="text/javascript"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="css/Main.css"/>
    <link rel="stylesheet" href="css/Mynetwork.css"/>
    <script type="text/javascript" src="Script/Nodeandedge.js?r=<% Randomnumber(); %>"></script>
    <script type="text/javascript" src="Script/Hidescript.js"></script>
    <script type="text/javascript" src="Script/Visjsconfig.js"></script>
    <script> 
        function loader()
        {
            document.getElementById("loader").style.display = "block";
        }

    </script>
</head>
<body onload="starting()">
        <div id="mynetwork"></div>
    <form id="form1" runat="server">

            <!--<div id="loader" style="display: none">loading... </div>-->
            <div id="loader"class="loader" style="display: none"></div>
        
        
        
        <div id="Midzone"> 
            <h1>Element</h1>
            <asp:DropDownList ID="Dropdownpacklist" runat="server"></asp:DropDownList>
            <br/>
            <asp:Button CssClass="button" ID="Displaypackbutton" runat="server" Text="Display the pack" OnClick="Displaypackbutton_Click" OnClientClick="loader()"/> <br />
            <p>selected element: </p>
            <asp:DropDownList ID="selectedelement" runat="server"></asp:DropDownList>
            <p>Adding element</p>

            <asp:RadioButtonList CssClass="Radioelementtype" ID="Radio1" runat="server" GroupName="Addserv1" onchange="Prestationselect()">
                <asp:ListItem Value="1" Selected="True">Prestations</asp:ListItem>
                <asp:ListItem Value="2">Articles</asp:ListItem>
                <asp:ListItem Value="3">Hardware</asp:ListItem>
            </asp:RadioButtonList>

            <asp:DropDownList ID="AddingelementPrestation" runat="server" CssClass="dropdownghost" DataSourceID="Prestationdropdown" DataTextField="Nom" DataValueField="Id"></asp:DropDownList>
            <asp:SqlDataSource ID="Prestationdropdown" runat="server" ConnectionString="<%$ ConnectionStrings:vtxClientsConnectionString %>" SelectCommand="PackDefinition_ElementValue_Get" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter DefaultValue="1" Name="ElementId" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
    
            <asp:DropDownList ID="AddingelementArticles" runat="server" CssClass="dropdownghost" DataSourceID="Articledropdown" DataTextField="Nom" DataValueField="Id"></asp:DropDownList>
            <asp:SqlDataSource ID="Articledropdown" runat="server" ConnectionString="<%$ ConnectionStrings:vtxClientsConnectionString %>" SelectCommand="PackDefinition_ElementValue_Get" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter DefaultValue="2" Name="ElementId" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
   
            <asp:DropDownList ID="AddingelementHardware" runat="server" CssClass="dropdownghost" DataSourceID="Hardwaredropdown" DataTextField="Nom" DataValueField="Id" Width="530px"></asp:DropDownList> 

            <asp:SqlDataSource ID="Hardwaredropdown" runat="server" ConnectionString="<%$ ConnectionStrings:vtxClientsConnectionString %>" SelectCommand="PackDefinition_ElementValue_Get" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter DefaultValue="3" Name="ElementId" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>

            <br />
             
            <div class="checkboxes">
                <p>More rules</p>
                <input type="checkbox" class="checkbox arrow-button" id="arrowButton" onclick="hiderule()"/>
                <label for="arrowButton" class="label arrow-button-label">    </label>
            </div>
            <div id="Morerulediv">
                <p>Element categories</p>
                <asp:DropDownList ID="Selectionid" runat="server" DataSourceID="SectionId" DataTextField="Nom" DataValueField="Id"></asp:DropDownList>
                <asp:SqlDataSource ID="SectionId" runat="server" ConnectionString="<%$ ConnectionStrings:vtxClientsConnectionString %>" SelectCommand="select * from Pack_ElementCategories"></asp:SqlDataSource>
                <p>Max and Minumum element</p>
                <asp:TextBox ID="Minelement" runat="server" type="number" placeholder="Minimum"></asp:TextBox><br />
                <asp:TextBox ID="Maxelement" runat="server" type="number" placeholder="Maximum"></asp:TextBox><br />
                <label>Use Existing:</label><asp:CheckBox ID="Use_Existing" runat="server" /><br />
                <label>Use checker:</label><asp:CheckBox ID="Use_checker" runat="server" /><br />
                <label>Use priority:</label><asp:CheckBox ID="Use_priority" runat="server" /><br />
                <p>Priority level</p>
                <asp:TextBox ID="PriorityLevel" placeholder="Priority Level" runat="server" type="number" Text="0"></asp:TextBox><br />
                <label>Ignore On Invoice:</label><asp:CheckBox ID="IgnoreOnInvoice" runat="server" /><br />
                <label>Display Item On Invoice:</label> <asp:CheckBox ID="DisplayItemOnInvoice" runat="server" /><br />
                <label>Display Price On Invoice:</label><asp:CheckBox ID="DisplayPriceOnInvoice" runat="server" /><br />
                <label>Define Official Price:</label><asp:CheckBox ID="DefineOfficialPrice" runat="server" /><br />
                <asp:TextBox ID="DependOn" runat="server" placeholder="DependOn"></asp:TextBox>
            </div>

            <div id="add_modificateur">
                <asp:CheckBox ID="alwayscreate" runat="server"/>
                <div class="tooltip">Always create
                    <span class="tooltiptext">If not checked it will count as reuse if existing</span>
                </div>
            
            </div>



            <br /><asp:Button CssClass="button" ID="addelement" runat="server" Text="Add" OnClick="addelement_Click"/><br />
            <!--<p>Replace element</p><br />
            <asp:DropDownList ID="Modifylist" runat="server"></asp:DropDownList><asp:CheckBox ID="alwayscreatemodify" runat="server"/>
            <div class="tooltip">Always create
                <span class="tooltiptext">If not checked it will count as reuse if existing</span>
            </div><br/>-->
            <asp:Button CssClass="button" ID="Modify" runat="server" Text="Modify" OnClick="Modify_Click" /><br />
            <!--<p>Change the total price</p> <br />
            <asp:TextBox ID="pricebox" runat="server" placeholder="New price"></asp:TextBox><br />
            <asp:Button ID="NewPrice" runat="server" Text="Change price" CssClass="button"/><br />  -->
            <p>Delete element from pack</p>
            <label for="myCheck">Delete selected element:</label> 
            <input type="checkbox" id="deletecheck" onclick="hidebutton()"/>

            <asp:Button ID="buttondelete" CssClass="button" style="display:none; background-color: #ff0000; margin-left: 30%;" runat="server" Text="Delete from pack" OnClick="buttondelete_Click"/>
            <br /><!--
            <p>Create a new pack</p><br />
            <asp:TextBox ID="newpacktext" placeholder="New packname" runat="server"></asp:TextBox><br />
            <asp:Button ID="newpackbutton" runat="server" Text="Add" CssClass="button"/>-->
        
        </div>
        <button type="button" style="margin-left: 89%;" class="button" onclick="switchright()">Element/Link</button>
        <div id="rightzone">
            <h1>Link</h1>
            <p>Select a existing link</p>
            <asp:DropDownList ID="Existinglink" runat="server"></asp:DropDownList>
            <p>Element link From</p>
            <asp:DropDownList ID="ElementFrom" runat="server"></asp:DropDownList>
            <p>Element link To</p>
            <asp:DropDownList ID="ElementTo" runat="server"></asp:DropDownList><br />
            <p>Condition to evaluate format</p>
            <asp:TextBox ID="LinkCondition" runat="server" placeholder="Condition"></asp:TextBox>
            <p>If True</p>
            <asp:DropDownList ID="ActionWhenTrue" runat="server">
                <asp:ListItem>--ASK</asp:ListItem>
                <asp:ListItem>CREATE</asp:ListItem>
                <asp:ListItem>GETEXISTING</asp:ListItem>
                <asp:ListItem>CREATEORREUSE</asp:ListItem>
                <asp:ListItem>NEXTSTEP</asp:ListItem>
            </asp:DropDownList>
            <p>If False</p>
            <asp:DropDownList ID="ActionWhenFalse" runat="server">
                <asp:ListItem>--ASK</asp:ListItem>
                <asp:ListItem>CREATE</asp:ListItem>
                <asp:ListItem>GETEXISTING</asp:ListItem>
                <asp:ListItem>CREATEORREUSE</asp:ListItem>
                <asp:ListItem>NEXTSTEP</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button CssClass="button" ID="Addlink" runat="server" Text="Add" OnClick="Addlink_Click" /><br />
            <asp:Button CssClass="button" ID="Modifylink" runat="server" Text="Modify" OnClick="Modifylink_Click" /><br />
            <asp:Button CssClass="button" ID="deltelink" runat="server" Text="Delete " OnClick="deltelink_Click" /><br />

        </div>
    </form>
</body>


</html>
