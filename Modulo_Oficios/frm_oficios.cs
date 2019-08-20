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
        //Esta lista es para guardar las dependecias seleccionadas cuando el rb elminar este seleccionado
        //para evitar que se hagan modificaciones en el listbox
        List<string> DepsSeleccionadas = new List<string>();
        //Constructor
        public frm_oficios(string id_selecc, string dependencia, char accion)
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
                mostrar_oficio(dependencia); //manda llamar al metodo que traera los datos de la BD para ser desplegados al abrir el formulario
            }
            else if (accion == 'C' && id_selecc != "")
            {
                rb_modificar.Checked = true;
                mostrar_oficio(dependencia); //manda llamar al metodo que traera los datos de la BD para ser desplegados al abrir el formulario
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
                lb_dependencias.Enabled = false;
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
                lb_dependencias.Enabled = false;
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
            //seleccion = false; //para que no se ejecute lo que esta dentro de lb_dependencias_SelectedIndexChanged
            lb_dependencias.ClearSelected();
            //seleccion = true; //dejamos la variable como estaba
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

        private void mostrar_oficio(string DepPreSeleccionada)
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
                    //Las fechas
                    dtp_envio.Value = Convert.ToDateTime(rdr["Fecha_envio"]);
                    rdr.Close(); //Cerrar el datareader
                    
                    //Muestra la Dependencia
                    //Ahora consultamos las dependencias
                    cmdConsultar = new SqlCommand("select dependencia_id from Oficio_dependencia where oficio_id='" + txt_id.Text + "'", c.conn);
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
                                //DepsSeleccionadas.Add(rdr["dependencia_id"].ToString());

                                //Vamos a guardar las dependencias relacionadas a este oficio en otro objeto listbox que vamos a mandar a otro form
                                DepsSeleccionadas.Add(lb_dependencias.SelectedItem.ToString());
                                //En caso de tener un valor en DepPreSeleccionada y que una de las dependecias asignadas al oficio sea la misma
                                //que la de esta variable, vamos a asignarle la cadena completa de la Dependencia a DepPreSeleccionada
                                //ya que asi como esta no trae el id, solo el nombre de la dependencia
                                if (DepPreSeleccionada != "" && lb_dependencias.SelectedItem.ToString().Contains(DepPreSeleccionada))
                                {
                                    DepPreSeleccionada = lb_dependencias.SelectedItem.ToString();
                                }
                                lb_dependencias.SetSelected(index, false);
                            }
                        }
                    }
                    rdr.Close();

                    
                    //Si tenemos la Dependencia precargada, es decir que nos llego como parametro desde el formulario de filtros al
                    //seleccionar un objeto del data grid, entonces no necesitamos elegir la dependencia con el ShowDialog
                    if (DepPreSeleccionada != "")
                    {
                        int ind = lb_dependencias.FindString(DepPreSeleccionada);
                        if (ind != -1)
                        {
                            lb_dependencias.SetSelected(ind, true);
                        }
                    }
                    else
                    {
                        //Ahora abrimos el siguiente form que nos mostrara las Dependencias relacionadas a ese oficio, para que ahi se seleccione
                        //solo una y esta sea la que se va a modificar/eliminar en el ABC
                        if (DepsSeleccionadas.Count > 1)
                        {
                            frm_seleccion_dependencia frm = new frm_seleccion_dependencia(DepsSeleccionadas);
                            frm.ShowDialog();
                            int ind = lb_dependencias.FindString(frm.Dependencia);
                            if (ind != -1)
                            {
                                lb_dependencias.SetSelected(ind, true);
                            }
                            else
                            {
                                MessageBox.Show("No se eligió una Dependencia. \nSe limpiarán los campos.");
                                limpiarCampos();
                                frm.Dispose();
                                return;
                            }
                            frm.Dispose();
                        }
                        else
                        {
                            int ind = lb_dependencias.FindString(DepsSeleccionadas.FirstOrDefault().ToString());
                            if (ind != -1)
                            {
                                lb_dependencias.SetSelected(ind, true);
                            }
                        }
                    }
                    //Ahora consultamos la fecha de respuesta
                    var idDepe = lb_dependencias.SelectedItem.ToString().Split('-');
                    cmdConsultar = new SqlCommand("select Fecha_respuesta from Oficio_dependencia where oficio_id='" + txt_id.Text + "' AND dependencia_id = " + idDepe[0] + ";", c.conn);
                    rdr = cmdConsultar.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            if (rdr["Fecha_respuesta"] != DBNull.Value) //puede ser que aun no haya fecha de respuesta
                            {
                                dtp_recibido.Value = Convert.ToDateTime(rdr["Fecha_respuesta"]);
                            }
                            else
                            {
                                chb_fecha_respuesta.CheckState = CheckState.Unchecked;
                                dtp_recibido.Enabled = false;
                            }
                        }
                    }
                    rdr.Close();

                    //Muestra el Estado
                    var idDep = lb_dependencias.SelectedItem.ToString().Split('-');
                    string sqlEdo = "SELECT Estado.id, Estado.Nombre ";
                    sqlEdo += " FROM Estado INNER JOIN ";
                    sqlEdo += " Oficio_dependencia ON Estado.id = Oficio_dependencia.estado_id";
                    sqlEdo += " where Oficio_dependencia.dependencia_id = " + idDep[0] + " AND Oficio_dependencia.oficio_id = '" + txt_id.Text + "';";
                    SqlCommand cmdEstado = new SqlCommand(sqlEdo, c.conn);
                    SqlDataReader reader = cmdEstado.ExecuteReader();
                    while (reader.Read())
                    {
                        cmb_estado.Text = reader["id"] + "-" + reader["Nombre"].ToString();
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
                { //ROE
                    MessageBox.Show("Falta ingresar el Id");
                }
                else if (txt_asunto.Text == "")
                {
                    MessageBox.Show("Falta ingresar el Asunto");
                }
                else if (lb_dependencias.SelectedItems.Count == 0)
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
                            //Agregamos las sentencias INSERT para las dependencias seleccionadas en el ListBox, a una variable
                            foreach (var item in lb_dependencias.SelectedItems)
                            {
                                var idDep = item.ToString().Split('-'); //Dividimos la cadena en 2 partes, en el id y el nombre de la dependencia
                                //Importante ese espacio al principio de la cadena
                                var idEdo = cmb_estado.Text.Split('-'); //Hacemos lo mismo con el cmb estado para extraer el Id
                                sqlDependencias += " INSERT INTO Oficio_dependencia (oficio_id, dependencia_id, estado_id, Fecha_respuesta) VALUES ('" + txt_id.Text + "', " + idDep[0] + ", '" + idEdo[0] + "', '" + dtp_recibido.Value.Date.ToString("yyyy-MM-dd") + "');";
                            }
                        }
                        else //Si no la hay, no se enviara nada
                        {
                            foreach (var item in lb_dependencias.SelectedItems)
                            {
                                var idDep = item.ToString().Split('-'); //Dividimos la cadena en 2 partes, en el id y el nombre de la dependencia
                                //Importante ese espacio al principio de la cadena
                                var idEdo = cmb_estado.Text.Split('-'); //Hacemos lo mismo con el cmb estado para extraer el Id
                                sqlDependencias += " INSERT INTO Oficio_dependencia (oficio_id, dependencia_id, estado_id) VALUES ('" + txt_id.Text + "', " + idDep[0] + ", '" + idEdo[0] + "');";
                            }
                        }
                        
                        sql = "INSERT INTO Oficio (id, Asunto, Fecha_envio, id_tipo) VALUES (@id, @asunto, @fecha_envio, @tipo)";
                        comando = new SqlCommand(sql, c.conn);

                        comando.Parameters.AddWithValue("@id", txt_id.Text);
                        comando.Parameters.AddWithValue("@asunto", txt_asunto.Text);
                        comando.Parameters.AddWithValue("@fecha_envio", dtp_envio.Value.Date);
                        comando.Parameters.AddWithValue("@tipo", obtenerId(cmb_tipo.Text));
                        
                        int rowsAffected = 0;
                        //Insertamos en la tabla Oficio
                        try
                        {
                            rowsAffected = comando.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Fallo al realizar el registro.  \n" + ex.ToString());
                        }

                        //Insertamos las diferentes dependencias en la tabla Oficio_dependencia
                        if (rowsAffected == 1)
                        {
                            try
                            {
                                SqlCommand comandoDeps = new SqlCommand(sqlDependencias, c.conn);
                                comandoDeps.ExecuteNonQuery();
                                MessageBox.Show("Registro Exitoso");
                                //Limpiar campos
                                limpiarCampos();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Fallo al realizar el registro.  \n" + ex.ToString());
                                //En caso de no realizarse la insercion en la segunda tabla se borra el contenido en la primera tabla
                                //pero sin limpiar campos del form para dar la oportunidad de volver a intentarlo
                                SqlCommand cmd = new SqlCommand("delete Oficio where id = '" + txt_id.Text + "';", c.conn);
                                cmd.ExecuteNonQuery();
                            }
                        }
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
                    mostrar_oficio(""); //manda llamar al metodo que traera los datos de la BD
                }
                else if (datos_mostrados == true) //Aqui ya procede a eliminar
                {
                    Conexion c = new Conexion();
                    var depId = lb_dependencias.SelectedItem.ToString().Split('-');
                    //Borra el registro por dependencia
                    SqlCommand cmdConsultar = new SqlCommand("delete Oficio_dependencia where oficio_id = '" + txt_id.Text + "' AND dependencia_id = " + depId[0] + ";", c.conn);
                    cmdConsultar.ExecuteNonQuery();

                    //Verificamos si al borrar una dependencia del oficio, aun queden otras dependencias ligadas al oficio haciendo un Count para saber cuantas dependencias tiene
                    cmdConsultar = new SqlCommand("Select Count(oficio_id) as 'Total' from Oficio_dependencia where oficio_id = '" + txt_id.Text + "';", c.conn);
                    SqlDataReader rdr = cmdConsultar.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {   
                            //Y en caso de que el total de dependencias ligadas al oficio sea 0, eliminamos el oficio totalmente
                            if (rdr["Total"].ToString() == "0")
                            {
                                cmdConsultar = new SqlCommand("delete Oficio where id = '" + txt_id.Text + "';", c.conn);
                                rdr.Close();
                                cmdConsultar.ExecuteNonQuery();
                                break;
                            }
                        }
                    }
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
                    mostrar_oficio(""); //manda llamar al metodo que traera los datos de la BD
                }
                else if (datos_mostrados == true) //Aqui se modificaran los datos
                {
                    Conexion c = new Conexion();

                    
                    var idDep = lb_dependencias.SelectedItem.ToString().Split('-');
                    var idEdo = cmb_estado.Text.Split('-');
                    string sql = "";
                    if (chb_fecha_respuesta.CheckState == CheckState.Checked) //Modificar fecha de respuesta en cambio de que se check el checkedbuton
                        sql = "UPDATE Oficio_dependencia set estado_id = '" + idEdo[0] + "', Fecha_respuesta = '" + dtp_recibido.Value.Date.ToString("yyyy-MM-dd") + "' where oficio_id = '" + txt_id.Text + "' AND dependencia_id = " + idDep[0] + ";";
                    else
                        sql = "UPDATE Oficio_dependencia set estado_id = '" + idEdo[0] + "' where oficio_id = '" + txt_id.Text + "' AND dependencia_id = " + idDep[0] + ";";
                    SqlCommand cmd = new SqlCommand(sql, c.conn);
                    cmd.ExecuteNonQuery();

                    sql = "update Oficio set Asunto = '" + txt_asunto.Text +"', ";
                    sql += "Fecha_envio = '" + dtp_envio.Value.Date.ToString("yyyy-MM-dd") + "', ";
                    sql += "id_tipo = '" + obtenerId(cmb_tipo.Text) + "' ";
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
            ////Evitar que cuando el rb eliminar este seleccionado se puedan modificar las selecciones del listbox
            //if (rb_eliminar.Checked && datos_mostrados == true && seleccion == true)
            //{
            //    seleccion = false; //si no tuviera esta variable, se ciclaria en este metodo ya que al seleccionar un nuevo elemento
            //                        //en el for each se estaria volviendo a llamar a este metodo
            //    lb_dependencias.ClearSelected();
            //    foreach (var item in DepsSeleccionadas)
            //    {
            //        int index = lb_dependencias.FindString(item.ToString());
            //        if (index != -1)
            //        {
            //            lb_dependencias.SetSelected(index, true);
            //        }
            //    }
            //    seleccion = true;
            //}
        }
    }
}