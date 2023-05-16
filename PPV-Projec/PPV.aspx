<%@ Page Title="PPV" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PPV.aspx.cs" Inherits="PPV_Projec.PPV" %>

<%@ Register Assembly="Syncfusion.EJ.Web" Namespace="Syncfusion.JavaScript.Web" TagPrefix="ej" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="Content/css/select2.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.7.min.js"></script>
    <script src="Scripts/select2.min.js"></script>

    <script>
        $(function () {
            $("#<%=ddl_client.ClientID%>").select2();
            $("#<%=ddl_vendor.ClientID%>").select2();
            $("#<%=ddl_Mfg.ClientID%>").select2();
        })

    </script>

    <script type="text/javascript">


        $(function () {
            $("[id*=btn_Submit]").click(function () {

                var txt_qtyJ = $("[id*=txt_qty]");
                var txt_NewPriceJ = $("[id*=txt_NewPrice]");
                var txt_AvPriceJ = $("[id*=txt_AvPrice]");
                if (txt_AvPriceJ.val() == "") {
                    //If the "Please Select" option is selected display error.
                    alert("Please Fill Av Price!");
                    return false;
                }
                else if (txt_NewPriceJ.val() == "") {
                    //If the "Please Select" option is selected display error.
                    alert("Please Fill New Price!");
                    return false;
                }
                else if (txt_qtyJ.val() == "") {
                    //If the "Please Select" option is selected display error.
                    alert("Please Fill Quantity!");
                    return false;
                }
                return true;
            });
        });

        $(function () {
            $("[id*=btn_Submit]").click(function () {
                console.log();
                //var ddl_pnJ = $("[id*=ddl_pn]");
                var ddl_pnJ = document.getElementById('<%=ddl_pn.ClientID%>');

                var ddl_clientrJ = $("[id*=ddl_client]");
                var ddl_vendorJ = $("[id*=ddl_vendor]");
                var ddl_MfgJ = $("[id*=ddl_Mfg]");

                if (ddl_MfgJ.val() == "") {
                    //If the "Please Select" option is selected display error.
                    alert("Please select a MFG!");
                    return false;
                }
                else if (ddl_vendorJ.val() == "") {
                    //If the "Please Select" option is selected display error.
                    alert("Please select a Vendor!");
                    return false;
                }
                else if (ddl_clientrJ.val() == "") {
                    //If the "Please Select" option is selected display error.
                    alert("Please select a Client!");
                    return false;
                }
                else if (ddl_pnJ.val() == "") {
                    //If the "Please Select" option is selected display error.
                    alert("Please select a Part N#!");
                    return false;
                }
                return true;
            });
        });

    </script>



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

        // VARIABLES

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

        .ddl-style {
            height: 25px;
        }
    </style>

    <style type="text/css">
        .WindowsStyle .ajax__combobox_inputcontainer .ajax__combobox_textboxcontainer input {
            /*margin: 0;*/
            border: solid 1px #444;
            border-right: 0px none;
            padding: 1px 0px 0px 5px;
            /*font-size: 16px;*/
            /*height: 26px;*/
            width: 257px;
            /*position: relative;
            margin-top: -11px;*/
        }

        .WindowsStyle .ajax__combobox_inputcontainer .ajax__combobox_buttoncontainer button {
            /*margin-left: -2px;
            border-bottom: solid 1px #444;
            border-top: solid 1px #444;
            height: 26px;
            width: 26px;
            margin-top: 3px;
            margin-top: -6px;
            background-color: white;*/
        }


        .WindowsStyle .ajax__combobox_itemlist {
            border-color: #444;
        }

        input[type="checkbox"] {
            width: 30px;
        }

        input[type="radio"] {
            width: 30px;
        }
    </style>



    <div class="container1">
        <form id="form1" method="post" autocomplete="off">

            <div class="row">
                <h3>PPV Information</h3>

                <div class="input-group input-group-icon">


                    <%-- <asp:TextBox ID="txt_pn" runat="server" CssClass="autosuggest"></asp:TextBox>
                    --%>

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddl_pn" EventName="SelectedIndexChanged" />
                        </Triggers>
                        <ContentTemplate>

                            <ajaxToolkit:ComboBox ID="ddl_pn" runat="server" AutoPostBack="True" DropDownStyle="DropDownList" CssClass="WindowsStyle" AutoCompleteMode="SuggestAppend" OnSelectedIndexChanged="ddl_pn_SelectedIndexChanged">
                                <asp:ListItem Value="-1" Text="Select Options"></asp:ListItem>
                            </ajaxToolkit:ComboBox>


                            <input runat="server" type="text" placeholder="Part# Description" id="txt_pndesc" name="txt_pndesc" style="bottom: 10px" />

                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="input-icon"><i class="fa fa-envelope"></i></div>
                </div>
                <div class="input-group input-group-icon">

                    <%--<input runat="server" type="text" placeholder="Vend#" id="txt_Vendor" name="txt_Vendor" />--%>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddl_vendor" EventName="SelectedIndexChanged" />
                        </Triggers>
                        <ContentTemplate>
                            <asp:DropDownList ID="ddl_vendor" runat="server" CssClass="ddl-style" AutoPostBack="true" OnSelectedIndexChanged="ddl_vendor_SelectedIndexChanged">
                                <asp:ListItem Value="-1" Text="Select Options">Select Options</asp:ListItem>
                            </asp:DropDownList>

                            <input runat="server" type="text" placeholder="Vendor" id="txt_Vendir" name="txt_Vendir" />

                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="input-icon"><i class="fa fa-envelope"></i></div>
                </div>
                <div class="input-group input-group-icon">
                    <%--<input runat="server" type="text" placeholder="Client ID" id="txt_ClientID" name="txt_ClientID" />--%>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddl_client" EventName="SelectedIndexChanged" />
                        </Triggers>
                        <ContentTemplate>
                            <asp:DropDownList ID="ddl_client" runat="server" CssClass="ddl-style" AutoPostBack="true" OnSelectedIndexChanged="ddl_client_SelectedIndexChanged">
                                <asp:ListItem Value="-1" Text="Select Options">Select Options</asp:ListItem>
                            </asp:DropDownList>
                            <input runat="server" type="text" placeholder="Client" id="txt_Client" name="txt_Client" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="input-icon"><i class="fa fa-key"></i></div>
                </div>

                <div class="input-group input-group-icon">
                    <input runat="server" type="text" placeholder="AV Price" id="txt_AvPrice" name="txt_AvPrice" />
                    <input runat="server" type="text" placeholder="New Price" id="txt_NewPrice" name="txt_NewPrice" />
                    <div class="input-icon"><i class="fa fa-user"></i></div>
                </div>
                <div class="input-group input-group-icon">
                    <input runat="server" type="text" placeholder="Quantity" id="txt_qty" name="txt_qty" />
                    <div class="input-icon"><i class="fa fa-key"></i></div>
                </div>
                <div class="input-group input-group-icon">
                    <input runat="server" type="text" placeholder="Work Order" id="txt_WO" name="txt_WO" />
                    <input runat="server" type="text" placeholder="PO" id="txt_PO" name="txt_PO" />
                    <div class="input-icon"><i class="fa fa-user"></i></div>
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
                        <div class="col-half">
                            <h4>1 Time or Permanent Changes</h4>
                            <asp:RadioButtonList ID="Rb_times" name="Rb_times" runat="server" CellSpacing="30" CellPadding="30" RepeatDirection="Horizontal">
                                <asp:ListItem Text="One time purchase" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Change AV" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div class="col-half">
                            <h4>Any other change in ROI is needed?</h4>
                            <asp:RadioButtonList ID="cbl_changed" name="cbl_changed" runat="server" CellSpacing="30" CellPadding="30" RepeatDirection="Horizontal">
                                <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                            </asp:RadioButtonList>

                            <input runat="server" type="text" placeholder="If yes, Please elaborate" id="txt_Eraborate" name="txt_Eraborate" />

                        </div>
                    </div>
                    <h4>Sales Order where PPV is retrieve</h4>
                    <%--<label>Any Sales Order?</label>--%>
                    <asp:RadioButtonList ID="cbl_salesOrder" name="cbl_salesOrder" runat="server" CellSpacing="30" CellPadding="30" RepeatDirection="Horizontal">
                        <asp:ListItem Text="No" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                    </asp:RadioButtonList>

                    <input runat="server" type="text" placeholder="Sales Order:" id="txt_salesOrder" name="txt_salesOrder" maxlength="50" />

                </div>
                <div class="col-half">
                    <h4>Sourcing Information</h4>
                    <div class="input-group input-group-icon">
                        <%--<input runat="server" type="text" placeholder="Vend#" id="txt_Vendor" name="txt_Vendor" />--%>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddl_Mfg" EventName="SelectedIndexChanged" />
                            </Triggers>
                            <ContentTemplate>
                                <asp:DropDownList ID="ddl_Mfg" runat="server" CssClass="ddl-style" AutoPostBack="true" OnSelectedIndexChanged="ddl_Mfg_SelectedIndexChanged">
                                    <asp:ListItem Value="-1" Text="Select Options">Select Options</asp:ListItem>
                                </asp:DropDownList>

                                <input runat="server" id="txt_MfgrPN" name="txt_MfgrPN" type="text" placeholder="MFGR Part No." />

                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="input-icon"><i class="fa fa-envelope"></i></div>
                    </div>
                    <%--<div class="input-group input-group-icon">
                        <input runat="server" id="txt_Mfgr" name="txt_Mfgr" type="text" placeholder="MFGR Name" />
                        <input runat="server" id="txt_MfgrPN" name="txt_MfgrPN" type="text" placeholder="MFGR Part No." />
                        <div class="input-icon"><i class="fa fa-key"></i></div>
                    </div>--%>
                    <div class="input-group input-group-icon">
                        <input runat="server" id="txt_LeadTime" name="txt_LeadTime" type="text" placeholder="Lead Time in Days" />
                        <div class="input-icon"><i class="fa fa-user"></i></div>
                    </div>
                </div>
            </div>
            <div class="row">
                <h4>PPV Details</h4>
                <div class="input-group input-group-icon">
                    <textarea runat="server" id="txt_Explanation" name="txt_Explanation" placeholder="Explanantion" style="width: 100%; height: 75px;" maxlength="1700"></textarea>
                </div>

            </div>
            <div class="row">
                <div class="input-group input-group-icon">
                    <asp:Button ID="btn_Submit" runat="server" Text="Submit" class="btn btn-lg btn-success " OnClick="btn_Submit_Click" />
                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" class="btn btn-lg btn-danger btn-style " OnClick="btn_Cancel_Click" />

                    <div class="input-icon"><i class="fa fa-key"></i></div>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
