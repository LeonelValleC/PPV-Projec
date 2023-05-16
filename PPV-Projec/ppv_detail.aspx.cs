using System;
using System.Data.SqlClient;

namespace PPV_Projec
{
    public partial class ppv_detail : System.Web.UI.Page
    {
        PPVs ppv = new PPVs();
        //User user = new User();

        protected void Page_Load(object sender, EventArgs e)
        {
            //filtro = ppv.LlenarDG("select * from PPV where id_ppv = '" + ppv.Id_ppv + "'").Tables[0];

            //CreateReport();

            if (!Page.IsPostBack)
            {
                FillDetail();

            }


        }

        private void FillDetail()
        {
            try
            {
                //SqlDataReader leer = ppv.Leer("select users.name, wo, po, pn, pn_desc, qty, av_price, new_price, vendorID, vendor, client, clientID, reason, times, OtherChange, elaborate, leadtime, mfgr_name,mfgr_pn, explanation, change_unit, change_unit_perc, current_total, current_total, new_total, total_increase from PPV join users on ppv.buyer = users.id_user where id_ppv = '" + ppv.Id_ppv + "'");
                SqlDataReader leer = ppv.Leer("select users.name, wo,salesOrder_num, salesOrder, po, PN.pn, PN.pnDesc, qty, av_price, new_price, note,Vendor.vendor, Vendor.vendorID, Client.client, Client.clientID,reason, times, OtherChange, elaborate, leadtime, MFG.mfg, MFG.mfg_desc ,explanation, change_unit, change_unit_perc, current_total, current_total, new_total, total_increase, first_approval from PPV join users on ppv.buyer = users.id_user left join PN on PN.id_pn = PPV.pn left join Client on Client.id_client = PPV.client left join Vendor on Vendor.id_vendor = PPV.vendor left join MFG on MFG.id_mfg = PPV.id_mfg where id_ppv = '" + ppv.Id_ppv + "'");

                if (leer.Read() == true)
                {
                    txt_AvPrice.Value = leer["av_price"].ToString();
                    txt_Buyer.Value = leer["name"].ToString();
                    txt_Client.Value = leer["client"].ToString();
                    txt_ClientID.Value = leer["clientID"].ToString();
                    txt_Eraborate.Value = leer["elaborate"].ToString();
                    txt_Explanation.Value = leer["explanation"].ToString();
                    txt_LeadTime.Value = leer["leadtime"].ToString();
                    txt_Mfgr.Value = leer["mfg"].ToString();
                    txt_MfgrPN.Value = leer["mfg_desc"].ToString();
                    txt_NewPrice.Value = leer["new_price"].ToString();
                    txt_pn.Value = leer["pn"].ToString();
                    txt_pndesc.Value = leer["pnDesc"].ToString();
                    txt_PO.Value = leer["po"].ToString();
                    txt_qty.Value = leer["qty"].ToString();
                    txt_Vendir.Value = leer["vendorID"].ToString();
                    txt_Vendor.Value = leer["vendor"].ToString();
                    txt_WO.Value = leer["wo"].ToString();
                    txt_salesOrder.Value = leer["salesOrder_num"].ToString();


                    txt_currentTotal.Value = leer["current_total"].ToString();
                    txt_newTotal.Value = leer["new_total"].ToString();
                    txt_TotalIncrease.Value = leer["total_increase"].ToString();
                    txt_chagePerc.Value = leer["change_unit_perc"].ToString();
                    txt_change.Value = leer["change_unit"].ToString();
                    txt_Note.Value = leer["note"].ToString();

                    RB_PPVReason.SelectedValue = leer["reason"].ToString();
                    Rb_times.SelectedValue = leer["times"].ToString();
                    cbl_changed.SelectedValue = leer["OtherChange"].ToString();
                    cbl_salesOrder.SelectedValue = Convert.ToInt32(Convert.ToBoolean(leer["salesOrder"].ToString())).ToString();

                    if (double.Parse(txt_TotalIncrease.Value) < 0)
                        txt_TotalIncrease.Style.Value = "background-color: lightgreen;";

                    //ppv.First_approval = leer["first_approval"].ToString();

                }
                else
                {
                    txt_salesOrder.Value = "";
                    txt_AvPrice.Value = "";
                    txt_Buyer.Value = "";
                    txt_chagePerc.Value = "";
                    txt_change.Value = "";
                    txt_Client.Value = "";
                    txt_ClientID.Value = "";
                    txt_currentTotal.Value = "";
                    txt_Eraborate.Value = "";
                    txt_Explanation.Value = "";
                    txt_LeadTime.Value = "";
                    txt_Mfgr.Value = "";
                    txt_MfgrPN.Value = "";
                    txt_NewPrice.Value = "";
                    txt_newTotal.Value = "";
                    txt_pn.Value = "";
                    txt_pndesc.Value = "";
                    txt_PO.Value = "";
                    txt_qty.Value = "";
                    txt_TotalIncrease.Value = "";
                    txt_Vendir.Value = "";
                    txt_Vendor.Value = "";
                    txt_WO.Value = "";
                    RB_PPVReason.SelectedIndex = -1;
                    Rb_times.SelectedIndex = -1;
                    cbl_changed.SelectedIndex = -1;

                }
                ppv.Cerrar();
            }
            catch (System.InvalidOperationException)
            {
                ppv.Cerrar();
                //throw;
            }


        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ppv.Crud("update PPV set first_auth = '" + Session["id_user"].ToString() + "', first_date= '" + DateTime.Now + "', first_approval='" + true + "', note= '" + txt_Note.Value + "', salesOrder_num= '" + txt_salesOrder.Value + "', salesOrder= '1' where id_ppv = '" + ppv.Id_ppv + "'");
                Response.Write("<script>alert('PPV Approved')</script>");
                Response.Redirect("MainMenu.aspx");
            }
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (!string.IsNullOrEmpty(txt_Note.Value))
                {
                    ppv.Crud("update PPV set first_auth = '" + Session["id_user"].ToString() + "', first_date= '" + DateTime.Now + "', first_approval='" + false + "', note= '" + txt_Note.Value + "' where id_ppv = '" + ppv.Id_ppv + "'");

                    Response.Write("<script>alert('PPV Decline')</script>");
                    Response.Redirect("MainMenu.aspx");
                }
                else
                {
                    txt_Note.Focus();
                    RequiredFieldValidator1.Enabled = true;

                }

            }



        }
    }
}



