using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PPV_Projec
{
    public partial class Maintenance : System.Web.UI.Page
    {
        Clients clients = new Clients();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnUpload_OnClick(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string connectionstring = "";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string fileextension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                string filelocation = HostingEnvironment.ApplicationPhysicalPath + filename;
                FileUpload1.SaveAs(filelocation);
                if (fileextension == ".xlsx")
                {
                    connectionstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filelocation + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=2\"";
                    OleDbConnection conn = new OleDbConnection(connectionstring);
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select * from [Sheet1$]";
                    cmd.Connection = conn;
                    OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    oleDbDataAdapter.Fill(dataTable);
                    Gridview1.DataSource = dataTable;
                    Gridview1.DataBind();
                }
            }
            else
            {
                BtnUpload.Attributes.Add("OnClientClick", "javascript:alert('Please Select an Excel file');");
                Gridview1.DataSource = null;
                Gridview1.DataBind();
            }
            FileUpload1.Attributes.Clear();
        }

        protected void BtnloadtoDB_Click(object sender, EventArgs e)
        {
            bool ValidateAC = false;

            if (Gridview1.Rows.Count != 0)
            {

                DataTable dt = new DataTable();
                dt.Columns.Add("ac", typeof(string));

                foreach (GridViewRow gvrow in Gridview1.Rows)
                {
                    string acs = gvrow.Cells[0].Text;

                    if (!clients.Existe("select count(*) from Client where clientID = '" + acs.Trim() + "'"))
                    {
                        dt.Rows.Add(acs);

                    }
                    else
                    {
                        ValidateAC = true;
                        break;

                    }

                }

                if (ValidateAC == false)
                {
                    //ExistAccessCode(dt);

                }
                else
                {
                    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Access Codes already upload!\nPlease check the file!');", true);
                    string script = "alert(\"WARNINIG !\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Access Codes already exists!", script, true);
                }

            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No data Uploaded')", true);

        }
    }
}
