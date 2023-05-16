<%@ Page Title="Inbox PPV" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inbox.aspx.cs" Inherits="PPV_Projec.Inbox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>PPV In Process </h1>
     <asp:GridView ID="GV_Approval" runat="server" Width="100%" OnRowDataBound="GV_Approval_RowDataBound" OnSelectedIndexChanged="GV_Approval_SelectedIndexChanged" CssClass="table table-striped table-bordered table-hover" EmptyDataText="No PPVs Pendings!">
        <Columns>
            <asp:CommandField SelectText="Detail" ShowSelectButton="True" HeaderText="Details" />
        </Columns>
    </asp:GridView>

</asp:Content>
