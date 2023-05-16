namespace PPV_Projec
{
    public class Vendor : Conexion
    {
        int id_vendor;
        string vendors;
        string vendorID;

        public int Id_vendor { get => id_vendor; set => id_vendor = value; }
        public string Vendors { get => vendors; set => vendors = value; }
        public string VendorID { get => vendorID; set => vendorID = value; }
    }
}