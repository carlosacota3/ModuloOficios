﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Modulo_Oficios
{
    public partial class frm_filtros : Form
    {
        string id_seleccionado = ""; //El id que se seleccione del Data View Grid
        bool dependencia = false, tipo = false, estado = false, f_envio = false, f_recibido = false, rango = false;

        public frm_filtros()
        {
            InitializeComponent();
            //Llenar ComboBox
            Conexion Conex = new Conexion();
            Conex.llenarDependencias(cmb_dependencias);
            Conex.llenarTipo(cmb_tipo);
            Conex.llenarEstados(cmb_estado);
            Conex.ConexionClose();
        }

        public void llenarDataGrid(string where)
        {
            
            Conexion c = new Conexion();
            //Se especifica aun lado de cada atributo, de que tabla se van a extraer
            string valores = "Oficio.id as 'Id', Oficio.Asunto, Oficio.Fecha_envio as 'Fecha Envio', Oficio.Fecha_recibido as 'Fecha Recibido', Dependencia.Nombre as 'Dependencia', Tipo.Nombre as ' Tipo', Estado.Nombre as 'Estado'";
            //Esta cadena funcionara como vista, para traer el NOMBRE y no el ID de Dependencia, Tipo y Estado
            string from = "Oficio INNER JOIN ";
            from += "	     Tipo ON Oficio.id_tipo = Tipo.id ";
            from += "	   INNER JOIN ";
            from += "         Dependencia ON Oficio.id_dependencia = Dependencia.id ";
            from += "	   INNER JOIN ";
            from += "         Estado ON Oficio.id_estado = Estado.id";
            if (where == "")
            {
                dgv_oficios.DataSource = c.Select(valores, from);
            }
            else
            {
                dgv_oficios.DataSource = c.Select(valores, from, where);
            }
            dgv_oficios.Columns[0].Width = 60;
            dgv_oficios.Columns[1].Width = 140;
            dgv_oficios.Columns[4].Width = 148; //Hacemos un poco mas ancha la columna Dependencia
            c.ConexionClose();
        }
        //Metodo para obtener el Id de Dependencia, Tipo, Estado
        public string obtenerId(string cadena)
        {
            string id = "";
            for (int i = 0; i <= cadena.Length; i++)
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
            chb_dependencia.Checked = false;
            rb_f_envio.Checked = false;
            chb_estado.Checked = false;
            rb_f_recibido.Checked = false;
            chb_tipo.Checked = false;
            cmb_dependencias.SelectedIndex = -1;
            cmb_tipo.SelectedIndex = -1;
            cmb_estado.SelectedIndex = -1;
            dtp_inicio.Value = DateTime.Today;
            dtp_final.Value = DateTime.Today;
            chb_rango.Checked = false;
            chb_rango.Enabled = false;
        }
        private void verificarChecks()
        {
            if (chb_dependencia.Checked == true)
            {
                dependencia = true;
            }
            else
            {
                dependencia = false;
            }
            if (chb_tipo.Checked == true)
            {
                tipo = true;
            }
            else
            {
                tipo = false;
            }
            if (chb_estado.Checked == true)
            {
                estado = true;
            }
            else
            {
                estado = false;
            }
            if (rb_f_envio.Checked == true)
            {
                f_envio = true;
            }
            else
            {
                f_envio = false;
            }
            if (rb_f_recibido.Checked == true)
            {
                f_recibido = true;
            }
            else
            {
                f_recibido = false;
            }
            if (chb_rango.Checked == true)
            {
                rango = true;
            }
            else
            {
                rango = false;
            }
        }
        private void frm_filtros_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'oficiosDataSet.Oficio' Puede moverla o quitarla según sea necesario.
            //this.oficioTableAdapter.Fill(this.oficiosDataSet.Oficio);
            llenarDataGrid(""); //Le mandamos "" porque no hay condicion where en este caso
        }

        void dgv_oficios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Cuando e.RowIndex es -1 es porque se dio click a los titulos de las columnas
            if (e.RowIndex != -1)
            {
                id_seleccionado = dgv_oficios.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void abrir_abc_oficios(char accion)
        {
            frm_oficios abc = new frm_oficios(id_seleccionado, accion);
            Program.filtros.Hide(); //El "filtros" es el formulario frm_filtros, esto se especifico en el archivo "Program.cs"
            abc.Show();
            id_seleccionado = "";
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            abrir_abc_oficios('A'); //Alta
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            abrir_abc_oficios('B'); //Baja
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            abrir_abc_oficios('C'); //Cambio
        }

        private void chb_dependencia_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_dependencia.Checked == true)
            {
                cmb_dependencias.Enabled = true;
                dependencia = true;
            }
            else
            {
                cmb_dependencias.Enabled = false;
                dependencia = false;
                cmb_dependencias.SelectedIndex = -1;
            }
        }

        private void chb_tipo_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_tipo.Checked == true)
            {
                cmb_tipo.Enabled = true;
                tipo = true;
            }
            else
            {
                cmb_tipo.Enabled = false;
                tipo = false;
                cmb_tipo.SelectedIndex = -1;
            }
        }

        private void chb_estado_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_estado.Checked == true)
            {
                cmb_estado.Enabled = true;
                estado = true;
            }
            else
            {
                cmb_estado.Enabled = false;
                estado = false;
                cmb_estado.SelectedIndex = -1;
            }
        }

        private void rb_f_envio_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rb_f_envio.Checked == true)
            {
                f_envio = true;
                f_recibido = false;
                chb_rango.Enabled = true;
                dtp_inicio.Enabled = true;
            }
            else
            {
                f_envio = false;
            }
        }

        private void rb_f_recibido_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rb_f_recibido.Checked == true)
            {
                f_recibido = true;
                f_envio = false;
                chb_rango.Enabled = true;
                dtp_inicio.Enabled = true;
            }
            else
            {
                f_recibido = false;
            }
        }

        private void chb_rango_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_rango.Checked)
            {
                rango = true;
                lbl_fecha_inicio.Text = "Fecha Inicio";
                lbl_fecha_final.Visible = true;
                dtp_final.Visible = true;
            }
            else
            {
                rango = false;
                lbl_fecha_inicio.Text = "Fecha";
                lbl_fecha_final.Visible = false;
                dtp_final.Visible = false;
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            //Validacion de que al menos un checkbox este marcado
            if (chb_dependencia.Checked || rb_f_envio.Checked || chb_estado.Checked || rb_f_recibido.Checked || chb_tipo.Checked)
            {
                //Validacion de que si hay un checkbox marcado, este tenga una opcion de su combobox seleccionada
                if (cmb_dependencias.Text == "" && chb_dependencia.Checked)
                {
                    MessageBox.Show("Selecciona una Dependencia");
                }
                else if(cmb_tipo.Text == "" && chb_tipo.Checked)
                {
                    MessageBox.Show("Selecciona un Tipo");
                }
                else if (cmb_estado.Text == "" && chb_estado.Checked)
                {
                    MessageBox.Show("Selecciona un Estado");
                }
                else
                {
                    if ((dtp_final.Value < dtp_inicio.Value) && (chb_rango.Checked))
                    {
                        MessageBox.Show("La Fecha de Recibido no puede ser anterior a la Fecha de Envio");
                    }
                    else
                    {
                        bool salir;
                        string where = "";
                        //Generar la cadena Where para hacer la consulta a la BD con el siguiente ciclo do..while
                        do
                        {
                            salir = true;
                            if (dependencia == true)
                            {
                                where += "id_dependencia = " + obtenerId(cmb_dependencias.Text);
                                dependencia = false;
                                salir = false;
                            }
                            else if (tipo == true)
                            {
                                where += "id_tipo = " + obtenerId(cmb_tipo.Text);
                                tipo = false;
                                salir = false;
                            }
                            else if (estado == true)
                            {
                                where += "id_estado = " + obtenerId(cmb_estado.Text);
                                estado = false;
                                salir = false;
                            }
                            else if (rango == true)
                            {
                                if (f_envio == true)
                                {
                                    where += "Fecha_envio >= '" + dtp_inicio.Value.Date.ToString("yyyy-MM-dd") + "' and Fecha_envio <= '" + dtp_final.Value.Date.ToString("yyyy-MM-dd") + "'";
                                    f_envio = false;
                                    rango = false;
                                    salir = false;
                                }
                                else if (f_recibido == true)
                                {
                                    where += "Fecha_recibido >= '" + dtp_inicio.Value.Date.ToString("yyyy-MM-dd") + "' and Fecha_recibido <= '" + dtp_final.Value.Date.ToString("yyyy-MM-dd") + "'";
                                    f_recibido = false;
                                    rango = false;
                                    salir = false;
                                }
                            }
                            else if (f_envio == true)
                            {
                                where += "Fecha_envio = '" + dtp_inicio.Value.Date.ToString("yyyy-MM-dd") + "'";
                                f_envio = false;
                                salir = false;
                            }
                            else if (f_recibido == true)
                            {
                                where += "Fecha_recibido = '" + dtp_inicio.Value.Date.ToString("yyyy-MM-dd") + "'";
                                f_recibido = false;
                                salir = false;
                            }

                            where += " and ";

                        } while (salir == false);
                        where = where.Substring(0, where.Length - 10); //Borramos las 2 ultimas comas que sobran en la cadena
                        llenarDataGrid(where); //Le mandamos la condicion where
                        verificarChecks(); //Para poner las variables booleanas como estaban antes del ciclo
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione al menos un Filtro de busqueda");
            }
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void btn_mostrar_todo_Click(object sender, EventArgs e)
        {
            llenarDataGrid("");
        }

        

        
        

    }
}