<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="PPV_Projec.Test" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <br />
    <br />
    <br />

    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" HasToggleGroupTreeButton="False" HasToggleParameterPanelButton="False" ReportSourceID="CrystalReportSource1" ToolPanelView="None" Width="868px" />

    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="CrystalReport1.rpt">
        </Report>
    </CR:CrystalReportSource>
    



</asp:Content>
