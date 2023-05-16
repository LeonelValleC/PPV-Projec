using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI;

namespace PPV_Projec
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        [WebMethod]
        public static List<string> GetEmployeeName(string empName)
        {

            Conexion con = new Conexion();
            List<string> empResult = new List<string>();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select Top 10 pn from PN where where pn LIKE ''+@SearchEmpName+'%'";
                cmd.Connection = con.Con1;
                con.Abrir();
                cmd.Parameters.AddWithValue("@SearchEmpName", empName);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    empResult.Add(dr["pn"].ToString());
                }
                con.Cerrar();
                return empResult;
            }

        }
    }
}