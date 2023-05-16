namespace PPV_Projec
{
    public class Clients : Conexion
    {
        int id_client;
        string client;
        string clientID;

        public int Id_client { get => id_client; set => id_client = value; }
        public string Client { get => client; set => client = value; }
        public string ClientID { get => clientID; set => clientID = value; }
    }
}