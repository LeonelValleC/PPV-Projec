namespace PPV_Projec
{
    public class PartN : Conexion
    {
        int id_pn;
        string pn;
        string pnDesc;

        public int Id_pn { get => id_pn; set => id_pn = value; }
        public string Pn { get => pn; set => pn = value; }
        public string PnDesc { get => pnDesc; set => pnDesc = value; }
    }
}