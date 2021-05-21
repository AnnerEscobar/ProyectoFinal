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
using FinalProgra.Conexiones;

namespace FinalProgra.Consultas
{
    class Consulta
    {
       public void Consultas(MySqlConnection conn, string query, DataGrid dataGrid1 )
        {

            MySqlCommand Createcommand = new MySqlCommand(query, conn);
            Createcommand.ExecuteNonQuery();

            MySqlDataAdapter dataAdp = new MySqlDataAdapter(Createcommand);
            DataTable dt = new DataTable("registros");
            dataAdp.Fill(dt);
            dataGrid1.ItemsSource = dt.DefaultView;
            dataAdp.Update(dt);

        }
       
    }
}
