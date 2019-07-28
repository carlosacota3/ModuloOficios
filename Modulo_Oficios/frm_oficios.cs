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
using Modulo_Oficios.Properties; //Para usar los recursos de la solucion, en este caso los iconos de los botones

namespace Modulo_Oficios
{
    public partial class frm_oficios : Form
    {
		bool datos_mostrados = false;
        bool id_selec = false;
        bool seleccion = true;
        //Esta lista es para guardar las dependecias seleccionadas cuando el rb elminar este seleccionado
        //para evitar que se hagan modificaciones en el listbox
        List<string> DepsSeleccionadas = new List<string>();
        //Constructor
        public frm_oficios(string id_selecc, char accion)
        {
            InitializeComponent();

            txt_id.Text = id_selecc;
            //Llenar ComboBox
            Conexion Conex = new Conexion();
            Conex.llenarDependencias(lb_dependencias);
            Conex.llenarTipo(cmb_tipo);
            Conex.llenarEstados(cmb_estado);
            Conex.ConexionClose();

            if (accion == 'A')
                rb_registrar.Checked = true;
            else if (accion == 'B' && id_selecc != "")
            {
                rb_eliminar.Checked = true;
                mostrar_oficio(); //manda llamar al metodo que traera los datos de la BD para ser desplegados al abrir el formulario
            }
            else if (accion == 'C' && id_selecc != "")
            {
                rb_modificar.Checked = true;
                mostrar_oficio(); //manda llamar al metodo que traera los datos de la BD para ser desplegados al abrir el formulario
            }
        }

        private void frm_oficios_Load(object sender, EventArgs e)
        {
            
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
                if (chb_fecha_respuesta.CheckState == CheckState.Checked)
                    dtp_recibido.Enabled = true;
                else if (chb_fecha_respuesta.CheckState == CheckState.Unchecked)
                    dtp_recibido.Enabled = false;
                lb_dependencias.Enabled = true;
                cmb_estado.Enabled = true;
                cmb_tipo.Enabled = true;
                btn_accion.ForeColor = Color.Black;
                btn_accion.Image = Resources.lista_reducida;
                chb_fecha_respuesta.Enabled = true;
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
                lb_dependencias.Enabled = true;
                cmb_estado.Enabled = false;
                cmb_tipo.Enabled = false;
                btn_accion.ForeColor = Color.Black;
                btn_accion.Image = Resources.lista_reducida;
                chb_fecha_respuesta.Enabled = false;
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
            seleccion = false; //para que no se ejecute lo que esta dentro de lb_dependencias_SelectedIndexChanged
            lb_dependencias.ClearSelected();
            seleccion = true; //dejamos la variable como estaba
            cmb_tipo.SelectedIndex = -1;
            cmb_estado.SelectedIndex = -1;
            dtp_envio.Value = DateTime.Today;
            dtp_recibido.Value = DateTime.Today;
            txt_id.Focus();
            btn_accion.ForeColor = Color.Black;
            chb_fecha_respuesta.CheckState = CheckState.Checked;
            dtp_recibido.Enabled = true;
            if (rb_eliminar.Checked || rb_modificar.Checked)
                btn_accion.Image = Resources.lista_reducida;
            else if (rb_registrar.Checked)
                btn_accion.Image = Resources.guardar_reducido;
            DepsSeleccionadas.Clear();
        }

        private void mostrar_oficio()
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
                    //Guarda los Id de los 2 datos siguientes
                    string id_tipo = rdr["id_tipo"].ToString();
                    string id_estado = rdr["id_estado"].ToString();
                    //Las fechas
                    dtp_envio.Value = Convert.ToDateTime(rdr["Fecha_envio"]);
                    if (rdr["Fecha_recibido"] != DBNull.Value) //puede ser que aun no haya fecha de respuesta
                    {
                        dtp_recibido.Value = Convert.ToDateTime(rdr["Fecha_recibido"]);
                    }
                    else
                    {
                        chb_fecha_respuesta.CheckState = CheckState.Unchecked;
                        dtp_recibido.Enabled = false;
                    }
                    rdr.Close(); //Cerrar el datareader
                    
                    //Muestra la Dependencia
                    //Ahora consultamos las dependencias
                    cmdConsultar = new SqlCommand("select dependencia_id from dependencia_oficio where oficio_id='" + txt_id.Text + "'", c.conn);
                    rdr = cmdConsultar.ExecuteReader();
                    
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            int index = lb_dependencias.FindString(rdr["dependencia_id"].ToString());
                            if (index != -1)
                            {
                                lb_dependencias.SetSelected(index, true);
                                //Si vamos a elminar se hara un respaldo de los elementos seleccionados para que no se puedan modificar en el listbox
                                DepsSeleccionadas.Add(rdr["dependencia_id"].ToString());
                            }
                        }
                    }
                    rdr.Close();

                    //Muestra el Tipo
                    SqlCommand cmdTipo = new SqlCommand("Select Nombre from Tipo where id = " + id_tipo + ";", c.conn);
                    SqlDataReader reader = cmdTipo.ExecuteReader();
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
                    if (rb_eliminar.Checked)
                    {
                        btn_accion.Text = "Eliminar Oficio";
                        btn_accion.ForeColor = Color.Red;
                        btn_accion.Image = Resources.limpiar_rojo_reducido; //Cambia el icono del boton, desde una imagen en los recursos del proyecto
                    }
                    else if (rb_modificar.Checked)
                    {
                        btn_accion.Text = "Guardar Cambios";
                        btn_accion.Image = Resources.guardar_reducido; //Cambia el icono del boton, desde una imagen en los recursos del proyecto
                    }
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
                else if (lb_dependencias.SelectedItems == null)
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
                else if ((dtp_recibido.Value < dtp_envio.Value) && (chb_fecha_respuesta.CheckState ==  CheckState.Checked))
                {
                    MessageBox.Show("La Fecha de Respuesta no puede ser anterior a la Fecha de Envio");
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
                        string sqlDependencias = "";
                        //Si hay fecha de respuesta se guardara en la BD
                        if (chb_fecha_respuesta.CheckState == CheckState.Checked)
                        {
                            sql = "INSERT INTO Oficio (id, Asunto, Fecha_envio, Fecha_recibido, id_tipo, id_estado) VALUES (@id, @asunto, @fecha_envio, @fecha_recibido, @tipo, @estado)";
                        }
                        else //Si no la hay, no se enviara nada
                        {
                            sql = "INSERT INTO Oficio (id, Asunto, Fecha_envio, id_tipo, id_estado) VALUES (@id, @asunto, @fecha_envio, @tipo, @estado)";
                        }
                        //Agregamos las sentencias INSERT para las dependencias seleccionadas en el ListBox, a una variable
                        foreach (var item in lb_dependencias.SelectedItems)
                        {                     
                            var arr = item.ToString().Split('-'); //Dividimos la cadena en 2 partes, en el id y el nombre de la dependencia
                                                //Importante ese espacio al principio de la cadena
                            sqlDependencias += " INSERT INTO dependencia_oficio (oficio_id, dependencia_id) VALUES ('" + txt_id.Text + "', " + arr[0] + ");";
                        }

                        comando = new SqlCommand(sql, c.conn);

                        comando.Parameters.AddWithValue("@id", txt_id.Text);
                        comando.Parameters.AddWithValue("@asunto", txt_asunto.Text);
                        comando.Parameters.AddWithValue("@fecha_envio", dtp_envio.Value.Date);
                        if (chb_fecha_respuesta.CheckState == CheckState.Checked)
                            comando.Parameters.AddWithValue("@fecha_recibido", dtp_recibido.Value.Date);
                        comando.Parameters.AddWithValue("@tipo", obtenerId(cmb_tipo.Text));
                        comando.Parameters.AddWithValue("@estado", obtenerId(cmb_estado.Text));
                        //try
                        //{
                            SqlCommand comandoDeps = new SqlCommand(sqlDependencias, c.conn);
                            comando.ExecuteNonQuery();
                            comandoDeps.ExecuteNonQuery();
                            MessageBox.Show("Registro Exitoso");
                            //Limpiar campos
                            limpiarCampos();
                        //}
                        //catch (Exception ex)
                        //{
                        //    MessageBox.Show("Fallo al realizar el registro. " + ex.ToString());
                        //}
                        c.ConexionClose();

                    }
                }
            }
            else if (rb_eliminar.Checked)
            {
				if (txt_id.Text.Length == 0)
                {
                    MessageBox.Show("Tienes que ingresar el Id para continuar");
                }
                else if (datos_mostrados == false) //Primero se despliegan los datos del oficio a los campos del formulario
                {
                    mostrar_oficio(); //manda llamar al metodo que traera los datos de la BD
                }
                else if (datos_mostrados == true) //Aqui ya procede a eliminar
                {
                    Conexion c = new Conexion();
                    SqlCommand cmdConsultar = new SqlCommand("delete dependencia_oficio where oficio_id = '" + txt_id.Text + "'; delete Oficio where Id = '" + txt_id.Text + "';", c.conn);
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
                    mostrar_oficio(); //manda llamar al metodo que traera los datos de la BD
                }
                else if (datos_mostrados == true) //Aqui se modificaran los datos
                {
                    Conexion c = new Conexion();

                    
                    //No fue la mejor manera de hacerlo pero fue la mas facil que se me ocurrio en el momento
                    //Borramos los registros de dependecias que tenga este oficio, y mas abajo los volvemos a registrar
                    //esto por si se agregaron o quitaron dependencias al oficio, del listbox
                    SqlCommand cmdDependencias = new SqlCommand("delete dependencia_oficio where oficio_id = '" + txt_id.Text + "';", c.conn);
                    cmdDependencias.ExecuteNonQuery();
                    string sqlDependencias = "";
                    //Agregamos las sentencias INSERT para las dependencias seleccionadas en el ListBox, a una variable
                    foreach (var item in lb_dependencias.SelectedItems)
                    {                     
                        var arr = item.ToString().Split('-'); //Dividimos la cadena en 2 partes, en el id y el nombre de la dependencia
                                            //Importante ese espacio al principio de la cadena
                        sqlDependencias += " INSERT INTO dependencia_oficio (oficio_id, dependencia_id) VALUES ('" + txt_id.Text + "', " + arr[0] + ");";
                    }

                    cmdDependencias = new SqlCommand(sqlDependencias, c.conn);
                    cmdDependencias.ExecuteNonQuery();

                    string sql = "update Oficio set Asunto = '" + txt_asunto.Text +"', ";
                    sql += "Fecha_envio = '" + dtp_envio.Value.Date.ToString("yyyy-MM-dd") + "', ";
                    if (chb_fecha_respuesta.CheckState == CheckState.Checked) //Modificar fecha de respuesta en cambio de que se check el checkedbuton
                       sql += "Fecha_recibido = '" + dtp_recibido.Value.Date.ToString("yyyy-MM-dd")+ "', ";
                    sql += "id_tipo = '" + obtenerId(cmb_tipo.Text) + "', ";
                    sql += "id_estado = '" + obtenerId(cmb_estado.Text) + "'";
                    sql += "where id = '" + txt_id.Text + "'";

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
                if (chb_fecha_respuesta.CheckState == CheckState.Checked)
                    dtp_recibido.Enabled = true;
                else if (chb_fecha_respuesta.CheckState == CheckState.Unchecked)
                    dtp_recibido.Enabled = false;
                lb_dependencias.Enabled = true;
                cmb_estado.Enabled = true;
                cmb_tipo.Enabled = true;
                btn_accion.ForeColor = Color.Black;
                btn_accion.Image = Resources.guardar_reducido;
                chb_fecha_respuesta.Enabled = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.filtros.Show();
            Program.filtros.llenarDataGrid("");
            this.Close();
        }

        private void frm_oficios_FormClosing(object sender, FormClosedEventArgs e)
        {
            Program.filtros.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_fecha_respuesta.CheckState == CheckState.Checked)
            {
                dtp_recibido.Enabled = true;
            }
            else if (chb_fecha_respuesta.CheckState == CheckState.Unchecked)
            {
                dtp_recibido.Enabled = false;
            }
        }

        private void lb_dependencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Evitar que cuando el rb eliminar este seleccionado se puedan modificar las selecciones del listbox
            if (rb_eliminar.Checked && datos_mostrados == true && seleccion == true)
            {
                seleccion = false; //si no tuviera esta variable, se ciclaria en este metodo ya que al seleccionar un nuevo elemento
                                    //en el for each se estaria volviendo a llamar a este metodo
                lb_dependencias.ClearSelected();
                foreach (var item in DepsSeleccionadas)
                {
                    int index = lb_dependencias.FindString(item.ToString());
                    if (index != -1)
                    {
                        lb_dependencias.SetSelected(index, true);
                    }
                }
                seleccion = true;
            }
        }
    }
}