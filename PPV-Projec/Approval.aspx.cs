using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PPV_Projec
{

    public partial class Aproval : System.Web.UI.Page
    {
        PPVs ppv = new PPVs();
        User user = new User();
        //DataTable dt = new DataTable();

        private void GetUser()
        {
            //IList lista  = user.GetCustomers();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //    if (int.Parse(user.GetUser(int.Parse(Session["id_user"].ToString())).ElementAt(0).Level.ToString()) != 0)
                //    {
                try
                {

                    //GV_Approval.DataSource = ppv.LlenarDG("select id_ppv, users.name, po, pn,qty, av_price, new_price, client,vendor, current_total, new_total, total_increase from PPV join users on ppv.buyer = users.id_user where id_user = '" + user.Id_user + "'").Tables[0];
                    if (int.Parse(user.GetUser(int.Parse(Session["id_user"].ToString())).ElementAt(0).Level.ToString()) == 4)
                    {
                        //GV_Approval.DataSource = ppv.LlenarDG("select id_ppv, users.name as 'Buyer', po as 'PO', PN.pn as 'Part N#',qty as 'QTY', av_price as 'AV Price', new_price as 'New Price', Client.client, Vendor.vendor, current_total as 'Current Total', new_total as 'New Total', total_increase as 'Total PPV',case when first_approval = 0 then 'Decline' when first_approval is null then 'Wait for Aproval' when first_approval = 1 then 'Approved' end as 'Leader Approval', case when last_approval = 0 then 'Decline' when last_approval is null then 'Wait for Aproval' when last_approval = 1 then 'Approved' end as 'Sourcing Approval' from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor where id_user = '" + Session["id_user"].ToString() + "' and first_approval is not null and total_increase between 0 and 500 and id_level = 4 or id_level = 1 and (first_approval != 0 or last_approval != 0)").Tables[0];
                        ppv.Dt = ppv.LlenarDG("select id_ppv, users.name as 'Buyer', po as 'PO', PN.pn as 'Part N#',qty as 'QTY', av_price as 'AV Price', new_price as 'New Price', Client.client, Vendor.vendor, current_total as 'Current Total', new_total as 'New Total', total_increase as 'Total PPV',case when first_approval = 0 then 'Decline' when first_approval is null then 'Wait for Aproval' when first_approval = 1 then 'Approved' end as 'Leader Approval',explanation from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor where (total_increase between 0 and 500) and first_approval is null").Tables[0];
                    }
                    else if (int.Parse(user.GetUser(int.Parse(Session["id_user"].ToString())).ElementAt(0).Level.ToString()) == 5)
                    {
                        //GV_Approval.DataSource = ppv.LlenarDG("select id_ppv, users.name as 'Buyer', po as 'PO', PN.pn as 'Part N#',qty as 'QTY', av_price as 'AV Price', new_price as 'New Price', Client.client, Vendor.vendor, current_total as 'Current Total', new_total as 'New Total', total_increase as 'Total PPV',case when first_approval = 0 then 'Decline' when first_approval is null then 'Wait for Aproval' when first_approval = 1 then 'Approved' end as 'Leader Approval', case when last_approval = 0 then 'Decline' when last_approval is null then 'Wait for Aproval' when last_approval = 1 then 'Approved' end as 'Sourcing Approval' from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor where id_user = '" + Session["id_user"].ToString() + "' and first_approval is not null and total_increase between 501 and 2000 and id_level = 5 or id_level = 1 and (first_approval != 0 or last_approval != 0)").Tables[0];
                        ppv.Dt = ppv.LlenarDG("select id_ppv, users.name as 'Buyer', po as 'PO', PN.pn as 'Part N#',qty as 'QTY', av_price as 'AV Price', new_price as 'New Price', Client.client, Vendor.vendor, current_total as 'Current Total', new_total as 'New Total', total_increase as 'Total PPV',case when first_approval = 0 then 'Decline' when first_approval is null then 'Wait for Aproval' when first_approval = 1 then 'Approved' end as 'Leader Approval',explanation from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor where (total_increase < 501 or total_increase between 501 and 2000) and first_approval is null").Tables[0];
                    }
                    else if (int.Parse(user.GetUser(int.Parse(Session["id_user"].ToString())).ElementAt(0).Level.ToString()) == 6)
                    {
                        //GV_Approval.DataSource = ppv.LlenarDG("select id_ppv, users.name as 'Buyer', po as 'PO', PN.pn as 'Part N#',qty as 'QTY', av_price as 'AV Price', new_price as 'New Price', Client.client, Vendor.vendor, current_total as 'Current Total', new_total as 'New Total', total_increase as 'Total PPV',case when first_approval = 0 then 'Decline' when first_approval is null then 'Wait for Aproval' when first_approval = 1 then 'Approved' end as 'Leader Approval', case when last_approval = 0 then 'Decline' when last_approval is null then 'Wait for Aproval' when last_approval = 1 then 'Approved' end as 'Sourcing Approval' from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor where id_user = '" + Session["id_user"].ToString() + "' and first_approval is not null and total_increase > 2000 and id_level = 6 or id_level = 1 and (first_approval != 0 or last_approval != 0)").Tables[0];
                        ppv.Dt = ppv.LlenarDG("select id_ppv, users.name as 'Buyer', po as 'PO', PN.pn as 'Part N#',qty as 'QTY', av_price as 'AV Price', new_price as 'New Price', Client.client, Vendor.vendor, current_total as 'Current Total', new_total as 'New Total', total_increase as 'Total PPV',case when first_approval = 0 then 'Decline' when first_approval is null then 'Wait for Aproval' when first_approval = 1 then 'Approved' end as 'Leader Approval',explanation from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor where (total_increase < 2000 or total_increase > 2000) and first_approval is null").Tables[0];
                    }
                    ////Temporally Disable Second Approval
                    //else if (int.Parse(user.GetCustomers(int.Parse(Session["id_user"].ToString())).ElementAt(0).Level.ToString()) == 7)
                    //{
                    //    //GV_Approval.DataSource = ppv.LlenarDG("select id_ppv, users.name as 'Buyer', po as 'PO', PN.pn as 'Part N#',qty as 'QTY', av_price as 'AV Price', new_price as 'New Price', Client.client, Vendor.vendor, current_total as 'Current Total', new_total as 'New Total', total_increase as 'Total PPV',case when first_approval = 0 then 'Decline' when first_approval is null then 'Wait for Aproval' when first_approval = 1 then 'Approved' end as 'Leader Approval', case when last_approval = 0 then 'Decline' when last_approval is null then 'Wait for Aproval' when last_approval = 1 then 'Approved' end as 'Sourcing Approval' from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor where id_user = '" + Session["id_user"].ToString() + "' and first_approval is not null and last_approval is null and (first_approval != 0 or last_approval != 0)").Tables[0];
                    //    GV_Approval.DataSource = ppv.LlenarDG("select id_ppv, users.name as 'Buyer', po as 'PO', PN.pn as 'Part N#',qty as 'QTY', av_price as 'AV Price', new_price as 'New Price', Client.client, Vendor.vendor, current_total as 'Current Total', new_total as 'New Total', total_increase as 'Total PPV',case when first_approval = 0 then 'Decline' when first_approval is null then 'Wait for Aproval' when first_approval = 1 then 'Approved' end as 'Leader Approval' from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor where first_approval is not null and last_approval is null").Tables[0];
                    //}
                    else if (int.Parse(user.GetUser(int.Parse(Session["id_user"].ToString())).ElementAt(0).Level.ToString()) == 1)
                    {
                        //GV_Approval.DataSource = ppv.LlenarDG("select id_ppv, users.name as 'Buyer', po as 'PO', PN.pn as 'Part N#',qty as 'QTY', av_price as 'AV Price', new_price as 'New Price', Client.client, Vendor.vendor, current_total as 'Current Total', new_total as 'New Total', total_increase as 'Total PPV',case when first_approval = 0 then 'Decline' when first_approval is null then 'Wait for Aproval' when first_approval = 1 then 'Approved' end as 'Leader Approval', case when last_approval = 0 then 'Decline' when last_approval is null then 'Wait for Aproval' when last_approval = 1 then 'Approved' end as 'Sourcing Approval' from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor where first_approval is null or last_approval is null and (first_approval != 0 or last_approval != 0)").Tables[0];
                        ppv.Dt = ppv.LlenarDG("select id_ppv, users.name as 'Buyer', po as 'PO', PN.pn as 'Part N#',qty as 'QTY', av_price as 'AV Price', new_price as 'New Price', Client.client, Vendor.vendor, current_total as 'Current Total', new_total as 'New Total', total_increase as 'Total PPV',case when first_approval = 0 then 'Decline' when first_approval is null then 'Wait for Aproval' when first_approval = 1 then 'Approved' end as 'Leader Approval',explanation from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor where total_increase > 0 and first_approval is null").Tables[0];
                    }

                    ppv.Dt.Merge(ppv.LlenarDG("select id_ppv, users.name as 'Buyer', po as 'PO', PN.pn as 'Part N#',qty as 'QTY', av_price as 'AV Price', new_price as 'New Price', Client.client, Vendor.vendor, current_total as 'Current Total', new_total as 'New Total', total_increase as 'Total PPV',case when first_approval = 0 then 'Decline' when first_approval is null then 'Wait for Aproval' when first_approval = 1 then 'Approved' end as 'Leader Approval',explanation from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor where total_increase < 0 and first_approval is null").Tables[0]);

                    GV_Approval.DataSource = ppv.Dt;
                    GV_Approval.DataBind();
                    //    }



                }
                catch (System.NullReferenceException)
                {

                    string script = "alert(\"Login Error!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Session Expired!", script, true);

                    Response.Redirect("~/Login.aspx", true);
                }
            }
        }

        protected void GV_Approval_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header | e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Controls[1].Visible = false;
            }
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

        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        protected void GV_Approval_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ppv.Id_ppv = int.Parse(ppv.Dt.Rows[GV_Approval.SelectedIndex][0].ToString());

            //Response.Redirect("~/ppv_detail.aspx");
        }

        protected void GV_Approval_SelectedIndexChanged1(object sender, EventArgs e)
        {
            ppv.Id_ppv = int.Parse(ppv.Dt.Rows[GV_Approval.SelectedIndex][0].ToString());

            //ppv.Id_ppv = int.Parse(GV_Approval.SelectedRow.Cells[1].Text);

            Response.Redirect("~/ppv_detail.aspx");
        }
    }
}