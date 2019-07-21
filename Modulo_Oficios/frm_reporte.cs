using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Modulo_Oficios
{
    public partial class frm_reporte : Form
    {
        Data_Set ds = new Data_Set(); //Creamos un objeto del tipo Data_Set que nosotros creamos y contiene una tabla "tabla_oficios"
        public frm_reporte(DataTable tabla) //Recibiremos una tabla desde el frm_filtros la cual usaremos para desplegar un reporte
        {
            InitializeComponent();
            //Agregamos el contenido de la tabla recibida, a la tabla contenida en el DataSet
            foreach (DataRow row in tabla.Rows)
            {
                if (row["Fecha Respuesta"].ToString() == "")
                    ds.tabla_oficios.Rows.Add(row["id"].ToString(), row["Asunto"].ToString(), row["Fecha Envio"].ToString().Substring(0, 10), row["Fecha Respuesta"].ToString(), row["Dependencia"].ToString(), row["Tipo"].ToString(), row["Estado"].ToString());
                else
                    ds.tabla_oficios.Rows.Add(row["id"].ToString(), row["Asunto"].ToString(), row["Fecha Envio"].ToString().Substring(0, 10), row["Fecha Respuesta"].ToString().Substring(0, 10), row["Dependencia"].ToString(), row["Tipo"].ToString(), row["Estado"].ToString());
            }
        }

        public frm_reporte()
        {
            // TODO: Complete member initialization
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void frm_reporte_Load(object sender, EventArgs e)
        {
            reporte_oficios rpt = new reporte_oficios(); //Creamos un objeto de tipo .rpt que tenemos creado en el proyecto
            rpt.SetDataSource(ds); //Le agregamos la fuente de los datos al objeto reporte que creamos
            crystalReportViewer1.ReportSource = rpt; //Y al visor de reportes de cristal reports le mandamos el reporte,
                                                     //para que cuando se abra, se muestre dicho reporte
        }

        private void regresarAlMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_reporte_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.filtros.Show();
            Program.filtros.llenarDataGrid("");
        }
    }
}
