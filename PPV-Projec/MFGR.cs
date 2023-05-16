namespace PPV_Projec
{
    public class MFGR : Conexion
    {
        int id_mfg;
        string mfg;
        string desc;

        public int Id_mfg { get => id_mfg; set => id_mfg = value; }
        public string Mfg { get => mfg; set => mfg = value; }
        public string Desc { get => desc; set => desc = value; }
    }
}