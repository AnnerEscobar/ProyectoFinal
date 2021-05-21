using FinalProgra.Conexiones;
using FinalProgra.Consultas;
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
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Xsl;
using System.IO;

namespace FinalProgra
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string rutaConexion = "Server = localhost; Database=final; Port = 3306; Username = root;  password = SoyAgente2341;";
        
        


        private void BotonVenta_Click(object sender, RoutedEventArgs e)
        {
            string Correlativo = Texbox1.Text;
            string Nombre = Texbox2.Text;
            string Nit = Texbox3.Text;
            string fecha = Convert.ToDateTime(DatePicker.Text).ToString("yyyy/MM/dd");
            string Marca = Texbox5.Text;
            string Modelo = Texbox6.Text;
            string Precio = Texbox7.Text;
            string Color = Texbox8.Text;

            try
            {
                MySqlConnection conn = new MySqlConnection(rutaConexion);
                conn.Open();
                var sql = $"INSERT INTO registros values({Correlativo},'{Nombre}',{Nit},'{fecha}','{Marca}','{Modelo}',{ Precio},'{Color}')";
                MySqlCommand Createcommand = new MySqlCommand(sql, conn);
                Createcommand.ExecuteNonQuery();

                MySqlDataAdapter dataAdp = new MySqlDataAdapter(Createcommand);
                DataTable dt = new DataTable("registros");
                dataAdp.Fill(dt);
                dataGrid1.ItemsSource = dt.DefaultView;
                dataAdp.Update(dt);
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Venta agregada con exito");
            }
        
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection conectar = new MySqlConnection("Server = localhost; Database=final; Port = 3306; Username = root;  password = SoyAgente2341;");
            conectar.Open();
           
            string query = $"Delete From final.registros where Correlativo = {Eliminar.Text}";
            MySqlCommand Createcommand = new MySqlCommand(query, conectar);
            Createcommand.ExecuteNonQuery();

            MySqlDataAdapter dataAdp = new MySqlDataAdapter(Createcommand);
            DataTable dt = new DataTable("registros");
            dataAdp.Fill(dt);
            dataGrid1.ItemsSource = dt.DefaultView;
            dataAdp.Update(dt);



            conectar.Close();

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string fecha1 = Convert.ToDateTime(Fecha1.Text).ToString("yyyy/MM/dd");
            string fecha2 = Convert.ToDateTime(Fecha2.Text).ToString("yyyy/MM/dd");
            MySqlConnection conectar = new MySqlConnection("Server = localhost; Database=final; Port = 3306; Username = root;  password = SoyAgente2341;");
            conectar.Open();
            string query = $"Select Nombre, Nit, Precio, Marca, Color, Fecha FROM final.registros where Fecha between'{fecha1}' AND '{fecha2}'";
            MySqlCommand Createcommand = new MySqlCommand(query,conectar);
            Createcommand.ExecuteNonQuery();

            MySqlDataAdapter dataAdp = new MySqlDataAdapter(Createcommand);
            DataTable dt = new DataTable("registros");
            dataAdp.Fill(dt);
            dataGrid1.ItemsSource = dt.DefaultView;
            dataAdp.Update(dt);
            conectar.Close();

        }



        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection conectar = new MySqlConnection("Server = localhost; Database=final; Port = 3306; Username = root;  password = SoyAgente2341;");
            conectar.Open();

            string query = $"Update final.registros SET Nombre ='{TxtActualizacion.Text}' where Correlativo = {Eliminar.Text}";
            MySqlCommand Createcommand = new MySqlCommand(query, conectar);
            Createcommand.ExecuteNonQuery();

            MySqlDataAdapter dataAdp = new MySqlDataAdapter(Createcommand);
            DataTable dt = new DataTable("registros");
            dataAdp.Fill(dt);
            dataGrid1.ItemsSource = dt.DefaultView;
            dataAdp.Update(dt);
            conectar.Close();
        }

        private void btnCargarB_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection conectar = new MySqlConnection("Server = localhost; Database=final; Port = 3306; Username = root;  password = SoyAgente2341;");
            conectar.Open();

            string query = "Select *from final.registros";
            MySqlCommand Createcommand = new MySqlCommand(query, conectar);
            Createcommand.ExecuteNonQuery();

            MySqlDataAdapter dataAdp = new MySqlDataAdapter(Createcommand);
            DataTable dt = new DataTable("registros");
            dataAdp.Fill(dt);
            dataGrid1.ItemsSource = dt.DefaultView;
            dataAdp.Update(dt);

            conectar.Close();
        }

        private void btnDescargar_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog() { Filter = "Archivo CSV|*.csv" };
            if (guardar.ShowDialog() == true) TtxRuta.Text = guardar.FileName;

            MySqlConnection conectar = new MySqlConnection("Server = localhost; Database=final; Port = 3306; Username = root;  password = SoyAgente2341;");
            conectar.Open();
            MySqlDataAdapter adptador = new MySqlDataAdapter("select *from final.registros ",conectar);
            DataTable tabla = new DataTable();
            adptador.Fill(tabla);

            List<string> lineas = new List<string>(), columnas = new List<string>();
            foreach (DataColumn col in tabla.Columns) columnas.Add(col.ColumnName);
            lineas.Add(string.Join(";", columnas));
            
            foreach(DataRow fila in tabla.Rows)
            {
                List<string> celdas = new List<string>();
                foreach (object celda in fila.ItemArray) celdas.Add(celda.ToString());
                    lineas.Add(string.Join(";", celdas));
                
            }
            File.WriteAllLines(TtxRuta.Text, lineas);
            MessageBox.Show($"Archivo guardado correctamente en: {TtxRuta} ");

            conectar.Close();


        }
    }
}
    

