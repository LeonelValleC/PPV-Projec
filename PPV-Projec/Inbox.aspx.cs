using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PPV_Projec
{
    public partial class Inbox : System.Web.UI.Page
    {
        PPVs ppv = new PPVs();
        User user = new User();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    //dt = ppv.LlenarDG("select id_ppv,wo as 'WO', po as 'PO', PN.pn as 'Part N#', Client.client, Vendor.vendor, qty as 'QTY', av_price as 'Av Price', new_price as 'New Price',  current_total as 'Current Total', new_total as 'New Total', case when first_approval = 0 then 'Decline' when first_approval is null then 'Wait for Aproval' when first_approval = 1 then 'Approved' end as 'Leader Approval', us1.name as 'Leader Approval by', case when last_approval = 0 then 'Decline' when last_approval is null then 'Wait for Aproval' when last_approval = 1 then 'Approved' end as 'Sourcing Approval', us2.name as 'Sourcing Approval By', salesOrder as 'ReqSO', salesOrder_num as 'SalesOrder' from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor left join users us1 on us1.id_user = ppv.first_auth left join users us2 on us2.id_user = ppv.last_auth where(first_approval = 0 or first_approval is null or last_approval = 0 or last_approval is null) and void != 1 and users.id_user = '" + Session["id_user"].ToString() + "'").Tables[0];
                    //dt.Merge(ppv.LlenarDG("select id_ppv,wo as 'WO', po as 'PO', PN.pn as 'Part N#', Client.client, Vendor.vendor, qty as 'QTY', av_price as 'Av Price', new_price as 'New Price', current_total as 'Current Total', new_total as 'New Total', case when first_approval = 0 then 'Decline' when first_approval is null then 'Wait for Aproval' when first_approval = 1 then 'Approved' end as 'Leader Approval', us1.name as 'Leader Approval by', case when last_approval = 0 then 'Decline' when last_approval is null then 'Wait for Aproval' when last_approval = 1 then 'Approved' end as 'Sourcing Approval', us2.name as 'Sourcing Approval By', salesOrder as 'ReqSO', salesOrder_num as 'SalesOrder' from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor left join users us1 on us1.id_user = ppv.first_auth left join users us2 on us2.id_user = ppv.last_auth where (first_approval = 1 and last_approval = 1 and salesOrder = 1 and salesOrder_num = '') and void != 1 and users.id_user = '" + Session["id_user"].ToString() + "'").Tables[0]);

                    dt = ppv.LlenarDG("select id_ppv,wo as 'WO', po as 'PO', PN.pn as 'Part N#', Client.client, Vendor.vendor, qty as 'QTY', av_price as 'Av Price', new_price as 'New Price',  current_total as 'Current Total', new_total as 'New Total', case when first_approval = 0 then 'Decline' when first_approval is null then 'Wait for Aproval' when first_approval = 1 then 'Approved' end as 'Leader Approval', us1.name as 'Leader Approval by', salesOrder as 'ReqSO', salesOrder_num as 'SalesOrder' from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor left join users us1 on us1.id_user = ppv.first_auth left join users us2 on us2.id_user = ppv.last_auth where (first_approval = 0 or first_approval is null ) and void != 1 and users.id_user = '" + Session["id_user"].ToString() + "'").Tables[0];
                    dt.Merge(ppv.LlenarDG("select id_ppv,wo as 'WO', po as 'PO', PN.pn as 'Part N#', Client.client, Vendor.vendor, qty as 'QTY', av_price as 'Av Price', new_price as 'New Price', current_total as 'Current Total', new_total as 'New Total', case when first_approval = 0 then 'Decline' when first_approval is null then 'Wait for Aproval' when first_approval = 1 then 'Approved' end as 'Leader Approval', us1.name as 'Leader Approval by', salesOrder as 'ReqSO', salesOrder_num as 'SalesOrder' from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor left join users us1 on us1.id_user = ppv.first_auth left join users us2 on us2.id_user = ppv.last_auth where (first_approval = 1 and salesOrder = 1 and salesOrder_num = '') and void != 1 and users.id_user = '" + Session["id_user"].ToString() + "'").Tables[0]);

                    GV_Approval.DataSource = dt;
                    GV_Approval.DataBind();
                }
            }
            catch (Exception)
            {

                //throw;
                string script = "alert(\"Login Error!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "Session Expired!", script, true);
                Response.Redirect("~/Login.aspx", false);
            }
        }

        protected void GV_Approval_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.Cells[0].Text != "No PPVs Pendings!")
            {
                if (e.Row.RowType == DataControlRowType.Header | e.Row.RowType == DataControlRowType.DataRow)
                    e.Row.Controls[1].Visible = false;

                if (e.Row.Cells[12].Text == "Decline" || e.Row.Cells[13].Text == "Decline")
                    e.Row.BackColor = System.Drawing.Color.OrangeRed;
                if (e.Row.Cells[12].Text == "Approved")
                    e.Row.BackColor = System.Drawing.Color.LightSkyBlue;
                if (e.Row.Cells[12].Text == "Approved" && e.Row.Cells[13].Text == "Approved")
                    e.Row.BackColor = System.Drawing.Color.CornflowerBlue;
                //if (e.Row.Cells[13].Text == "Decline")
                //    e.Row.BackColor = System.Drawing.Color.OrangeRed;

            }

        }

        protected void GV_Approval_SelectedIndexChanged(object sender, EventArgs e)
        {
            ppv.Id_ppv = int.Parse(GV_Approval.SelectedRow.Cells[1].Text);

            Response.Redirect("~/PPV_Detail_Buyer.aspx");
        }
    }
}