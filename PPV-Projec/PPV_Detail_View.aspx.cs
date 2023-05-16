using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

namespace PPV_Projec
{
    public partial class PPV_Detail_View : System.Web.UI.Page
    {
        PPVs ppv = new PPVs();
        User user = new User();
        PartN pn = new PartN();
        Vendor vendor = new Vendor();
        Clients client = new Clients();
        MFGR mfg = new MFGR();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["id_user"].ToString() != user.ReturnID("select buyer from PPV where id_ppv = '" + ppv.Id_ppv + "'").ToString() && int.Parse(user.GetUser(int.Parse(Session["id_user"].ToString())).ElementAt(0).Level.ToString()) != 1)
                {
                    btn_Submit.Visible = false;


                }

                ddl_client.DataSource = client.LlenarComboBox("select * from Client");
                ddl_client.DataTextField = "clientID";
                ddl_client.DataValueField = "id_client";
                ddl_client.DataBind();
                ddl_client.Items.Insert(0, new ListItem("Clients", String.Empty));
                ddl_client.SelectedIndex = 0;

                DataClasses1DataContext dcc = new DataClasses1DataContext();
                var ddquery = (from dd in dcc.PNs select dd).Distinct().ToList();

                ddl_pn.DataSource = ddquery;
                //ddl_pn.DataSource = ppv.LlenarComboBox("select * from PN where pn like '" + ddl_pn.Text + "%'");
                ddl_pn.DataTextField = "pn1";
                ddl_pn.DataValueField = "id_pn";
                ddl_pn.DataBind();
                ddl_pn.Items.Insert(0, new ListItem("Part N#", String.Empty));
                ddl_pn.SelectedIndex = 0;


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

                FillDetail();
            }
        }

        private void FillDetail()
        {
            //try
            //{
            //SqlDataReader leer = ppv.Leer("select users.name, wo, po, pn, pn_desc, qty, av_price, new_price, vendorID, vendor, client, clientID, reason, times, OtherChange, elaborate, leadtime, mfgr_name,mfgr_pn, explanation, change_unit, change_unit_perc, current_total, current_total, new_total, total_increase from PPV join users on ppv.buyer = users.id_user where id_ppv = '" + ppv.Id_ppv + "'");
            SqlDataReader leer = ppv.Leer("select salesOrder as 'so' ,users.name, wo, po, PN.pn, PN.id_pn, PN.pnDesc, qty, av_price, new_price, salesOrder_num, Vendor.vendor, Vendor.vendorID, Vendor.id_vendor, Client.client, Client.clientID, Client.id_client,reason, times, OtherChange, elaborate, leadtime, MFG.mfg, MFG.mfg_desc, MFG.id_mfg,explanation, change_unit, change_unit_perc, current_total, current_total, new_total, total_increase, first_approval,note from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor left join MFG on MFG.id_mfg = PPV.id_mfg where id_ppv = '" + ppv.Id_ppv + "'");

            if (leer.Read() == true)
            {
                //string so = Convert.ToInt32(Convert.ToBoolean(leer["so"].ToString())).ToString();
                rb_salesOrder.SelectedValue = Convert.ToInt32(Convert.ToBoolean(leer["so"].ToString())).ToString();

                txt_AvPrice.Value = leer["av_price"].ToString();
                ddl_client.SelectedValue = leer["id_client"].ToString();
                txt_Eraborate.Value = leer["elaborate"].ToString();
                txt_Explanation.Value = leer["explanation"].ToString();
                txt_LeadTime.Value = leer["leadtime"].ToString();
                txt_NewPrice.Value = leer["new_price"].ToString();

                ddl_pn.SelectedValue = leer["id_pn"].ToString();
                ddl_Mfg.SelectedValue = leer["id_mfg"].ToString();
                txt_PO.Value = leer["po"].ToString();
                txt_qty.Value = leer["qty"].ToString();
                ddl_vendor.SelectedValue = leer["id_vendor"].ToString();
                txt_WO.Value = leer["wo"].ToString();

                txt_salesOrder.Value = leer["salesOrder_num"].ToString();

                //CheckBoxList1.SelectedValue = leer["so"].ToString();

                txt_currentTotal.Value = leer["current_total"].ToString();
                txt_newTotal.Value = leer["new_total"].ToString();

                txt_TotalIncrease.Value = leer["total_increase"].ToString();

                if (double.Parse(txt_TotalIncrease.Value) < 0)
                    txt_TotalIncrease.Style.Value = "background-color: lightgreen;";


                txt_chagePerc.Value = leer["change_unit_perc"].ToString();
                txt_change.Value = leer["change_unit"].ToString();
                RB_PPVReason.SelectedValue = leer["reason"].ToString();
                Rb_times.SelectedValue = leer["times"].ToString();
                cbl_changed.SelectedValue = leer["OtherChange"].ToString();
                ddl_Mfg.SelectedValue = leer["id_mfg"].ToString();


                txt_pndesc.Value = pn.ReturnValue("select pnDesc from PN where id_pn = '" + ddl_pn.SelectedValue + "'");
                txt_Vendir.Value = vendor.ReturnValue("select vendor from Vendor where id_vendor = '" + ddl_vendor.SelectedValue + "'");
                txt_Client.Value = client.ReturnValue("select client from Client where id_client = '" + ddl_client.SelectedValue + "'");
                txt_MfgrPN.Value = mfg.ReturnValue("select mfg from MFG where id_mfg = '" + ddl_Mfg.SelectedValue + "'");
                txt_Note.Value = leer["note"].ToString();
            }
            else
            {
                txt_AvPrice.Value = "";
                txt_MfgrPN.Value = "";
                //txt_Buyer.Value = "";
                txt_chagePerc.Value = "";
                txt_change.Value = "";
                txt_Client.Value = "";
                //txt_ClientID.Value = "";
                txt_currentTotal.Value = "";
                txt_Eraborate.Value = "";
                txt_Explanation.Value = "";
                txt_LeadTime.Value = "";
                //txt_Mfgr.Value = "";
                txt_MfgrPN.Value = "";
                txt_NewPrice.Value = "";
                txt_newTotal.Value = "";
                //txt_pn.Value = "";
                txt_pndesc.Value = "";
                txt_PO.Value = "";
                txt_qty.Value = "";
                txt_TotalIncrease.Value = "";
                txt_Vendir.Value = "";
                //txt_Vendor.Value = "";
                txt_WO.Value = "";
                RB_PPVReason.SelectedIndex = -1;
                Rb_times.SelectedIndex = -1;
                cbl_changed.SelectedIndex = -1;

            }
            ppv.Cerrar();
            //}
            //catch (System.InvalidOperationException)
            //{
            //    ppv.Cerrar();
            //    //throw;
            //}


        }


        protected void btn_Submit_Click(object sender, EventArgs e)
        {

            ppv.Crud("update PPV set first_approval = NULL, wo = '" + txt_WO.Value + "', po = '" + txt_PO.Value + "', qty = '" + txt_qty.Value + "', av_price = '" + txt_AvPrice.Value + "', new_price = '" + txt_NewPrice.Value + "', OtherChange = '" + cbl_changed.SelectedValue + "', elaborate = '" + txt_Eraborate.Value +  "', id_mfg = '" + ddl_Mfg.SelectedValue + "', explanation = '" + txt_Explanation.Value + "', client = '" + ddl_client.SelectedValue + "', salesOrder = '" + rb_salesOrder.SelectedValue + "', salesOrder_num = '" + txt_salesOrder.Value + "' where id_ppv = '" + ppv.Id_ppv + "'");
            Response.Redirect("MainMenu.aspx");

        }

        protected void ddl_pn_SelectedIndexChanged(object sender, EventArgs e)
            => txt_pndesc.Value = pn.ReturnValue("select pnDesc from PN where id_pn = '" + ddl_pn.SelectedValue + "'");

        protected void ddl_vendor_SelectedIndexChanged(object sender, EventArgs e)
            => txt_Vendir.Value = vendor.ReturnValue("select vendor from Vendor where id_vendor = '" + ddl_vendor.SelectedValue + "'");

        protected void ddl_client_SelectedIndexChanged(object sender, EventArgs e)
            => txt_Client.Value = client.ReturnValue("select client from Client where id_client = '" + ddl_client.SelectedValue + "'");

        protected void ddl_Mfg_SelectedIndexChanged(object sender, EventArgs e)
            => txt_MfgrPN.Value = mfg.ReturnValue("select mfg_desc from MFG where id_mfg = '" + ddl_Mfg.SelectedValue + "'");
    }
}