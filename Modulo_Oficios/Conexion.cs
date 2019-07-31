using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Modulo_Oficios
{
    class Conexion
    {
        public SqlConnection conn;
        SqlCommand comand;
        SqlDataReader dr;

        //inicia la conexion con la BD
        public Conexion()
        {
            try
            {
                string value;
                value = Environment.GetEnvironmentVariable("servidor_BD"); //Esta variable se tiene que crear en las variables del sistema
                conn = new SqlConnection("Data Source=" + value + ";Initial Catalog=oficios;Integrated Security=True");
                conn.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show("No se logro establecer la conexion con la BD.");
            }
        }
        //Metodo Select
        public DataTable Select(String Valores, String Tabla)
        {
            DataTable table = new DataTable();
            try
            {
                String SQL = "Select " + Valores + " from " + Tabla;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(SQL, conn);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Fill(table);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                table.Clear();
            }
            return table;
        }
        //Metodo Select con Where
        public DataTable Select(String Valores, String Tabla, String Condicion)
        {

            DataTable table = new DataTable();
            try
            {
                String SQL = "Select " + Valores + " from " + Tabla + " where " + Condicion;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(SQL, conn);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Fill(table);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                table.Clear();
            }
            return table;
        }
        // Llena el list box Dependencias
        public void llenarDependencias(ListBox lb)
        {
            try
            {
                comand = new SqlCommand("Select * from Dependencia",conn);
                dr = comand.ExecuteReader();
                string resultado = "";
                while(dr.Read())
                {
                    resultado = dr["id"].ToString() + "-" + dr["Nombre"].ToString();
                    lb.Items.Add(resultado);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                //MessageBox.Show("No se lleno el ComboBox " + ex.ToString());
            }
        }
        // Llena el combo box Dependencias
        public void llenarDependencias(ComboBox cb)
        {
            try
            {
                comand = new SqlCommand("Select * from Dependencia", conn);
                dr = comand.ExecuteReader();
                string resultado = "";
                while (dr.Read())
                {
                    resultado = dr["id"].ToString() + "-" + dr["Nombre"].ToString();
                    cb.Items.Add(resultado);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                //MessageBox.Show("No se lleno el ComboBox " + ex.ToString());
            }
        }
        // Llena el combo box Estados
        public void llenarEstados(ComboBox cb)
        {
            try
            {
                comand = new SqlCommand("Select * from Estado", conn);
                dr = comand.ExecuteReader();
                string resultado = "";
                while (dr.Read())
                {
                    resultado = dr["id"].ToString() + "-" + dr["Nombre"].ToString();
                    cb.Items.Add(resultado);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                //MessageBox.Show("No se lleno el ComboBox " + ex.ToString());
            }
        }

        // Llena el combo box Tipos
        public void llenarTipo(ComboBox cb)
        {
            try
            {
                comand = new SqlCommand("Select * from Tipo", conn);
                dr = comand.ExecuteReader();
                string resultado = "";
                while (dr.Read())
                {
                    resultado = dr["id"].ToString() + "-" + dr["Nombre"].ToString();
                    cb.Items.Add(resultado);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                //MessageBox.Show("No se lleno el ComboBox " + ex.ToString());
            }
        }

        //Cierra la conexion
        public void ConexionClose()
        {
            try
            {
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se desconecto " + ex.ToString());
            }
        }
    }
}
