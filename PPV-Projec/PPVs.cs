using System.Data;

namespace PPV_Projec
{
    public class PPVs : Conexion
    {
        static int id_ppv;
        private decimal av_price;
        private decimal new_price;
        private int vendorID;
        private string vendor;
        private int buyer;
        private int clientID;
        private string client;
        private string reason;
        private string times;
        private bool otherChange;
        private string elaborate;
        private string leadtime;
        private string mfgr_name;
        private string mfgr_pn;
        private string explanation;
        private decimal change_unit;
        private int change_unit_perc;
        private decimal current_total;
        private decimal new_total;
        private decimal total_increase;
        private int first_auth;
        private int last_auth;
        private string first_approval;

        static DataTable dt;


        public int Id_ppv { get => id_ppv; set => id_ppv = value; }
        public decimal Av_price { get => av_price; set => av_price = value; }
        public decimal New_price { get => new_price; set => new_price = value; }
        public int VendorID { get => vendorID; set => vendorID = value; }
        public string Vendor { get => vendor; set => vendor = value; }
        public int Buyer { get => buyer; set => buyer = value; }
        public int ClientID { get => clientID; set => clientID = value; }
        public string Client { get => client; set => client = value; }
        public string Reason { get => reason; set => reason = value; }
        public string Times { get => times; set => times = value; }
        public bool OtherChange { get => otherChange; set => otherChange = value; }
        public string Elaborate { get => elaborate; set => elaborate = value; }
        public string Leadtime { get => leadtime; set => leadtime = value; }
        public string Mfgr_name { get => mfgr_name; set => mfgr_name = value; }
        public string Mfgr_pn { get => mfgr_pn; set => mfgr_pn = value; }
        public string Explanation { get => explanation; set => explanation = value; }
        public decimal Change_unit { get => change_unit; set => change_unit = value; }
        public int Change_unit_perc { get => change_unit_perc; set => change_unit_perc = value; }
        public decimal Current_total { get => current_total; set => current_total = value; }
        public decimal New_total { get => new_total; set => new_total = value; }
        public decimal Total_increase { get => total_increase; set => total_increase = value; }
        public int First_auth { get => first_auth; set => first_auth = value; }
        public int Last_auth { get => last_auth; set => last_auth = value; }
        public string First_approval { get => first_approval; set => first_approval = value; }
        public DataTable Dt { get => dt; set => dt = value; }
    }
}