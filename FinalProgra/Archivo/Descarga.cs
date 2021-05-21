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
       
        //public void ObeterRuta(string ruta)
        //{
        //    SaveFileDialog guardar = new SaveFileDialog() { Filter = "Archivo CSV|*.csv" };
        //    if (guardar.ShowDialog() == true) ruta = guardar.FileName;
        //}

        public void Rellenar(string query, MySqlConnection conn, string ruta)
        {
            MySqlDataAdapter adptador = new MySqlDataAdapter(query, conn);
            DataTable tabla = new DataTable();
            adptador.Fill(tabla);

            List<string> lineas = new List<string>(), columnas = new List<string>();
            foreach (DataColumn col in tabla.Columns) columnas.Add(col.ColumnName);
            lineas.Add(string.Join(";", columnas));

            foreach (DataRow fila in tabla.Rows)
            {
                List<string> celdas = new List<string>();
                foreach (object celda in fila.ItemArray) celdas.Add(celda.ToString());
                lineas.Add(string.Join(";", celdas));

            }
            File.WriteAllLines(ruta, lineas);
            MessageBox.Show($"Archivo guardado correctamente en: {ruta} ");
        }


    }
}
