using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ExMySql
{
    public class AcessoDados
    {
        public static MySqlConnection Conectar()
        {

            MySqlConnection c = new MySqlConnection("Server=localhost;Database=udemy;Uid=root;Pwd=");
            c.Open();

            return c;
        }
    }
}
