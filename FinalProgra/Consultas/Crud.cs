using FinalProgra.Conexiones;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FinalProgra.Consultas
{
    class Crud
    {

        public void CagarCompra(string crud)
        {
            MySqlConnection conn = new MySqlConnection("Server = localhost; Database=final; Port = 3306; Username = root;  password = SoyAgente2341;");
            conn.Open();
            var sql = crud;
            var cmd = new MySqlCommand();
            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;
            conn.Close();
        }
    }
}
