using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

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
                conn = new SqlConnection("Data Source=.;Initial Catalog=oficios;Integrated Security=True");
                conn.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show("No se logro establecer la conexion con la BD.");
            }
        }

        // Llena el combo box Dependencias
        public void llenarDependencias(ComboBox cb)
        {
            try
            {
                comand = new SqlCommand("Select * from Dependencia",conn);
                dr = comand.ExecuteReader();
                string resultado = "";
                while(dr.Read())
                {
                    resultado = dr["id"].ToString() + "-" + dr["Nombre"].ToString();
                    cb.Items.Add(resultado);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se lleno el ComboBox " + ex.ToString());   
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
                MessageBox.Show("No se lleno el ComboBox " + ex.ToString());
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
                MessageBox.Show("No se lleno el ComboBox " + ex.ToString());
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
