using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PPV_Projec
{
    public partial class View : System.Web.UI.Page
    {
        PPVs ppv = new PPVs();
        DateTime dateNow = new DateTime();
        User user = new User();
        //DataTable dt = new DataTable();
        //DataTable dtNew = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            dateNow.ToString("ddMMyy");
            if (!IsPostBack)
            {
                BindGridview();

            }
        }

        protected void GV_Approval_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.Header | e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    //e.Row.Controls[24].Visible = false;
            //}

            


        }


        protected void GV_Approval_DataBound(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            for (int i = 1; i < GV_Approval.Columns.Count; i++)
            {
                if (GV_Approval.Columns[i].HeaderText != "Details" && GV_Approval.Columns[i].HeaderText != "id")
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    TextBox txtSearch = new TextBox();
                    txtSearch.Attributes["placeholder"] = GV_Approval.Columns[i].HeaderText;
                    txtSearch.CssClass = "search_textbox";
                    txtSearch.ID = "txt_search";
                    cell.Controls.Add(txtSearch);
                    row.Controls.Add(cell);
                }
                else
                {
                    TableHeaderCell cell = new TableHeaderCell();
                    Label txtSearch = new Label();
                    txtSearch.Attributes["placeholder"] = GV_Approval.Columns[i].HeaderText;
                    txtSearch.CssClass = "search_textbox";
                    cell.Controls.Add(txtSearch);
                    row.Controls.Add(cell);
                }

            }
            //    else if (GV_Approval.Columns[i].HeaderText == "Details")
            //    {
            //        TableHeaderCell cell = new TableHeaderCell();
            //        Label txtSearch = new Label();
            //        txtSearch.Attributes["placeholder"] = GV_Approval.Columns[i].HeaderText;
            //        txtSearch.CssClass = "search_textbox";
            //        cell.Controls.Add(txtSearch);
            //        row.Controls.Add(cell);
            //    }

            //    if (GV_Approval.Columns[i].HeaderText == "Details")
            //        GV_Approval.Rows[0].Cells[0].Visible = false;

            //}
            GV_Approval.HeaderRow.Parent.Controls.AddAt(1, row);

            //}
        }


        protected void ddl_TypeDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchPPV();
        }

        protected void date1_TextChanged(object sender, EventArgs e)
        {
            SearchPPV();

        }

        protected void date2_TextChanged(object sender, EventArgs e)
        {
            SearchPPV();

        }

        private void SearchPPV()
        {
            string buscar1 = "", buscar2 = "";
            if (!string.IsNullOrEmpty(date1.Text))
            {
                DateTime fecha1 = Convert.ToDateTime(date1.Text);
                buscar1 = fecha1.ToString("yyyy-MM-dd 00:00:00");
            }
            if (!string.IsNullOrEmpty(date2.Text))
            {
                DateTime fecha2 = Convert.ToDateTime(date2.Text);
                buscar2 = fecha2.ToString("yyyy-MM-dd 23:59:59");
            }

            if (ddl_SO.SelectedValue == "2")
            {
                if (ddl_TypeDate.SelectedValue == "1")
                {
                    ppv.Dt = ppv.LlenarDG("select id_ppv, us1.name as 'Approved by', users.name as 'Buyer',wo, po, PN.pn, Client.clientID, Vendor.vendorID, qty, elaborate,case when salesOrder = 1 then 'Yes' when salesOrder = 0 then 'No' end as 'salesOrder', explanation,salesOrder_num,MFG.mfg, MFG.mfg_desc,leadtime, case when reason = 1 then '' when reason = 1 then 'Price Change' when reason = 2 then 'Combined Requirements' when reason = 3 then 'Quantity Change' when reason = 4 then 'Alternate Source' when reason = 5 then 'Broker Purchase' when reason = 6 then 'Other (Specify in Explanation)' end as 'reason',case when times = 1 then 'No'  when times = 2 then 'Yes' end as 'times',case when OtherChange = 1 then 'No' when OtherChange = 2 then 'Yes' end as 'OtherChange', note ,date_ppv, first_date, first_approval, av_price, new_price, total_increase, current_total, new_total from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor left join MFG on MFG.id_mfg = PPV.id_mfg left join users us1 on us1.id_user = ppv.first_auth left join users us2 on us2.id_user = ppv.last_auth where first_approval = 1 or first_approval = 0 and date_ppv >= '" + buscar1 + "' and  date_ppv <= '" + buscar2 + "' ").Tables[0];
                    //ppv.Dt.Merge(ppv.LlenarDG("select id_ppv, us1.name as 'Approved by', users.name as 'Buyer',wo, po, PN.pn, Client.clientID, Vendor.vendorID, qty, elaborate, case when salesOrder = 1 then 'No'  when times = 2 then 'Yes' end as 'salesOrder', explanation,salesOrder_num,MFG.mfg, MFG.mfg_desc,leadtime, case when reason = 1 then '' when reason = 1 then 'Price Change' when reason = 2 then 'Combined Requirements' when reason = 3 then 'Quantity Change' when reason = 4 then 'Alternate Source' when reason = 5 then 'Broker Purchase' when reason = 6 then 'Other (Specify in Explanation)' end as 'reason',case when times = 1 then 'No'  when times = 2 then 'Yes' end as 'times',case when OtherChange = 1 then 'No' when OtherChange = 2 then 'Yes' end as 'OtherChange', note ,date_ppv, first_date, first_approval, av_price, new_price, total_increase, current_total, new_total from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor left join MFG on MFG.id_mfg = PPV.id_mfg left join users us1 on us1.id_user = ppv.first_auth left join users us2 on us2.id_user = ppv.last_auth where first_approval = 1 and salesOrder = 1 and (salesOrder_num is not null or salesOrder_num != '')  and date_ppv >= '" + buscar1 + "' and  date_ppv <= '" + buscar2 + "'").Tables[0]);
                    GV_Approval.DataSource = ppv.Dt;
                    GV_Approval.DataBind();
                    SumTotalGV();
                }
                else if (ddl_TypeDate.SelectedValue == "2")
                {
                    ppv.Dt = ppv.LlenarDG("select id_ppv, us1.name as 'Approved by', users.name as 'Buyer',wo, po, PN.pn, Client.clientID, Vendor.vendorID, qty, elaborate, case when salesOrder = 1 then 'Yes' when salesOrder = 0 then 'No' end as 'salesOrder', explanation,salesOrder_num,MFG.mfg, MFG.mfg_desc,leadtime, case when reason = 1 then '' when reason = 1 then 'Price Change' when reason = 2 then 'Combined Requirements' when reason = 3 then 'Quantity Change' when reason = 4 then 'Alternate Source' when reason = 5 then 'Broker Purchase' when reason = 6 then 'Other (Specify in Explanation)' end as 'reason',case when times = 1 then 'No'  when times = 2 then 'Yes' end as 'times',case when OtherChange = 1 then 'No' when OtherChange = 2 then 'Yes' end as 'OtherChange', note ,date_ppv, first_date, first_approval, av_price, new_price, total_increase, current_total, new_total from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor left join MFG on MFG.id_mfg = PPV.id_mfg left join users us1 on us1.id_user = ppv.first_auth left join users us2 on us2.id_user = ppv.last_auth where first_approval = 1 or first_approval = 0 and first_date >= '" + buscar1 + "' and  first_date <= '" + buscar2 + "' ").Tables[0];
                    //ppv.Dt.Merge(ppv.LlenarDG("select id_ppv, us1.name as 'Approved by', users.name as 'Buyer',wo, po, PN.pn, Client.clientID, Vendor.vendorID, qty, elaborate, case when salesOrder = 1 then 'No'  when times = 2 then 'Yes' end as 'salesOrder', explanation,salesOrder_num,MFG.mfg, MFG.mfg_desc,leadtime, case when reason = 1 then '' when reason = 1 then 'Price Change' when reason = 2 then 'Combined Requirements' when reason = 3 then 'Quantity Change' when reason = 4 then 'Alternate Source' when reason = 5 then 'Broker Purchase' when reason = 6 then 'Other (Specify in Explanation)' end as 'reason',case when times = 1 then 'No'  when times = 2 then 'Yes' end as 'times',case when OtherChange = 1 then 'No' when OtherChange = 2 then 'Yes' end as 'OtherChange', note ,date_ppv, first_date, first_approval, av_price, new_price, total_increase, current_total, new_total from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor left join MFG on MFG.id_mfg = PPV.id_mfg left join users us1 on us1.id_user = ppv.first_auth left join users us2 on us2.id_user = ppv.last_auth where first_approval = 1 and salesOrder = 1 and (salesOrder_num is not null or salesOrder_num != '')  and first_date >= '" + buscar1 + "' and  first_date <= '" + buscar2 + "' ").Tables[0]);
                    GV_Approval.DataSource = ppv.Dt;
                    GV_Approval.DataBind();
                    SumTotalGV();
                }
                else if (ddl_TypeDate.SelectedValue == "3")
                {
                    ppv.Dt = ppv.LlenarDG("select id_ppv, us1.name as 'Approved by', users.name as 'Buyer',wo, po, PN.pn, Client.clientID, Vendor.vendorID, qty, elaborate, case when salesOrder = 1 then 'Yes' when salesOrder = 0 then 'No' end as 'salesOrder', explanation,salesOrder_num,MFG.mfg, MFG.mfg_desc,leadtime, case when reason = 1 then '' when reason = 1 then 'Price Change' when reason = 2 then 'Combined Requirements' when reason = 3 then 'Quantity Change' when reason = 4 then 'Alternate Source' when reason = 5 then 'Broker Purchase' when reason = 6 then 'Other (Specify in Explanation)' end as 'reason',case when times = 1 then 'No'  when times = 2 then 'Yes' end as 'times',case when OtherChange = 1 then 'No' when OtherChange = 2 then 'Yes' end as 'OtherChange', note ,date_ppv, first_date, first_approval, av_price, new_price, total_increase, current_total, new_total from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor left join MFG on MFG.id_mfg = PPV.id_mfg left join users us1 on us1.id_user = ppv.first_auth left join users us2 on us2.id_user = ppv.last_auth where first_approval = 1 or first_approval = 0 and last_date >= '" + buscar1 + "' and  last_date <= '" + buscar2 + "'").Tables[0];
                    //ppv.Dt.Merge(ppv.LlenarDG("select id_ppv, us1.name as 'Approved by', users.name as 'Buyer',wo, po, PN.pn, Client.clientID, Vendor.vendorID, qty, elaborate, case when salesOrder = 1 then 'No'  when times = 2 then 'Yes' end as 'salesOrder', explanation,salesOrder_num,MFG.mfg, MFG.mfg_desc,leadtime, case when reason = 1 then '' when reason = 1 then 'Price Change' when reason = 2 then 'Combined Requirements' when reason = 3 then 'Quantity Change' when reason = 4 then 'Alternate Source' when reason = 5 then 'Broker Purchase' when reason = 6 then 'Other (Specify in Explanation)' end as 'reason',case when times = 1 then 'No'  when times = 2 then 'Yes' end as 'times',case when OtherChange = 1 then 'No' when OtherChange = 2 then 'Yes' end as 'OtherChange', note ,date_ppv, first_date, first_approval, av_price, new_price, total_increase, current_total, new_total from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor left join MFG on MFG.id_mfg = PPV.id_mfg left join users us1 on us1.id_user = ppv.first_auth left join users us2 on us2.id_user = ppv.last_auth where first_approval = 1 and salesOrder = 1 and (salesOrder_num is not null or salesOrder_num != '') and last_date >= '" + buscar1 + "' and  last_date <= '" + buscar2 + "' ").Tables[0]);
                    GV_Approval.DataSource = ppv.Dt;
                    GV_Approval.DataBind();
                    SumTotalGV();
                }
            }
            else if (ddl_SO.SelectedValue == "1")
            {
                if (ddl_TypeDate.SelectedValue == "1")
                {
                    ppv.Dt = ppv.LlenarDG("select id_ppv, us1.name as 'Approved by', users.name as 'Buyer',wo, po, PN.pn, Client.clientID, Vendor.vendorID, qty, elaborate, case when salesOrder = 1 then 'Yes' when salesOrder = 0 then 'No' end as 'salesOrder', explanation,salesOrder_num,MFG.mfg, MFG.mfg_desc,leadtime, case when reason = 1 then '' when reason = 1 then 'Price Change' when reason = 2 then 'Combined Requirements' when reason = 3 then 'Quantity Change' when reason = 4 then 'Alternate Source' when reason = 5 then 'Broker Purchase' when reason = 6 then 'Other (Specify in Explanation)' end as 'reason',case when times = 1 then 'No'  when times = 2 then 'Yes' end as 'times',case when OtherChange = 1 then 'No' when OtherChange = 2 then 'Yes' end as 'OtherChange', note ,date_ppv, first_date, first_approval, av_price, new_price, total_increase, current_total, new_total from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor left join MFG on MFG.id_mfg = PPV.id_mfg left join users us1 on us1.id_user = ppv.first_auth left join users us2 on us2.id_user = ppv.last_auth where first_approval = 1 and date_ppv >= '" + buscar1 + "' and  date_ppv <= '" + buscar2 + "' ").Tables[0];
                    ppv.Dt.Merge(ppv.LlenarDG("select id_ppv, us1.name as 'Approved by', users.name as 'Buyer',wo, po, PN.pn, Client.clientID, Vendor.vendorID, qty, elaborate, case when salesOrder = 1 then 'Yes' when salesOrder = 0 then 'No' end as 'salesOrder', explanation,salesOrder_num,MFG.mfg, MFG.mfg_desc,leadtime, case when reason = 1 then '' when reason = 1 then 'Price Change' when reason = 2 then 'Combined Requirements' when reason = 3 then 'Quantity Change' when reason = 4 then 'Alternate Source' when reason = 5 then 'Broker Purchase' when reason = 6 then 'Other (Specify in Explanation)' end as 'reason',case when times = 1 then 'No'  when times = 2 then 'Yes' end as 'times',case when OtherChange = 1 then 'No' when OtherChange = 2 then 'Yes' end as 'OtherChange', note ,date_ppv, first_date, first_approval, av_price, new_price, total_increase, current_total, new_total from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor left join MFG on MFG.id_mfg = PPV.id_mfg left join users us1 on us1.id_user = ppv.first_auth left join users us2 on us2.id_user = ppv.last_auth where first_approval = 1 and salesOrder = 1 and (salesOrder_num is not null or salesOrder_num != '')  and date_ppv >= '" + buscar1 + "' and  date_ppv <= '" + buscar2 + "'").Tables[0]);
                    GV_Approval.DataSource = ppv.Dt;
                    GV_Approval.DataBind();
                    SumTotalGV();
                }
                else if (ddl_TypeDate.SelectedValue == "2")
                {
                    ppv.Dt = ppv.LlenarDG("select id_ppv, us1.name as 'Approved by', users.name as 'Buyer',wo, po, PN.pn, Client.clientID, Vendor.vendorID, qty, elaborate, case when salesOrder = 1 then 'Yes' when salesOrder = 0 then 'No' end as 'salesOrder', explanation,salesOrder_num,MFG.mfg, MFG.mfg_desc,leadtime, case when reason = 1 then '' when reason = 1 then 'Price Change' when reason = 2 then 'Combined Requirements' when reason = 3 then 'Quantity Change' when reason = 4 then 'Alternate Source' when reason = 5 then 'Broker Purchase' when reason = 6 then 'Other (Specify in Explanation)' end as 'reason',case when times = 1 then 'No'  when times = 2 then 'Yes' end as 'times',case when OtherChange = 1 then 'No' when OtherChange = 2 then 'Yes' end as 'OtherChange', note ,date_ppv, first_date, first_approval, av_price, new_price, total_increase, current_total, new_total from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor left join MFG on MFG.id_mfg = PPV.id_mfg left join users us1 on us1.id_user = ppv.first_auth left join users us2 on us2.id_user = ppv.last_auth where first_approval = 1 and first_date >= '" + buscar1 + "' and  first_date <= '" + buscar2 + "' ").Tables[0];
                    ppv.Dt.Merge(ppv.LlenarDG("select id_ppv, us1.name as 'Approved by', users.name as 'Buyer',wo, po, PN.pn, Client.clientID, Vendor.vendorID, qty, elaborate, case when salesOrder = 1 then 'Yes' when salesOrder = 0 then 'No' end as 'salesOrder', explanation,salesOrder_num,MFG.mfg, MFG.mfg_desc,leadtime, case when reason = 1 then '' when reason = 1 then 'Price Change' when reason = 2 then 'Combined Requirements' when reason = 3 then 'Quantity Change' when reason = 4 then 'Alternate Source' when reason = 5 then 'Broker Purchase' when reason = 6 then 'Other (Specify in Explanation)' end as 'reason',case when times = 1 then 'No'  when times = 2 then 'Yes' end as 'times',case when OtherChange = 1 then 'No' when OtherChange = 2 then 'Yes' end as 'OtherChange', note ,date_ppv, first_date, first_approval, av_price, new_price, total_increase, current_total, new_total from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor left join MFG on MFG.id_mfg = PPV.id_mfg left join users us1 on us1.id_user = ppv.first_auth left join users us2 on us2.id_user = ppv.last_auth where first_approval = 1 and salesOrder = 1 and (salesOrder_num is not null or salesOrder_num != '')  and first_date >= '" + buscar1 + "' and  first_date <= '" + buscar2 + "' ").Tables[0]);
                    GV_Approval.DataSource = ppv.Dt;
                    GV_Approval.DataBind();
                    SumTotalGV();
                }
                else if (ddl_TypeDate.SelectedValue == "3")
                {
                    ppv.Dt = ppv.LlenarDG("select id_ppv, us1.name as 'Approved by', users.name as 'Buyer',wo, po, PN.pn, Client.clientID, Vendor.vendorID, qty, elaborate, case when salesOrder = 1 then 'Yes' when salesOrder = 0 then 'No' end as 'salesOrder', explanation,salesOrder_num,MFG.mfg, MFG.mfg_desc,leadtime, case when reason = 1 then '' when reason = 1 then 'Price Change' when reason = 2 then 'Combined Requirements' when reason = 3 then 'Quantity Change' when reason = 4 then 'Alternate Source' when reason = 5 then 'Broker Purchase' when reason = 6 then 'Other (Specify in Explanation)' end as 'reason',case when times = 1 then 'No'  when times = 2 then 'Yes' end as 'times',case when OtherChange = 1 then 'No' when OtherChange = 2 then 'Yes' end as 'OtherChange', note ,date_ppv, first_date, first_approval, av_price, new_price, total_increase, current_total, new_total from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor left join MFG on MFG.id_mfg = PPV.id_mfg left join users us1 on us1.id_user = ppv.first_auth left join users us2 on us2.id_user = ppv.last_auth where first_approval = 1 and last_date >= '" + buscar1 + "' and  last_date <= '" + buscar2 + "'").Tables[0];
                    ppv.Dt.Merge(ppv.LlenarDG("select id_ppv, us1.name as 'Approved by', users.name as 'Buyer',wo, po, PN.pn, Client.clientID, Vendor.vendorID, qty, elaborate, case when salesOrder = 1 then 'Yes' when salesOrder = 0 then 'No' end as 'salesOrder', explanation,salesOrder_num,MFG.mfg, MFG.mfg_desc,leadtime, case when reason = 1 then '' when reason = 1 then 'Price Change' when reason = 2 then 'Combined Requirements' when reason = 3 then 'Quantity Change' when reason = 4 then 'Alternate Source' when reason = 5 then 'Broker Purchase' when reason = 6 then 'Other (Specify in Explanation)' end as 'reason',case when times = 1 then 'No'  when times = 2 then 'Yes' end as 'times',case when OtherChange = 1 then 'No' when OtherChange = 2 then 'Yes' end as 'OtherChange', note ,date_ppv, first_date, first_approval, av_price, new_price, total_increase, current_total, new_total from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor left join MFG on MFG.id_mfg = PPV.id_mfg left join users us1 on us1.id_user = ppv.first_auth left join users us2 on us2.id_user = ppv.last_auth where first_approval = 1 and salesOrder = 1 and (salesOrder_num is not null or salesOrder_num != '') and last_date >= '" + buscar1 + "' and  last_date <= '" + buscar2 + "' ").Tables[0]);
                    GV_Approval.DataSource = ppv.Dt;
                    GV_Approval.DataBind();
                    SumTotalGV();
                }

            }

        }

        protected void GV_Approval_SelectedIndexChanged(object sender, EventArgs e)
        {
            ppv.Id_ppv = int.Parse(ppv.Dt.Rows[GV_Approval.SelectedIndex][0].ToString());

            Response.Redirect("~/PPV_Detail_View.aspx");
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {

        }

        private void BindGridview()
        {
            try
            {
                if (ddl_SO.SelectedValue == "1")
                {
                    ppv.Dt = ppv.LlenarDG("select id_ppv, us1.name as 'Approved by', users.name as 'Buyer',wo, po, PN.pn, Client.clientID, Vendor.vendorID, qty, elaborate, case when salesOrder = 1 then 'Yes' when salesOrder = 0 then 'No' end as 'salesOrder', explanation,salesOrder_num,MFG.mfg, MFG.mfg_desc,leadtime, case when reason = 1 then '' when reason = 1 then 'Price Change' when reason = 2 then 'Combined Requirements' when reason = 3 then 'Quantity Change' when reason = 4 then 'Alternate Source' when reason = 5 then 'Broker Purchase' when reason = 6 then 'Other (Specify in Explanation)' end as 'reason',case when times = 1 then 'No'  when times = 2 then 'Yes' end as 'times',case when OtherChange = 1 then 'No' when OtherChange = 2 then 'Yes' end as 'OtherChange', note ,date_ppv, first_date, first_approval, av_price, new_price, total_increase, current_total, new_total from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor left join MFG on MFG.id_mfg = PPV.id_mfg left join users us1 on us1.id_user = ppv.first_auth left join users us2 on us2.id_user = ppv.last_auth where first_approval = 1  and salesOrder = 0 or void = 1 or first_approval = 0").Tables[0];
                    ppv.Dt.Merge(ppv.LlenarDG("select id_ppv, us1.name as 'Approved by', users.name as 'Buyer',wo, po, PN.pn, Client.clientID, Vendor.vendorID, qty, elaborate, case when salesOrder = 1 then 'Yes' when salesOrder = 0 then 'No' end as 'salesOrder', explanation,salesOrder_num,MFG.mfg, MFG.mfg_desc,leadtime, case when reason = 1 then '' when reason = 1 then 'Price Change' when reason = 2 then 'Combined Requirements' when reason = 3 then 'Quantity Change' when reason = 4 then 'Alternate Source' when reason = 5 then 'Broker Purchase' when reason = 6 then 'Other (Specify in Explanation)' end as 'reason',case when times = 1 then 'No'  when times = 2 then 'Yes' end as 'times',case when OtherChange = 1 then 'No' when OtherChange = 2 then 'Yes' end as 'OtherChange', note ,date_ppv, first_date, first_approval, av_price, new_price, total_increase, current_total, new_total from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor left join MFG on MFG.id_mfg = PPV.id_mfg left join users us1 on us1.id_user = ppv.first_auth left join users us2 on us2.id_user = ppv.last_auth where first_approval = 1 and salesOrder = 1 and salesOrder_num != '' ").Tables[0]);
                }
                else if (ddl_SO.SelectedValue == "2")
                {
                    //ppv.Dt.Merge(ppv.LlenarDG("select id_ppv, us1.name as 'Approved by', users.name as 'Buyer',wo, po, PN.pn, Client.clientID, Vendor.vendorID, qty, elaborate, case when salesOrder = 1 then 'No'  when times = 2 then 'Yes' end as 'salesOrder', explanation,salesOrder_num,MFG.mfg, MFG.mfg_desc,leadtime, case when reason = 1 then '' when reason = 1 then 'Price Change' when reason = 2 then 'Combined Requirements' when reason = 3 then 'Quantity Change' when reason = 4 then 'Alternate Source' when reason = 5 then 'Broker Purchase' when reason = 6 then 'Other (Specify in Explanation)' end as 'reason',case when times = 1 then 'No'  when times = 2 then 'Yes' end as 'times',case when OtherChange = 1 then 'No' when OtherChange = 2 then 'Yes' end as 'OtherChange', note ,date_ppv, first_date, first_approval, av_price, new_price, total_increase, current_total, new_total from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor left join MFG on MFG.id_mfg = PPV.id_mfg left join users us1 on us1.id_user = ppv.first_auth left join users us2 on us2.id_user = ppv.last_auth where first_approval = 1 and salesOrder = 1 and salesOrder_num != '' ").Tables[0]);
                    ppv.Dt = ppv.LlenarDG("select id_ppv, us1.name as 'Approved by', users.name as 'Buyer',wo, po, PN.pn, Client.clientID, Vendor.vendorID, qty, elaborate, case when salesOrder = 1 then 'Yes' when salesOrder = 0 then 'No' end as 'salesOrder', explanation,salesOrder_num,MFG.mfg, MFG.mfg_desc,leadtime, case when reason = 1 then '' when reason = 1 then 'Price Change' when reason = 2 then 'Combined Requirements' when reason = 3 then 'Quantity Change' when reason = 4 then 'Alternate Source' when reason = 5 then 'Broker Purchase' when reason = 6 then 'Other (Specify in Explanation)' end as 'reason',case when times = 1 then 'No'  when times = 2 then 'Yes' end as 'times',case when OtherChange = 1 then 'No' when OtherChange = 2 then 'Yes' end as 'OtherChange', note ,date_ppv, first_date, first_approval, av_price, new_price, total_increase, current_total, new_total from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor left join MFG on MFG.id_mfg = PPV.id_mfg left join users us1 on us1.id_user = ppv.first_auth left join users us2 on us2.id_user = ppv.last_auth where first_approval = 1 or first_approval = 0").Tables[0];


                }

                if (int.Parse(user.GetUser(int.Parse(Session["id_user"].ToString())).ElementAt(0).Level.ToString()) == 1)
                {
                    ddl_SO.Visible = true;

                }



                GV_Approval.Columns[1].Visible = false;

                GV_Approval.DataSource = ppv.Dt;
                GV_Approval.DataBind();

                ////Calculate Sum and display in Footer Row
                //decimal total = ppv.Dt.AsEnumerable().Sum(row => row.Field<decimal>("total_increase"));
                //GV_Approval.FooterRow.Cells[13].Text = "Total PPV SUM";
                //GV_Approval.FooterRow.Cells[13].HorizontalAlign = HorizontalAlign.Right;
                //GV_Approval.FooterRow.Cells[14].Text = total.ToString("N2");
                SumTotalGV();
            }
            catch (Exception)
            {

                //throw;
                string script = "alert(\"Login Error!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "Session Expired!", script, true);
                Response.Redirect("~/Login.aspx", false);
            }

        }

        private void SumTotalGV()
        {
            try
            {
                //Calculate Sum and display in Footer Row
                decimal total = ppv.Dt.AsEnumerable().Sum(row => row.Field<decimal>("total_increase"));
                GV_Approval.FooterRow.Cells[13].Text = "Total PPV SUM";
                GV_Approval.FooterRow.Cells[13].HorizontalAlign = HorizontalAlign.Right;
                GV_Approval.FooterRow.Cells[14].Text = total.ToString("N2");

            }
            catch (System.NullReferenceException)
            {

                // throw;
            }
        }

        private void ExportGridView()
        {
            BindGridview();
            string attachment = "attachment; filename=ReportPPV" + DateTime.Now.ToString("MMddyy") + ".xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            //GV_Approval.AllowPaging = false;
            //BindGridview();
            //Change the Header Row back to white color
            //GV_Approval.HeaderRow.Style.Add("background-color", "#FFFFFF");
            //Applying stlye to gridview header cells
            for (int i = 0; i < GV_Approval.HeaderRow.Cells.Count; i++)
            {
                GV_Approval.HeaderRow.Cells[i].Style.Add("background-color", "#df5015");
                GV_Approval.Columns[GV_Approval.Columns.Count - 1].Visible = false;
                GV_Approval.Columns[0].Visible = false;
                GV_Approval.Rows[0].Visible = false;
            }
            GV_Approval.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        protected void ddl_SO_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridview();
        }

        protected void GV_Approval_PreRender(object sender, EventArgs e)
        {
            // You only need the following 2 lines of code if you are not 
            // using an ObjectDataSource of SqlDataSource
            if (!Page.IsPostBack)
            {
                //GV_Approval.DataSource = DataTable();
                //GV_Approval.DataBind();
                BindGridview();
            }
            if (GV_Approval.Rows.Count > 0)
            {
                //This replaces <td> with <th> and adds the scope attribute
                GV_Approval.UseAccessibleHeader = true;

                //This will add the <thead> and <tbody> elements
                GV_Approval.HeaderRow.TableSection = TableRowSection.TableHeader;

                //This adds the <tfoot> element. 
                //Remove if you don't have a footer row
                //gvTheGrid.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void GV_Approval_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GV_Approval.PageIndex = e.NewPageIndex;
            BindGridview();
            //GV_Approval.DataSource = DataTable();
            //GV_Approval.DataBind();
        }

    }
}