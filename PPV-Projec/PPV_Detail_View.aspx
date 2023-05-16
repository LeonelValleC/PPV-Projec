<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PPV_Detail_View.aspx.cs" Inherits="PPV_Projec.PPV_Detail_View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <link href="Content/css/select2.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.7.min.js"></script>
    <script src="Scripts/select2.min.js"></script>

    <script type="text/javascript">
        $(function () {
            $("#<%=ddl_client.ClientID%>").select2();
            $("#<%=ddl_vendor.ClientID%>").select2();
            $("#<%=ddl_Mfg.ClientID%>").select2();
        })

        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to save data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }

        function confirmation() {
            return confirm("Are you sure you want to modify this PPV?");
        }

    </script>

    <br />
    <br />
    <h1>PPV Detail</h1>
    <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" BestFitPage="True" />--%>

    <asp:Panel runat="server" ID="Styles">
        <style type="text/css">
            @import "lesshat";

            .clearfix() {
                zoom: 1;
                &:before, &:after

            {
                content: "";
                display: block;
            }

            &:after {
                clear: both;
            }

            }

            .col() {
                padding-right: 10px;
                float: left;
                &:last-of-type

            {
                padding-right: 0;
            }

            }

            .transition(@speed, @easing) {
                transition: all @speed @easing;
            }

            //VARIABLES

            @white: #fff;
            @grey-lightest: #f9f9f9;
            @grey-light: #e3e3e3;
            @grey: #e5e5e5;
            @grey-dark: #b9b9b9;

            @purple: #c68eaa;
            @green: #7ed321;
            @emerald: #04BDBD;
            @blue: #04AEC5;
            @blue-dark: #0F6CC9;
            @color-primary: @green;
            @color-primary-strong: darken(saturate(@color-primary, 5%), 10%);

            @br: 3px;

            @fast: 0.35s;

            @ease: ease-in-out;

            // GENERAL

            * {
                &, &:before, &:after

            {
                box-sizing: border-box;
            }

            }

            body {
                padding: 1em;
                font-family: 'Open Sans', 'Helvetica Neue', Helvetica, Arial, sans-serif;
                font-size: 15px;
                // font-size: 1vw;
                color: @grey-dark;
                background-color: @grey-light;
            }

            // TYPOGRAPHY

            h4 {
                color: @color-primary;
            }

            // FORM

            input {
                width: -webkit-fill-available;
                width: 100%;
                padding: 1em;
                line-height: 1.4;
                background-color: @grey-lightest;
                border: 1px solid @grey;
                border-radius: 3px;
                .transition(@fast, @ease);
                &:focus

            {
                width: -webkit-fill-available;
                outline: 0;
                border-color: @color-primary-strong;
                & + .input-icon

            {
                i

            {
                color: @color-primary;
            }

            &:after {
                border-right-color: @color-primary;
            }

            }
            }

            &[type="radio"] {
                display: none;
                & + label

            {
                &:extend(input);
                display: inline-block;
                width: 50%;
                text-align: center;
                float: left;
                border-radius: 0;
                &:first-of-type

            {
                border-top-left-radius: @br;
                border-bottom-left-radius: @br;
            }

            &:last-of-type {
                border-top-right-radius: @br;
                border-bottom-right-radius: @br;
            }

            i {
                padding-right: 0.4em;
            }

            }

            &:checked + label {
                background-color: @color-primary;
                color: @white;
                border-color: @color-primary-strong;
            }

            }

            &[type="checkbox"] {
                display: none;
                & + label

            {
                position: relative;
                display: block;
                padding-left: 1.6em;
                &:before

            {
                &:extend(input);
                position: absolute;
                top: 0.2em;
                left: 0;
                display: block;
                width: 1em;
                height: 1em;
                padding: 0;
                content: "";
            }

            &:after {
                position: absolute;
                top: 0.45em;
                left: 0.2em;
                font-size: 0.8em;
                color: @white;
                opacity: 0;
                font-family: FontAwesome;
                content: "\f00c";
            }

            }
            }

            &:checked + label {
                &:before

            {
                &:extend(input[type="radio"]:checked + label);
            }

            &:after {
                opacity: 1;
            }

            }
            }

            select {
                &:extend(input[type="radio"] + label);
                height: 3.4em;
                line-height: 2;
                &:first-of-type

            {
                border-top-left-radius: @br;
                border-bottom-left-radius: @br;
            }

            &:last-of-type {
                border-top-right-radius: @br;
                border-bottom-right-radius: @br;
            }

            &:focus, &:active {
                outline: 0;
                &:extend(input[type="radio"]:checked + label);
            }

            option {
                &:extend(input);
                background-color: @color-primary;
                color: @white;
            }

            }

            .input-group {
                margin-bottom: 1em;
                display: block;
                .clearfix();
            }

            .input-group-icon {
                position: relative;
                input

            {
                padding-left: 4.4em;
            }

            .input-icon {
                position: absolute;
                top: 0;
                left: 0;
                width: 3.4em;
                height: 3.4em;
                line-height: 3.4em;
                text-align: center;
                pointer-events: none;
                &:after

            {
                position: absolute;
                top: 0.6em;
                bottom: 0.6em;
                left: 3.4em;
                /*display: block;*/
                display: inherit;
                border-right: 1px solid @grey;
                content: "";
                .transition(@fast, @ease);
            }

            i {
                .transition(@fast, @ease);
            }

            }
            }


            .container1 {
                max-width: 55em;
                padding: 0em 2em 2em 3em;
                /*margin: 0em auto;*/
                margin: 4em 0em 0em 15%;
                background-color: @white;
                border-radius: @br * 1.4;
                box-shadow: 0px 3px 10px -2px rgba(0,0,0,0.2);
                padding-top: 25px;
            }

            .row {
                .clearfix();
            }

            .col-half {
                .col();
                width: 100% / 2;
            }

            .col-third {
                .col();
                width: 100% / 3;
            }

            @media only screen and (max-width: 540px) {
                .col-half {
                    width: 100%;
                    padding-right: 0;
                }
            }

            .btn-style {
                float: right;
            }

            input[type="checkbox"] {
                width: 30px;
            }

            input[type="radio"] {
                width: 30px;
            }
        </style>

    </asp:Panel>


    <div class="container1">
        <form id="form1" method="post" autocomplete="off">
            <div class="row">
                <h3>PPV Information</h3>
                <div class="input-group input-group-icon">
                    <asp:Label Text="Work Order:" runat="server" />
                    <input runat="server" type="text" placeholder="Work Order" id="txt_WO" name="txt_WO" />
                    <asp:Label Text="PO:" runat="server" />
                    <input runat="server" type="text" placeholder="PO" id="txt_PO" name="txt_PO" />
                    <div class="input-icon"><i class="fa fa-user"></i></div>
                </div>
                <div class="input-group input-group-icon">
                    <asp:Label Text="Part #:" runat="server" />
                    <%-- <asp:DropDownList ID="ddl_pn" runat="server" CssClass="ddl-style" AutoPostBack="true" OnSelectedIndexChanged="ddl_pn_SelectedIndexChanged" AppendDataBoundItems="true">
                    </asp:DropDownList>--%>
                    <ajaxToolkit:ComboBox ID="ddl_pn" runat="server" AutoPostBack="True" DropDownStyle="Simple" CssClass="WindowsStyle" OnSelectedIndexChanged="ddl_pn_SelectedIndexChanged">
                    </ajaxToolkit:ComboBox>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PPVdbConnectionString %>" SelectCommand="SELECT [id_pn], [pn], [pnDesc] FROM [PN]"></asp:SqlDataSource>

                    <asp:Label Text="Part # Description:" runat="server" />
                    <input runat="server" type="text" placeholder="Part# Description" id="txt_pndesc" name="txt_pndesc" />
                    <div class="input-icon"><i class="fa fa-envelope"></i></div>
                </div>
                <div class="input-group input-group-icon">
                    <asp:Label Text="Vendor:" runat="server" />
                    <%--<input runat="server" type="text" placeholder="Vend#" id="txt_Vendor" name="txt_Vendor" />--%>
                    <asp:DropDownList ID="ddl_vendor" runat="server" CssClass="ddl-style" AutoPostBack="true" OnSelectedIndexChanged="ddl_vendor_SelectedIndexChanged">
                        <asp:ListItem Value="" Text="Part N#">Select</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label Text="VendorID:" runat="server" />
                    <input runat="server" type="text" placeholder="Vendor" id="txt_Vendir" name="txt_Vendir" />
                    <div class="input-icon"><i class="fa fa-envelope"></i></div>
                </div>
                <div class="input-group input-group-icon">
                    <asp:Label Text="ClientID:" runat="server" />
                    <asp:DropDownList ID="ddl_client" runat="server" CssClass="ddl-style" AutoPostBack="true" OnSelectedIndexChanged="ddl_client_SelectedIndexChanged">
                        <asp:ListItem Text="Select Client"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label Text="Client:" runat="server" />
                    <input runat="server" type="text" placeholder="Client" id="txt_Client" name="txt_Client" />
                    <div class="input-icon"><i class="fa fa-key"></i></div>
                </div>



                <h4>PPV Reason (must be define)</h4>
                <asp:RadioButtonList ID="RB_PPVReason" name="RB_PPVReason" runat="server" RepeatDirection="Horizontal" CellSpacing="20" CellPadding="20">
                    <asp:ListItem Text="Price Change" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Combined Requirements" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Quantity Change" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Alternate Source" Value="4"></asp:ListItem>
                    <asp:ListItem Text="Broker Purchase" Value="5"></asp:ListItem>
                    <asp:ListItem Text="Other (Specify in 'Explanation')" Value="6"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="row">
                <div class="col-half">
                    <div class="input-group">
                        <div class="col-third">
                            <h4>1 Time or Permanent Changes</h4>
                            <asp:RadioButtonList ID="Rb_times" name="Rb_times" runat="server" RepeatDirection="Vertical" CellSpacing="30" CellPadding="30">
                                <asp:ListItem Text="One time purchase" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Change AV" Value="0"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div class="col-third">
                            <h4>Any other change in ROI is needed?</h4>
                            <asp:CheckBoxList ID="cbl_changed" name="cbl_changed" runat="server" CellSpacing="30" CellPadding="30" RepeatDirection="Horizontal" Width="100%" CssClass="cb-style">
                                <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                            </asp:CheckBoxList>

                            <asp:Label Text="If yes, Please elaborate:" runat="server" />
                            <input runat="server" type="text" placeholder="If yes, Please elaborate" id="txt_Eraborate" name="txt_Eraborate" />

                        </div>
                        <h4>Sales Order where PPV is retrieve</h4>
                        <%--<label>Any Sales Order?</label>--%>
                        <asp:RadioButtonList ID="rb_salesOrder" name="rb_salesOrder" runat="server" CellSpacing="30" CellPadding="30" RepeatDirection="Horizontal" Width="100%" CssClass="cb-style">
                            <asp:ListItem Text="No" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                        </asp:RadioButtonList>


                        <asp:Label Text="Sales Order:" runat="server" />
                        <input runat="server" type="text" placeholder="Sales Order:" id="txt_salesOrder" name="txt_Eraborate" />

                    </div>
                </div>
                <div class="col-half">
                    <h4>Sourcing Information</h4>
                    <div class="input-group input-group-icon">
                        <asp:Label Text="MFGR:" runat="server" />
                        <%--<input runat="server" type="text" placeholder="Vend#" id="txt_Vendor" name="txt_Vendor" />--%>

                        <asp:DropDownList ID="ddl_Mfg" runat="server" CssClass="ddl-style" AutoPostBack="true" OnSelectedIndexChanged="ddl_Mfg_SelectedIndexChanged">
                            <asp:ListItem Text="Select MFGR"></asp:ListItem>
                        </asp:DropDownList>

                        <asp:Label Text="MFGR:" runat="server" />
                        <input runat="server" id="txt_MfgrPN" name="txt_MfgrPN" type="text" placeholder="MFGR Part No." />
                        <div class="input-icon"><i class="fa fa-envelope"></i></div>
                    </div>
                    <%--<div class="input-group input-group-icon">
                        <asp:Label Text="MFGR Name:" runat="server" />
                        <input runat="server" id="txt_Mfgr" name="txt_Mfgr" type="text" placeholder="MFGR Name" />
                        <asp:Label Text="MFGR P/N:" runat="server" />
                        <input runat="server" id="txt_MfgrPN" name="txt_MfgrPN" type="text" placeholder="MFGR Part No." />
                        <div class="input-icon"><i class="fa fa-key"></i></div>
                    </div>--%>
                    <div class="input-group input-group-icon">
                        <asp:Label Text="Lead Time in Days:" runat="server" />
                        <input runat="server" id="txt_LeadTime" name="txt_LeadTime" type="text" placeholder="Lead Time in Days" />
                        <div class="input-icon"><i class="fa fa-user"></i></div>
                    </div>
                </div>
            </div>
            <div class="row">
                <h4>Payment Details</h4>
                <div class="input-group input-group-icon">
                    <asp:Label Text="Explanation:" runat="server" />
                    <textarea runat="server" id="txt_Explanation" name="txt_Explanation" placeholder="Explanantion" style="width: 100%; height: 75px;"></textarea>
                </div>

            </div>

            <div class="row">
                <h3>Resume</h3>
                <div class="col-third">
                    <asp:Label Text="Current Standard Cost:" runat="server" />
                    <input runat="server" type="text" placeholder="Current Standard Cost" id="txt_AvPrice" name="txt_AvPrice" />
                    <br />
                    <br />
                    <asp:Label Text="New Cost:" runat="server" />
                    <input runat="server" type="text" placeholder="New Cost" id="txt_NewPrice" name="txt_NewPrice" />
                    <br />
                    <br />
                    <asp:Label Text="Purchased Quantity:" runat="server" />
                    <input runat="server" type="text" placeholder="Purchased Quantity" id="txt_qty" name="txt_qty" />
                    <div class="input-icon"><i class="fa fa-user"></i></div>
                    <br />
                </div>
                <div class="input-group input-group-icon">
                    <asp:Label Text="Change:" runat="server" />
                    <input runat="server" type="text" placeholder="Change" id="txt_change" name="txt_change" />
                    <asp:Label Text="Change %:" runat="server" />
                    <input runat="server" type="text" placeholder="Change %" id="txt_chagePerc" name="txt_chagePerc" />
                    <div class="input-icon"><i class="fa fa-user"></i></div>
                </div>
                <div class="input-group input-group-icon">
                    <asp:Label Text="Current Total:" runat="server" />
                    <input runat="server" type="text" placeholder="Current Total" id="txt_currentTotal" name="txt_currentTotal" />
                    <asp:Label Text="New Total:" runat="server" />
                    <input runat="server" type="text" placeholder="New Total" id="txt_newTotal" name="txt_newTotal" />
                    <div class="input-icon"><i class="fa fa-user"></i></div>
                </div>
                <div class="input-group input-group-icon">
                    <asp:Label Text="Total PPV:" runat="server" />
                    <input runat="server" type="text" placeholder="Total PPV" id="txt_TotalIncrease" name="txt_TotalIncrease" />
                    <div class="input-icon"><i class="fa fa-user"></i></div>
                </div>
                <div class="input-group input-group-icon">
                    <asp:Label Text="Approval Note:" runat="server" />
                    <%--<input runat="server" type="text" placeholder="Note" id="txt_Note" name="txt_Note" style="width: 100%; height: 100px;" />--%>
                    <textarea runat="server" id="txt_Note" name="" cols="20" rows="2" placeholder="NOTES" style="width: 100%; height: 100px;"></textarea>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required note if decline this PPV*" Display="Dynamic" ControlToValidate="txt_Note" BorderColor="Red" ForeColor="Red" ValidateRequestMode="Disabled" Enabled="false"></asp:RequiredFieldValidator>
                    <div class="input-icon"><i class="fa fa-user"></i></div>
                </div>
            </div>

            <div class="row">
                <div class="input-group input-group-icon">
                    <asp:Button ID="btn_Submit" runat="server" Text="Reapproval" class="btn btn-lg btn-success " OnClick="btn_Submit_Click" OnClientClick="return confirmation();"  />
                    <%--<asp:Button ID="btn_Cancel" runat="server" Text="Void" class="btn btn-lg btn-danger btn-style " OnClick="btn_Cancel_Click" />--%>

                    <div class="input-icon"><i class="fa fa-key"></i></div>
                </div>

            </div>
        </form>
    </div>



</asp:Content>
