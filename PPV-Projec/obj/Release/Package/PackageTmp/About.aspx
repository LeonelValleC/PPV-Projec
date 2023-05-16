<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="PPV_Projec.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">



    <style type="text/css">
        /* body {
            font-family: Arial;
            font-size: 10pt;
            margin: 0;
            padding: 0;
            padding-left: 63px;
            float: left;
            padding-top: 5em;
        }*/

        table {
            border: 1px solid #ccc;
        }

            table th {
                background-color: #F7F7F7;
                color: #333;
                font-weight: bold;
            }

            table th, table td {
                padding: 5px;
                border-color: #ccc;
            }

        input {
            width: 100%;
        }

        .orangeButton {
            box-shadow: inset 0px 1px 0px 0px #fff6af;
            background: linear-gradient(to bottom, #ffcc66 5%, #d18717 100%);
            background-color: #ffcc66;
            border-radius: 6px;
            border: 1px solid #ffaa22;
            display: inline-block;
            cursor: pointer;
            color: #333333;
            font-family: Arial;
            font-size: 15px;
            font-weight: bold;
            padding: 6px 24px;
            text-decoration: none;
            text-shadow: 0px 1px 0px #ffee66;
            float: right;
            height: 42px;
            width: 100px;
            margin-bottom: 30px;
        }

            .orangeButton:disabled {
                background-color: #808080;
                color: black;
            }

            .orangeButton:hover {
                background: linear-gradient(to bottom, #d18717 5%, #ffcc66 100%);
                background-color: #d18717;
            }

            .orangeButton:active {
                position: relative;
                top: 1px;
            }
    </style>

    <h1>Approval Queue</h1>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="Scripts/quicksearch.js"></script>
    <script type="text/javascript">
        $(function () {
            $('.search_textbox').each(function (i) {
                $(this).quicksearch("[id*=GV_Approval] tr:not(:has(th))", {
                    'testQuery': function (query, txt, row) {
                        return $(row).children(":eq(" + i + ")").text().toLowerCase().indexOf(query[0].toLowerCase()) != -1;
                    }
                });
            });
        });
    </script>

    <asp:HiddenField ID="Hidden1" runat="server" />



    <asp:UpdatePanel runat="server" ID="updatepnl">
        <ContentTemplate>

            <asp:GridView ID="GV_Approval" runat="server" Width="100%" AutoGenerateColumns="false" OnDataBound="GV_Approval_DataBound" OnRowDataBound="GV_Approval_RowDataBound" CssClass="table table-striped table-bordered table-hover"
                HorizontalAlign="Center" ShowHeaderWhenEmpty="True" OnSelectedIndexChanged="GV_Approval_SelectedIndexChanged" ShowFooter="true">
                <Columns>
                    <asp:CommandField SelectText="Detail" ShowSelectButton="True" HeaderText="Details" />
                </Columns>

                <Columns>

                    <asp:BoundField DataField="id_ppv" HeaderText="id" />

                    <asp:BoundField DataField="Buyer" HeaderText="Buyer" />

                    <asp:BoundField DataField="po" HeaderText="PO" />
                    <asp:BoundField DataField="Part N#" HeaderText="Part N#" />
                    <asp:BoundField DataField="Client" HeaderText="Client" />
                    <asp:BoundField DataField="Vendor" HeaderText="Vendor" />
                    <asp:BoundField DataField="AV Price" HeaderText="AV Price" />
                    <asp:BoundField DataField="New Price" HeaderText="New Price" />
                    <asp:BoundField DataField="qty" HeaderText="QTY" />

                    <asp:BoundField DataField="Total PPV" HeaderText="Total PPV" />
                    <asp:BoundField DataField="Current Total" HeaderText="Current Total" />
                    <asp:BoundField DataField="New Total" HeaderText="New Total" />
                    <asp:BoundField DataField="Leader Approval" HeaderText="Leader Approval" />
                </Columns>

            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
