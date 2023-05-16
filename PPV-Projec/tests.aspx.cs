using System;
using System.Web.UI.WebControls;

namespace PPV_Projec
{
    public partial class tests : System.Web.UI.Page
    {
        PPVs ppv = new PPVs();
        User user = new User();
        PartN pn = new PartN();
        Vendor vendor = new Vendor();
        Clients client = new Clients();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ddl_client.DataSource = client.LlenarComboBox("select * from Client");
                ddl_client.DataTextField = "clientID";
                ddl_client.DataValueField = "id_client";
                ddl_client.DataBind();
                ddl_client.Items.Insert(0, new ListItem("Clients", String.Empty));
                ddl_client.SelectedIndex = 0;

                ddl_pn.DataSourceID = SqlDataSource1.ID;
                ddl_pn.Items.Insert(0, new ListItem("Part N#", String.Empty));
                ddl_pn.SelectedIndex = 0;

                ddl_vendor.DataSource = vendor.LlenarComboBox("select * from Vendor");
                ddl_vendor.DataTextField = "vendorID";
                ddl_vendor.DataValueField = "id_vendor";
                ddl_vendor.DataBind();
                ddl_vendor.Items.Insert(0, new ListItem("Vendors", String.Empty));
                ddl_vendor.SelectedIndex = 0;
            }
        }


        protected void ddl_pn_SelectedIndexChanged(object sender, EventArgs e)
            => txt_pndesc.Value = pn.ReturnValue("select pnDesc from PN where id_pn = '" + ddl_pn.SelectedValue + "'");

        protected void ddl_vendor_SelectedIndexChanged(object sender, EventArgs e)
            => txt_Vendir.Value = vendor.ReturnValue("select vendor from Vendor where id_vendor = '" + ddl_vendor.SelectedValue + "'");

        protected void ddl_client_SelectedIndexChanged(object sender, EventArgs e)
        => txt_Client.Value = client.ReturnValue("select client from Client where id_client = '" + ddl_client.SelectedValue + "'");
    }
}