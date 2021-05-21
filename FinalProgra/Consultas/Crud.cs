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

        public void CagarCompra(string sql,MySqlConnection conn )
        {
            MySqlCommand Createcommand = new MySqlCommand(sql, conn);
            Createcommand.ExecuteNonQuery();
        }
    }
}
