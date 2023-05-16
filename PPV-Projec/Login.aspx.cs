using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace PPV_Projec
{
    public partial class Login : System.Web.UI.Page
    {

        User user = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["username"] = null;
                Session.Abandon();
                //Session.Clear();
                //FormsAuthentication.SignOut();

            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
           
            if (user.Login(txtUsuario.Value, txtPassword.Value))
            {
                
                Session["username"] = txtUsuario.Value;
                Session["id_user"] = user.ReturnID("select id_user from users where username = '" + txtUsuario.Value.Trim() + "' and password = '" + txtPassword.Value.Trim() + "'");

                Response.Redirect("~/MainMenu.aspx", false);
            }
            else
            {
                string script = "alert(\"Login Error!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "User or Password incorrect!", script, true);
            }

        }
    }
}