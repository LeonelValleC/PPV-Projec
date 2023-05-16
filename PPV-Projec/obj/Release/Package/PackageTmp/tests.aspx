<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="tests.aspx.cs" Inherits="PPV_Projec.tests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <link href="Content/css/select2.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.7.min.js"></script>
    <script src="Scripts/select2.min.js"></script>

    <script>
        $(function () {
            $("#<%=ddl_pn.ClientID%>").select2();
    })
    </script>

    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:DropDownList ID="ddl_pn" runat="server" CssClass="ddl-style" AutoPostBack="true" OnSelectedIndexChanged="ddl_pn_SelectedIndexChanged" DataTextField="clientID" DataValueField="id_client" AppendDataBoundItems="true">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PPVdbConnectionString %>" SelectCommand="SELECT [id_client], [clientID] FROM [Client]"></asp:SqlDataSource>
    <input runat="server" type="text" placeholder="Part# Description" id="txt_pndesc" name="txt_pndesc" />

    <br />
    <br />
    <br />

    <asp:DropDownList ID="ddl_vendor" runat="server" CssClass="ddl-style" AutoPostBack="true" OnSelectedIndexChanged="ddl_vendor_SelectedIndexChanged">
        <%--<asp:ListItem Value="" Text="Part N#">Select</asp:ListItem>--%>
    </asp:DropDownList>
    <input runat="server" type="text" placeholder="Vendor" id="txt_Vendir" name="txt_Vendir" />

    <br />
    <br />
    <br />

    <asp:DropDownList ID="ddl_client" runat="server" CssClass="ddl-style" AutoPostBack="true" OnSelectedIndexChanged="ddl_client_SelectedIndexChanged">
        <asp:ListItem Text="Select Color"></asp:ListItem>
    </asp:DropDownList>
    <input runat="server" type="text" placeholder="Client" id="txt_Client" name="txt_Client" />

</asp:Content>
