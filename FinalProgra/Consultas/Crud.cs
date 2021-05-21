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

        public void CagarCompra(string sql,MySqlConnection conn )//Insericion de la venta realizada le mandamos como parametro la conexion y el string con la consulta
        {
            MySqlCommand Createcommand = new MySqlCommand(sql, conn);//crea el comando para el insert
            Createcommand.ExecuteNonQuery();//ejecuta la consutla
        }
    }
}
