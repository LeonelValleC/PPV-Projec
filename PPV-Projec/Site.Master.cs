using System;
using System.Drawing;
using System.Linq;
using System.Web.UI;

namespace PPV_Projec
{
    public partial class SiteMaster : MasterPage
    {
        PPVs ppvs = new PPVs();
        User user = new User();
        int countInbox = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                //int _displayTimeInMiliSec = (Session.Timeout - 1) * 60000;
                if (int.Parse(user.GetUser(int.Parse(Session["id_user"].ToString())).ElementAt(0).Level.ToString()) == 3)
                {
                    inbox.HRef = "";
                    lblUser.Text = user.ReturnValue("select name from users where id_user = '" + Session["id_user"].ToString() + "'");

                }
                else
                {
                    if (Session["id_user"] != null)
                    {
                        lblUser.Text = user.ReturnValue("select name from users where id_user = '" + Session["id_user"].ToString() + "'");

                        countInbox = int.Parse(ppvs.ReturnValue("select count(*) from PPV where (first_approval = 0 or first_approval is null) and void != 1 and buyer = '" + Session["id_user"].ToString() + "'"));
                        countInbox += int.Parse(ppvs.ReturnValue("select count(*) from PPV where (first_approval = 1 and salesOrder = 1 and salesOrder_num = '') and void != 1 and buyer = '" + Session["id_user"].ToString() + "'"));

                        notification_count.Text = countInbox.ToString();
                    }
                    else
                    {
                        string script = "alert(\"Login Error!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "Session Expired!", script, true);
                        Response.Redirect("~/Login.aspx", false);

                    }
                }
                if (int.Parse(Session["id_user"].ToString()) == 13)
                    lblUser.ForeColor = Color.Fuchsia;


                ////countInbox = int.Parse(ppvs.ReturnValue("select count(*) from PPV where (first_approval = 0 or first_approval is null or last_approval = 0 or last_approval is null) and void != 1 and buyer = '" + Session["id_user"].ToString() + "'"));
                ////countInbox += int.Parse(ppvs.ReturnValue("select count(*) from PPV where (first_approval = 1 and last_approval = 1 and salesOrder = 1 and salesOrder_num = '') and void != 1 and buyer = '" + Session["id_user"].ToString() + "'"));
            }
            catch (Exception)
            {

                //throw;
                string script = "alert(\"Login Error!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "Session Expired!", script, true);
                Response.Redirect("~/Login.aspx", false);
            }

        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("login.aspx");
        }
    }
}