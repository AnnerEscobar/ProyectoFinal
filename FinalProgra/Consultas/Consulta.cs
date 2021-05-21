using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace FinalProgra.Consultas
{
    class Consulta
    {
        public DataSet dsTabla = new DataSet();
        //public void Consultas(string consulta, MySqlConnection conexion, DataGrid data)
        //{
        //    conexion.Open();
        //    MySqlCommand comando = new MySqlCommand(consulta, conexion);
        //    MySqlDataAdapter data = new MySqlDataAdapter(comando);
        //    DataTable tabla = new DataTable();
        //    data.Fill(tabla);
        //    textBox.Text = Convert.ToString(tabla);
        //    conexion.Close();

        //}
    }
}
