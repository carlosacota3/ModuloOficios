using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Modulo_Oficios
{
    public partial class frm_oficios : Form
    {
		bool datos_mostrados = false; 

        public frm_oficios()
        {
            InitializeComponent();
        }

        private void frm_oficios_Load(object sender, EventArgs e)
        {
            Conexion Conex = new Conexion();
            Conex.llenarDependencias(cmb_dependencias);
            Conex.llenarTipo(cmb_tipo);
            Conex.llenarEstados(cmb_estado);
        }

        private void rb_registrar_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_registrar.Checked)
                btn_accion.Text = "Registrar Oficio";
        }

        private void rb_modificar_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_modificar.Checked)
            {
                btn_accion.Text = "Mostrar Oficio";
                datos_mostrados = false;
                txt_asunto.Enabled = true;
                dtp_envio.Enabled = true;
                dtp_recibido.Enabled = true;
                cmb_dependencias.Enabled = true;
                cmb_estado.Enabled = true;
                cmb_tipo.Enabled = true;
                btn_accion.ForeColor = Color.Black;
            }
        }

        private void rb_eliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_eliminar.Checked)
            {
                btn_accion.Text = "Mostrar Oficio";
                datos_mostrados = false;
                txt_asunto.Enabled = false;
                dtp_envio.Enabled = false;
                dtp_recibido.Enabled = false;
                cmb_dependencias.Enabled = false;
                cmb_estado.Enabled = false;
                cmb_tipo.Enabled = false;
                btn_accion.ForeColor = Color.Black;
            }
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            datos_mostrados = false;
            txt_id.Enabled = true;
            if (rb_registrar.Checked)
                btn_accion.Text = "Registrar Oficio";
            else if (rb_modificar.Checked || rb_eliminar.Checked)
                btn_accion.Text = "Mostrar Oficio";
        }

        //Metodo para obtener el Id de Dependencia, Tipo, Estado
        public string obtenerId(string cadena)
        {
            string id = "";
            for (int i = 0 ; i <= cadena.Length; i++)
            {
                if (cadena[i] == '-')
                {
                    break;
                }
                else
                {
                    id += cadena[i];
                }
            } 
            return id;
        }

        private void limpiarCampos()
        {
            txt_id.Clear();
            txt_asunto.Clear();
            cmb_dependencias.SelectedIndex = -1;
            cmb_tipo.SelectedIndex = -1;
            cmb_estado.SelectedIndex = -1;
            dtp_envio.Value = DateTime.Today;
            dtp_recibido.Value = DateTime.Today;
            txt_id.Focus();
            btn_accion.ForeColor = Color.Black;
        }

        private void btn_accion_Click(object sender, EventArgs e)
        {
            if (rb_registrar.Checked)
            {
                if (txt_id.Text == "")
                {
                    MessageBox.Show("Falta ingresar el Id");
                }
                else if (txt_asunto.Text == "")
                {
                    MessageBox.Show("Falta ingresar el Asunto");
                }
                else if (cmb_dependencias.Text == "")
                {
                    MessageBox.Show("Falta seleccionar Dependencia");
                }
                else if (cmb_tipo.Text == "")
                {
                    MessageBox.Show("Falta seleccionar Tipo");
                }
                else if (cmb_estado.Text == "")
                {
                    MessageBox.Show("Falta seleccionar Estado");
                }
                else
                {
                    Conexion c = new Conexion();
                    //Verificar que el id no exista registrado
                    string sql = "SELECT id from Oficio where id = '" + txt_id.Text + "';";
                    SqlCommand comando = new SqlCommand(sql, c.conn);
                    SqlDataReader rdr = comando.ExecuteReader();
                    if (rdr.HasRows) //Si ya existe va a regresar un resultado (el mismo id que se solicito buscar se encontro a si mismo)
                    {
                        string id = "", maxId = "";
                        while (rdr.Read())
                        {
                            id = rdr["id"].ToString();
                        }
                        rdr.Close();
                        //Le mostraremos al usuario el id del ultimo oficio registrado
                        sql = "SELECT MAX(id) as maxId from Oficio";
                        comando = new SqlCommand(sql, c.conn);
                        rdr = comando.ExecuteReader();
                        while (rdr.Read())
                        {
                            maxId = rdr["maxId"].ToString();
                        }
                        rdr.Close();
                        MessageBox.Show("El id: " + id + " ya ha sido registrado.\n\nSUGERENCIA: El ultimo id registrado es el: " + maxId + ".");

                    }
                    else //Si no existe registrado procedera a registrar el oficio
                    {
                        rdr.Close();//Se cierra el rdr que usamos para verificar el id
                        //Almacenar los datos en la BD
                        sql = "INSERT INTO Oficio (id, Asunto, Fecha_envio, Fecha_recibido, id_dependencia, id_tipo, id_estado) VALUES (@id, @asunto, @fecha_envio, @fecha_recibido, @dependencia, @tipo, @estado)";
                        comando = new SqlCommand(sql, c.conn);

                        comando.Parameters.AddWithValue("@id", txt_id.Text);
                        comando.Parameters.AddWithValue("@asunto", txt_asunto.Text);
                        comando.Parameters.AddWithValue("@fecha_envio", dtp_envio.Value.Date);
                        comando.Parameters.AddWithValue("@fecha_recibido", dtp_recibido.Value.Date);
                        comando.Parameters.AddWithValue("@dependencia", obtenerId(cmb_dependencias.Text));
                        comando.Parameters.AddWithValue("@tipo", obtenerId(cmb_tipo.Text));
                        comando.Parameters.AddWithValue("@estado", obtenerId(cmb_estado.Text));
                        comando.ExecuteNonQuery();
                        MessageBox.Show("Registro Exitoso");
                        c.ConexionClose();

                        //Limpiar campos
                        limpiarCampos();
                    }
                }
            }
            else if (rb_eliminar.Checked)
            {
				if (txt_id.Text.Length == 0)
                {
                    MessageBox.Show("Tienes que ingresar el Id para continuar");
                }
                else if (datos_mostrados == false)
                {
					Conexion c = new Conexion();
                    //Se van a mostrar los datos del oficio
                    SqlCommand cmdConsultar = new SqlCommand("select * from Oficio where Id='" + txt_id.Text + "'", c.conn);
                    SqlDataReader rdr = cmdConsultar.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            //El asunto
                            txt_asunto.Text = rdr["Asunto"].ToString();
                            //Guarda los Id de los 3 datos siguientes
                            string id_dependencia = rdr["id_dependencia"].ToString();
                            string id_tipo = rdr["id_tipo"].ToString();
                            string id_estado = rdr["id_estado"].ToString();
                            //Las fechas
                            dtp_envio.Value = Convert.ToDateTime(rdr["Fecha_envio"]);
                            dtp_recibido.Value = Convert.ToDateTime(rdr["Fecha_recibido"]);
                            rdr.Close(); //Cerrar el datareader

                            //Muestra la Dependencia
                            SqlCommand cmdDependencia = new SqlCommand("Select Nombre from Dependencia where id = " + id_dependencia + ";", c.conn);
                            SqlDataReader reader = cmdDependencia.ExecuteReader();
                            while (reader.Read())
                            {
                                cmb_dependencias.Text = id_dependencia + "-" + reader["Nombre"].ToString();
                            }
                            reader.Close();

                            //Muestra el Tipo
                            SqlCommand cmdTipo = new SqlCommand("Select Nombre from Tipo where id = " + id_tipo + ";", c.conn);
                            reader = cmdTipo.ExecuteReader();
                            while (reader.Read())
                            {
                                cmb_tipo.Text = id_tipo + "-" + reader["Nombre"].ToString();
                            }
                            reader.Close();

                            //Muestra el Estado
                            SqlCommand cmdEstado = new SqlCommand("Select Nombre from Estado where id = " + id_estado + ";", c.conn);
                            reader = cmdEstado.ExecuteReader();
                            while (reader.Read())
                            {
                                cmb_estado.Text = id_estado + "-" + reader["Nombre"].ToString();
                            }
                            reader.Close();

                            btn_accion.Text = "Eliminar Oficio";
                            btn_accion.ForeColor = Color.Red;
                            txt_id.Enabled = false;
                            datos_mostrados = true; //Indicamos que los datos ya se muestran para ahora proceder a eliminar
                            break; //Salimos del ciclo, porque el rdr ya esta cerrado y probablemente da error en el siguiente loop
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay datos que coincidan con la busqueda");
                        rdr.Close(); //Cerrar el datareader
                    }
                     
                    c.ConexionClose(); //Cerrar la conexion



                }
                else if (datos_mostrados == true) //Aqui ya procede a eliminar
                {
                    Conexion c = new Conexion();
                    SqlCommand cmdConsultar = new SqlCommand("delete Oficio where Id = '" + txt_id.Text +"';", c.conn);
                    cmdConsultar.ExecuteNonQuery();
                    MessageBox.Show("Registro Borrado");
                    limpiarCampos(); //Limpiar campos
                    datos_mostrados = false;
                    btn_accion.Text = "Mostrar Oficio";
                    btn_accion.ForeColor = Color.Black;
                    txt_id.Enabled = true;
                    c.ConexionClose(); //Cerrar la conexion
                }
            }
            else if (rb_modificar.Checked)
            {
                if (txt_id.Text.Length == 0)
                {
                    MessageBox.Show("Ingresa el Id");
                }
                else if (datos_mostrados == false)
                {
                    Conexion c = new Conexion();
                    //Se van a mostrar los datos del oficio
                    SqlCommand cmdConsultar = new SqlCommand("select * from Oficio where Id='" + txt_id.Text + "'", c.conn);
                    SqlDataReader rdr = cmdConsultar.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            //El asunto
                            txt_asunto.Text = rdr["Asunto"].ToString();
                            //Guarda los Id de los 3 datos siguientes
                            string id_dependencia = rdr["id_dependencia"].ToString();
                            string id_tipo = rdr["id_tipo"].ToString();
                            string id_estado = rdr["id_estado"].ToString();
                            //Las fechas
                            dtp_envio.Value = Convert.ToDateTime(rdr["Fecha_envio"]);
                            dtp_recibido.Value = Convert.ToDateTime(rdr["Fecha_recibido"]);
                            rdr.Close(); //Cerrar el datareader

                            //Muestra la Dependencia
                            SqlCommand cmdDependencia = new SqlCommand("Select Nombre from Dependencia where id = " + id_dependencia + ";", c.conn);
                            SqlDataReader reader = cmdDependencia.ExecuteReader();
                            while (reader.Read())
                            {
                                cmb_dependencias.Text = id_dependencia + "-" + reader["Nombre"].ToString();
                            }
                            reader.Close();

                            //Muestra el Tipo
                            SqlCommand cmdTipo = new SqlCommand("Select Nombre from Tipo where id = " + id_tipo + ";", c.conn);
                            reader = cmdTipo.ExecuteReader();
                            while (reader.Read())
                            {
                                cmb_tipo.Text = id_tipo + "-" + reader["Nombre"].ToString();
                            }
                            reader.Close();

                            //Muestra el Estado
                            SqlCommand cmdEstado = new SqlCommand("Select Nombre from Estado where id = " + id_estado + ";", c.conn);
                            reader = cmdEstado.ExecuteReader();
                            while (reader.Read())
                            {
                                cmb_estado.Text = id_estado + "-" + reader["Nombre"].ToString();
                            }
                            reader.Close();

                            btn_accion.Text = "Modificar Oficio";
                            datos_mostrados = true; //Indicamos que los datos ya se muestran para ahora proceder a eliminar
                            txt_id.Enabled = false;
                            break; //Salimos del ciclo, porque el rdr ya esta cerrado y probablemente da error en el siguiente loop
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay datos que coincidan con la busqueda");
                        rdr.Close(); //Cerrar el datareader
                    }
                    c.ConexionClose(); //Cerrar la conexion
                }
                else if (datos_mostrados == true) //Aqui se modificaran los datos
                {
                    Conexion c = new Conexion();

                    string sql = "update Oficio set Asunto = '" + txt_asunto.Text +"', ";
                    sql += "Fecha_envio = '" + dtp_envio.Value.Date.ToString("yyyy-MM-dd") + "', ";
                    sql += "Fecha_recibido = '" + dtp_recibido.Value.Date.ToString("yyyy-MM-dd")+ "', ";
                    sql += "id_dependencia = '" + obtenerId(cmb_dependencias.Text) + "', ";
                    sql += "id_tipo = '" + obtenerId(cmb_tipo.Text) + "', ";
                    sql += "id_estado = '" + obtenerId(cmb_estado.Text) + "';";


                    SqlCommand cmdConsultar = new SqlCommand(sql, c.conn);
                    cmdConsultar.ExecuteNonQuery();
                    MessageBox.Show("Datos Actualizados");
                    c.ConexionClose();
                    datos_mostrados = false;
                    btn_accion.Text = "Mostrar Oficio";
                    //Limpiar campos
                    limpiarCampos();
                    txt_id.Enabled = true;
                }
            }
        }

        private void rb_registrar_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rb_registrar.Checked)
            {
                btn_accion.Text = "Registrar Oficio";
                datos_mostrados = false;
                txt_asunto.Enabled = true;
                dtp_envio.Enabled = true;
                dtp_recibido.Enabled = true;
                cmb_dependencias.Enabled = true;
                cmb_estado.Enabled = true;
                cmb_tipo.Enabled = true;
                btn_accion.ForeColor = Color.Black;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}