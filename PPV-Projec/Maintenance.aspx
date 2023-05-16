<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Maintenance.aspx.cs" Inherits="PPV_Projec.Maintenance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <style>
        .Grid {
            background-color: #fff;
            margin: 5px 0 10px 0;
            border: solid 1px #808080;
            border-collapse: collapse;
            font-family: 'Times New Roman';
            color: #000000;
        }
            .Grid td {
                padding: 2px;
                border: solid 1px #363670;
            }
            .Grid th {
                padding: 10px 10px;
                color: #fff;
                background: #552525;
                border-left: solid 1px #525252;
                font-size: 1em;
            }
    </style>
   
     <div>
        <div>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button runat="server" ID="BtnUpload" OnClick="BtnUpload_OnClick" Text="Upload" />
            <asp:Button runat="server" ID="BtnloadtoDB" Text="Load" OnClick="BtnloadtoDB_Click" />
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="Gridview1" runat="server" AutoGenerateColumns="false" CssClass="Grid">
                        <Columns>
                            <asp:BoundField DataField="Number" HeaderText="Number"
                                ApplyFormatInEditMode="true" ShowHeader="true" NullDisplayText="Null" />
                            <asp:BoundField DataField="Name" HeaderText="Name"
                                ShowHeader="true" />
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>


</asp:Content>
