using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modulo_Oficios
{
    public partial class frm_max_datagrid_oficios : Form
    {
        public frm_max_datagrid_oficios(DataTable table)
        {
            InitializeComponent();
            dgv_oficios.DataSource = table;
            //Hacemos un poco mas pequeña la columna de Id
        }

        public int row_seleccionada { set; get; }

        private void dgv_oficios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Cuando e.RowIndex es -1 es porque se dio click a los titulos de las columnas
            if (e.RowIndex != -1)
            {
                row_seleccionada = e.RowIndex;
                this.Close();
            }
        }

        private void frm_max_datagrid_oficios_Load(object sender, EventArgs e)
        {
            //Valor que regresará en caso de que no se seleccione ninguna columna (o se seleccionen los titulos de columna)
            //y se cierre el formulario
            row_seleccionada = -1;
            dgv_oficios.Columns[0].Width = 90;  //Id
            dgv_oficios.Columns[2].Width = 110; //Fecha Envio
            dgv_oficios.Columns[3].Width = 130; //Fecha Respuesta
            dgv_oficios.Columns[5].Width = 200; //Tipo
            dgv_oficios.Columns[6].Width = 200; //Estado
        }

    }
}
