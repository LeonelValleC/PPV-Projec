using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PPV_Projec
{
    public class User : Conexion
    {
        //User user = new User();

        int id_user;
        string name;
        string email;
        string username;
        string password;
        int level;
        private int id;

        public User()
        {
        }

         public User( string name, string email, string username, string password, int id, int levels)
        {
            this.name = name;
            this.email = email;
            this.username = username;
            this.password = password;
            this.id = id;
            this.level = levels;
        }

        //public int Id_user { get => id_user; set => id_user = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int Level { get => level; set => level = value; }


        public bool Login(string user, string password)
        {
            return (id_user = ReturnID("select id_user from users where username = '" + user + "' and password = '" + password + "'")) > 0;
        }

        public List<User> GetUser(int getid)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select name, email, username, password, id, id_level from users where id_user = " + getid);
            //sql.Append("   FROM Customer ");

            DataTable dt = LlenarDG(sql.ToString()).Tables[0];

            return MakeCustomers(dt);
        }

        private List<User> MakeCustomers(DataTable dt)
        {
            List<User> list = new List<User>();
            foreach (DataRow row in dt.Rows)
                list.Add(MakeCustomer(row));

            return list;
        }

        private User MakeCustomer(DataRow row)
        {
            string name = (row["name"].ToString());
            string email = row["email"].ToString();
            string username = row["username"].ToString();
            string password = row["password"].ToString();
            int id = int.Parse(row["id"].ToString());
            int level = int.Parse(row["id_level"].ToString());

            return new User(name, email, username, password, id, level);
        }
    }
}