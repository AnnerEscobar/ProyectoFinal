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
using FinalProgra.Archivo;

namespace FinalProgra
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Consulta Consultas = new Consulta();//Variable de tipo Consulta para ejecurtar las diferentes consultas
        MySqlConnection conectar = new MySqlConnection("Server = localhost; Database=final; Port = 3306; Username = root;  password = SoyAgente2341;");//Ruta de conexion para acceder a la base de datos

        

        private void BotonVenta_Click(object sender, RoutedEventArgs e)//Boton que ejecuta el insert de una nueva venta
        {
            try
            {
                string fecha = Convert.ToDateTime(DatePicker.Text).ToString("yyyy/MM/dd");//string que contiene la fecha que se extrae del texbox y se convierte al formato aceptado por Mysql
                conectar.Open();
                var sql = $"INSERT INTO registros values({Texbox1.Text},'{Texbox2.Text}',{Texbox3.Text},'{fecha}','{Texbox5.Text}','{Texbox6.Text}',{Texbox7.Text},'{Texbox8.Text}')";
                Crud insert = new Crud();
                insert.CagarCompra(sql, conectar);
                conectar.Close();
                MessageBox.Show("Venta agregada");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Venta No agregada con exito" + ex.Message);

            }
      
        }


        private void Button_Click(object sender, RoutedEventArgs e)// boton para eliminar un registro en base al correlativo de la venta
        {
            try
            {
                conectar.Open();
                string query = $"Delete From final.registros where Correlativo = {Eliminar.Text}";
                Consultas.Consultas(conectar, query, dataGrid1);
                conectar.Close();
                MessageBox.Show("Eliminacion Correcta");
            }catch(Exception ex)
            {
                MessageBox.Show("Eliminacion No completada" + ex.Message);
            }

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)// boton para consultar fechas en un rango establecido
        {
            try
            {
                string fecha1 = Convert.ToDateTime(Fecha1.Text).ToString("yyyy/MM/dd");
                string fecha2 = Convert.ToDateTime(Fecha2.Text).ToString("yyyy/MM/dd");
                conectar.Open();
                string query = $"Select Correlativo, Nombre, Nit, Precio, Marca, Color, Fecha FROM final.registros where Fecha between'{fecha1}' AND '{fecha2}'";
                Consultas.Consultas(conectar, query, dataGrid1);
                conectar.Close();
            }catch(Exception ex)
            {
                MessageBox.Show("Ocurrio un Error" + ex.Message);
            }
        }



        private void btnActualizar_Click(object sender, RoutedEventArgs e)// boton para actualizar el nombre de un comprador
        {
            try
            {
                conectar.Open();
                string query = $"Update final.registros SET Nombre ='{TxtActualizacion.Text}' where Correlativo = {Eliminar.Text}";
                Consultas.Consultas(conectar, query, dataGrid1);
                conectar.Close();
                MessageBox.Show("Actualizacion Correcta");
            }catch(Exception ex)
            {
                MessageBox.Show("No se ejecuto la actualizaion" + ex.Message);
            }
        }


        private void btnCargarB_Click(object sender, RoutedEventArgs e)//Boton para refrescar la pantalla o visualizar el contenido completo de la base
        {
            try
            {
                conectar.Open();
                string query = "Select *from final.registros";
                Consultas.Consultas(conectar, query, dataGrid1);
                conectar.Close();
            }catch(Exception ex)
            {
                MessageBox.Show("Error al cargar" + ex.Message);
            }
        }



        private void btnDescargar_Click(object sender, RoutedEventArgs e)//Boton para descargar el contenido de la base de datos en formato csv
        {
            try
            {
                Descarga archivos = new Descarga();
                string ruta = TtxRuta.Text;
                string query = "select *from final.registros ";
                SaveFileDialog guardar = new SaveFileDialog() { Filter = "(Archivo CSV|*.csv)" };//Se especifica de  que tipo sera el archivo que se creara
                if (guardar.ShowDialog() == true) ruta = guardar.FileName; //Si se agrega un nombre se guardara en la ruta elegida

                conectar.Open();
                archivos.Rellenar(query, conectar, ruta);
                conectar.Close();
            }catch(Exception ex)
            {
                MessageBox.Show("Ocurrio un error en la descarga" + ex.Message);
            }


        }
    }
}
    

