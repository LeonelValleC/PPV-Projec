using System;
using System.Linq;
using System.Web.UI;

namespace PPV_Projec
{
    public partial class MainMenu : System.Web.UI.Page
    {
        User user = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (int.Parse(user.GetUser(int.Parse(Session["id_user"].ToString())).ElementAt(0).Level.ToString()) == 3)
                    {

                        ppv.Visible = false;
                        inbox.Visible = false;
                        approval.Visible = false;


                    }
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
    }
}