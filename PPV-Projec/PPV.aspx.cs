using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PPV_Projec
{
    public partial class PPV : System.Web.UI.Page
    {
        PPVs ppv = new PPVs();
        //User user = new User();
        PartN pn = new PartN();
        Vendor vendor = new Vendor();
        Clients client = new Clients();
        MFGR mfg = new MFGR();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataClasses1DataContext dc = new DataClasses1DataContext();
                var ddquery = (from dd in dc.PNs select dd).Distinct().ToList();

                ddl_pn.DataSource = ddquery;
                //ddl_pn.DataSource = ppv.LlenarComboBox("select * from PN where pn like '" + ddl_pn.Text + "%'");
                ddl_pn.DataTextField = "pn1";
                ddl_pn.DataValueField = "id_pn";
                ddl_pn.DataBind();
                ddl_pn.Items.Insert(0, new ListItem("Part N#", String.Empty));
                ddl_pn.SelectedIndex = 0;


                ddl_client.DataSource = client.LlenarComboBox("select * from Client");
                ddl_client.DataTextField = "clientID";
                ddl_client.DataValueField = "id_client";
                ddl_client.DataBind();
                ddl_client.Items.Insert(0, new ListItem("Clients", String.Empty));
                ddl_client.SelectedIndex = 0;


                ddl_vendor.DataSource = vendor.LlenarComboBox("select * from Vendor");
                ddl_vendor.DataTextField = "vendorID";
                ddl_vendor.DataValueField = "id_vendor";
                ddl_vendor.DataBind();
                ddl_vendor.Items.Insert(0, new ListItem("Vendors", String.Empty));
                ddl_vendor.SelectedIndex = 0;


                ddl_Mfg.DataSource = vendor.LlenarComboBox("select * from MFG");
                ddl_Mfg.DataTextField = "mfg";
                ddl_Mfg.DataValueField = "id_mfg";
                ddl_Mfg.DataBind();
                ddl_Mfg.Items.Insert(0, new ListItem("MFGR", String.Empty));
                ddl_Mfg.SelectedIndex = 0;
            }
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            //if (Page.IsValid)
            //{
            if (ddl_pn.SelectedValue != "")
            {

                ppv.Crud("insert into PPV (av_price, new_price, wo, po, pn, vendor, buyer, qty, client, reason, times, OtherChange, elaborate, leadtime, id_mfg, explanation, salesOrder, salesOrder_num, date_ppv, void) " +
                "values('" + txt_AvPrice.Value + "','" + txt_NewPrice.Value + "','" + txt_WO.Value + "','" + txt_PO.Value + "','" + ddl_pn.SelectedValue + "','" + ddl_vendor.SelectedValue + "','" + Session["id_user"].ToString()
                + "','" + txt_qty.Value + "','" + ddl_client.SelectedValue + "','" + RB_PPVReason.SelectedValue + "','" + Rb_times.SelectedValue + "','" + cbl_changed.SelectedValue
                + "','" + txt_Eraborate.Value + "','" + txt_LeadTime.Value + "','" + ddl_Mfg.SelectedValue + "','" + txt_Explanation.Value.Replace("'","") + "','" + cbl_salesOrder.SelectedValue + "','" + txt_salesOrder.Value + "','" + DateTime.Now + "','0')");



                ClearInputs(Page.Controls);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please select a Part N#!');", true);
            }
            //}
        }

        private void ClearInputs(ControlCollection ctrls)
        {
            txt_AvPrice.Value = "";
            txt_Client.Value = "";
            txt_Eraborate.Value = "";
            txt_Explanation.Value = "";
            txt_LeadTime.Value = "";
            //txt_Mfgr.Value = "";
            txt_MfgrPN.Value = "";
            txt_NewPrice.Value = "";
            txt_pndesc.Value = "";
            txt_AvPrice.Value = "";
            txt_PO.Value = "";
            txt_qty.Value = "";
            txt_salesOrder.Value = "";
            txt_Vendir.Value = "";
            txt_WO.Value = "";

            ddl_client.SelectedIndex = 0;
            ddl_pn.SelectedIndex = 0;
            ddl_vendor.SelectedIndex = 0;
            ddl_Mfg.SelectedIndex = 0;

            cbl_changed.SelectedIndex = -1;
            cbl_salesOrder.SelectedIndex = -1;
            RB_PPVReason.SelectedIndex = -1;
            Rb_times.SelectedIndex = -1;


        }


        protected void ddl_pn_SelectedIndexChanged(object sender, EventArgs e)
            => txt_pndesc.Value = pn.ReturnValue("select pnDesc from PN where id_pn = '" + ddl_pn.SelectedValue + "'");

        //protected void ddl_pn_SelectedIndexChanged1(object sender, EventArgs e)
        //    => txt_pndesc.Value = pn.ReturnValue("select pnDesc from PN where id_pn = '" + ddl_pn.SelectedValue + "'");

        protected void ddl_vendor_SelectedIndexChanged(object sender, EventArgs e)
            => txt_Vendir.Value = vendor.ReturnValue("select vendor from Vendor where id_vendor = '" + ddl_vendor.SelectedValue + "'");

        protected void ddl_client_SelectedIndexChanged(object sender, EventArgs e)
            => txt_Client.Value = client.ReturnValue("select client from Client where id_client = '" + ddl_client.SelectedValue + "'");

        protected void ddl_Mfg_SelectedIndexChanged(object sender, EventArgs e)
            => txt_MfgrPN.Value = mfg.ReturnValue("select mfg_desc from MFG where id_mfg = '" + ddl_Mfg.SelectedValue + "'");

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearInputs(Page.Controls);

        }


    }
}