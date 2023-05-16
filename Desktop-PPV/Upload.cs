using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Desktop_PPV
{
    public partial class Upload : Form
    {
        //Test test = new Test();
        Conexion con = new Conexion();
        public Upload()
        {
            InitializeComponent();
        }

        private void Upload_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("pn", "pn");
            dataGridView1.Columns.Add("pnDesc", "pnDesc");
        }

        private void btn_Ingresar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {

                try
                {

                    //int id = con.ReturnID("select top 1 id_client from Client where clientID = '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "' order by id_client asc");


                    //con.Crud("delete Client where id_client = '" + id + "'");

                    //if (!con.Existe("select count(*) from PN where pn = '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'"))
                    //if (!con.Existe("select count(*) from Vendor where vendorID = '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'"))
                    //if (!con.Existe("select count(*) from MFG where mfg = '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'"))
                        if (!con.Existe("select count(*) from Client where clientID = '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'"))
                        {
                        //test.sn = dataGridView1.Rows[i].Cells[0].Value.ToString().Substring(dataGridView1.Rows[i].Cells[0].Value.ToString().Trim().Length - 4);

                        //con.Crud("insert into PN values('" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "')");
                        //con.Crud("insert into Vendor values('" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "')");
                        //con.Crud("insert into MFG values('" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "')");
                        con.Crud("insert into Client values('" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "')");
                        //MessageBox.Show(i+"!");

                    }
                }
                catch (System.Data.SqlClient.SqlException) { }
                //catch (System.NullReferenceException) { }
                //test.Crud("insert into test(cp_sin, cp_imei, cp_mac, nuc_sn, nuc_mac, mediabox_sn, result, test_time) values('" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[1].Value + "','" + dataGridView1.Rows[i].Cells[2].Value + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value + "','" + dataGridView1.Rows[i].Cells[5].Value + "','" + dataGridView1.Rows[i].Cells[6].Value + "','" + dataGridView1.Rows[i].Cells[7].Value + "')");


            }
            MessageBox.Show("Upload Completed!");



        }

        private void btn_Paste_Click(object sender, EventArgs e)
        {

            DataObject o = (DataObject)Clipboard.GetDataObject();
            if (o.GetDataPresent(DataFormats.Text))
            {
                if (dataGridView1.RowCount > 0)
                    dataGridView1.Rows.Clear();

                if (dataGridView1.ColumnCount > 0)
                    dataGridView1.Columns.Clear();

                bool columnsAdded = false;
                string[] pastedRows = Regex.Split(o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
                foreach (string pastedRow in pastedRows)
                {
                    string[] pastedRowCells = pastedRow.Split(new char[] { '\t' });

                    if (!columnsAdded)
                    {
                        for (int i = 0; i < pastedRowCells.Length; i++)
                            dataGridView1.Columns.Add("col" + i, pastedRowCells[i]);

                        columnsAdded = true;
                        continue;
                    }

                    dataGridView1.Rows.Add();
                    int myRowIndex = dataGridView1.Rows.Count - 1;

                    using (DataGridViewRow myDataGridViewRow = dataGridView1.Rows[myRowIndex])
                    {
                        for (int i = 0; i < pastedRowCells.Length; i++)
                            myDataGridViewRow.Cells[i].Value = pastedRowCells[i];
                    }
                }
            }

        }


        private void Paste()
        {
            string s = Clipboard.GetText();

            string[] lines = s.Replace("\n", "").Split('\r');
            if (lines.Length == 1)
            {
                dataGridView1.Rows.Add(lines.Length);

            }
            else
            {
                dataGridView1.Rows.Add(lines.Length - 1);

            }
            string[] fields;
            int row = 0;
            int col = 0;

            foreach (string item in lines)
            {
                fields = item.Split('\t');
                foreach (string f in fields)
                {
                    Console.WriteLine(f);
                    dataGridView1[col, row].Value = f;
                    col++;
                }
                row++;
                col = 0;
            }
        }

        private void btn_Claer_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }
    }
}
