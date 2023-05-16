<%@ Page Title="View Aprovals PPVs" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="PPV_Projec.View" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv='X-UA-Compatible' content='IE=7' />
    <link rel='stylesheet' type='text/css' href='Styles/StaticHeader.css' />
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

    <style type="text/css">
        body {
            font-family: Arial;
            font-size: 10pt;
            margin: 0;
            padding: 0;
            padding-left: 63px;
            float: left;
            padding-top: 5em;
        }

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

        .FixedHeader {
            
            top: expression(this.parentNode.parentNode.parentNode.scrollTop-1);
        }
    </style>


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


    <script type="text/javascript">
        $(function () {
            $('[id*=btnExport]').on('click', function () {
                ExportToExcel('GV_Approval');
                location.reload();
            });
        });
        function ExportToExcel(Id) {
            var tab_text = "<table border='2px'><tr>";
            var textRange;
            var j = 0;
            tab = document.getElementById(Id);
            var headerRow = $('[id*=GV_Approval] tr:first');
            tab_text += headerRow.html() + '</tr><tr>';
            var rows = $('[id*=GV_Approval] tr:not(:has(th))');
            for (j = 0; j < rows.length; j++) {
                if ($(rows[j]).css('display') != 'none') {
                    tab_text = tab_text + rows[j].innerHTML + "</tr>";
                }
            }
            tab_text = tab_text + "</table>";
            tab_text = tab_text.replace(/<A[^>]*>|<\/A>/g, ""); //remove if u want links in your table
            tab_text = tab_text.replace(/<img[^>]*>/gi, ""); // remove if u want images in your table
            tab_text = tab_text.replace(/<input[^>]*>|<\/input>/gi, ""); // reomves input params
            var ua = window.navigator.userAgent;
            var msie = ua.indexOf("MSIE ");
            if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./))      // If Internet Explorer
            {
                txtArea1.document.open("txt/html", "replace");
                txtArea1.document.write(tab_text);
                txtArea1.document.close();
                txtArea1.focus();
                sa = txtArea1.document.execCommand("SaveAs", true, "ReportPPV_" + Date.now + ".xls");
            }
            else {                 //other browser not tested on IE 11
                sa = window.open('data:application/vnd.ms-excel,' + encodeURIComponent(tab_text));
            }
            return (sa);
        }
    </script>

    <script src="Scripts/FreeGrid.js" type="text/javascript"></script>
    
   


    <h1>Approved PPV</h1>

    <asp:HiddenField ID="Hidden1" runat="server" />

    <h3>Filter</h3>
    <asp:DropDownList ID="ddl_TypeDate" runat="server" OnSelectedIndexChanged="ddl_TypeDate_SelectedIndexChanged" OnClientClick="return false;" AutoPostBack="true">
        <asp:ListItem Value="1" Text="PPV Date"></asp:ListItem>
        <asp:ListItem Value="2" Text="First Aproval"></asp:ListItem>
        <asp:ListItem Value="3" Text="Last Aproval"></asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <asp:TextBox ID="date1" runat="server" TextMode="Date" OnTextChanged="date1_TextChanged" OnClientClick="return false;" AutoPostBack="true"></asp:TextBox>
    TO
    <asp:TextBox ID="date2" runat="server" TextMode="Date" OnTextChanged="date2_TextChanged" OnClientClick="return false;" AutoPostBack="true"></asp:TextBox>

    <input runat="server" type="submit" name="btnExport" value="Export" id="btnExport" class="orangeButton" onclick="javascript:return false;" />

    <asp:DropDownList ID="ddl_SO" runat="server" OnClientClick="return false;" OnSelectedIndexChanged="ddl_SO_SelectedIndexChanged" Visible="false" AutoPostBack="true">
        <asp:ListItem Value="1" Text="No PPVs SO Req"></asp:ListItem>
        <asp:ListItem Value="2" Text="PPVs SO Req"></asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />

    <form >

        <%--<asp:UpdatePanel runat="server" ID="updatepnl">
        <ContentTemplate>--%>
        <asp:GridView ID="GV_Approval" runat="server" Width="100%" AutoGenerateColumns="false" OnDataBound="GV_Approval_DataBound" OnRowDataBound="GV_Approval_RowDataBound"
            ShowHeaderWhenEmpty="True" OnSelectedIndexChanged="GV_Approval_SelectedIndexChanged" ShowFooter="true" OnPageIndexChanging="GV_Approval_PageIndexChanging"
            OnPreRender="GV_Approval_PreRender" HeaderStyle-CssClass="FixedHeader">

            <Columns>
                <asp:CommandField SelectText="Detail" ShowSelectButton="True" HeaderText="Details" />
            </Columns>
            <Columns>

                <asp:BoundField DataField="id_ppv" HeaderText="id" />

                <asp:BoundField DataField="Buyer" HeaderText="Buyer" />

                <asp:BoundField DataField="wo" HeaderText="WO" />
                <asp:BoundField DataField="po" HeaderText="PO" />
                <asp:BoundField DataField="pn" HeaderText="Part N#" />
                <asp:BoundField DataField="clientID" HeaderText="Client" />
                <asp:BoundField DataField="vendorID" HeaderText="Vendor" />
                <asp:BoundField DataField="av_price" HeaderText="AV Price" />
                <asp:BoundField DataField="new_price" HeaderText="New Price" />
                <asp:BoundField DataField="qty" HeaderText="QTY" />

                <asp:BoundField DataField="salesOrder" HeaderText="Sales Order" />
                <asp:BoundField DataField="salesOrder_num" HeaderText="Sales Order #" />
                <asp:BoundField DataField="total_increase" HeaderText="Total PPV" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right" />
                <%--<asp:BoundField DataField="current_total" HeaderText="Current Total" />
                    <asp:BoundField DataField="new_total" HeaderText="New Total" />--%>

                <asp:BoundField DataField="elaborate" HeaderText="Elaborate" />
                <asp:BoundField DataField="times" HeaderText="Changes" />
                <asp:BoundField DataField="leadtime" HeaderText="LT" />
                <asp:BoundField DataField="mfg" HeaderText="Mfgr ID" />
                <asp:BoundField DataField="mfg_desc" HeaderText="Mfgr Part No." />

                <asp:BoundField DataField="Approved by" HeaderText="Approved By" />

                <asp:BoundField DataField="date_ppv" HeaderText="PPV Creation Date" />
                <asp:BoundField DataField="first_date" HeaderText="Leader Approval" />
                <asp:BoundField DataField="first_approval" HeaderText="Approved" />
                <asp:BoundField DataField="explanation" HeaderText="Explanation" />

            </Columns>
        </asp:GridView>
        <script type="text/JavaScript">
            window.onload = function () {
                this.FreezeGrid("<%=GV_Approval.ClientID %>");

            }
        </script>
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
    <br />
    <%--<asp:Button ID="btnExport" CssClass="orangeButton" runat="server" BackColor="#FFCC66" Height="42px" Text="Export" Width="100px" CommandName="btnExport"  />--%>
    <%--<input runat="server" type="submit" name="btnExport" value="Export" id="btnExport" class="orangeButton" onclick="javascript:return false;" />--%>

    <br />
    <br />
</asp:Content>
