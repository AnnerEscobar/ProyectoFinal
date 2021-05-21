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
       public void Consultas(MySqlConnection conn, string query, DataGrid dataGrid1 )//Funcion que ejecuta la consulta
        {

            MySqlCommand Createcommand = new MySqlCommand(query, conn);//Crea un comando conn la conexion y el query para hacer la consulta
            Createcommand.ExecuteNonQuery();//ejecuta la consulta

            MySqlDataAdapter dataAdp = new MySqlDataAdapter(Createcommand);//adapata la consulta
            DataTable dt = new DataTable();//Creamos un datatable
            dataAdp.Fill(dt);
            dataGrid1.ItemsSource = dt.DefaultView;//agregamos el contenido del datatable al datagrid
            dataAdp.Update(dt);//actualiza el contenido

        }
       
    }
}
