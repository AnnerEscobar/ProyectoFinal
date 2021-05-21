using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinalProgra.Archivo
{
    class Descarga
    {
       

        public void Rellenar(string query, MySqlConnection conn, string ruta)//Recibe tres parametros la consulta, la conexion y la ruta donde se guardara
        {
            MySqlDataAdapter adptador = new MySqlDataAdapter(query, conn);
            DataTable tabla = new DataTable();
            adptador.Fill(tabla);//EStas tres lineas agregan el contenido de la consulta a un datatable el cual aun no podremos visualizar

            List<string> lineas = new List<string>(), columnas = new List<string>();
            foreach (DataColumn col in tabla.Columns) columnas.Add(col.ColumnName);
            lineas.Add(string.Join(";", columnas));//Con estas tres lineas creamos un list para guardar los encabezados y los guardamos, establecemos el separador en este caso ;

            foreach (DataRow fila in tabla.Rows)
            {
                List<string> celdas = new List<string>();
                foreach (object celda in fila.ItemArray) celdas.Add(celda.ToString());
                lineas.Add(string.Join(";", celdas));//Con este foreach obtenemos las filas y los guardamos en un estring con delimitador ;

            }
            File.WriteAllLines(ruta, lineas);//Guardamos todas las lineas en la ruta creando asi el archivo csv
            MessageBox.Show($"Archivo guardado correctamente en: {ruta} ");
        }


    }
}
