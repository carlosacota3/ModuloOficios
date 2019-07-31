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
    public partial class frm_seleccion_dependencia : Form
    {
        public frm_seleccion_dependencia(List<string> DepsSelecc)
        {
            InitializeComponent();
            foreach (var item in DepsSelecc)
            {
                lb_dependencias.Items.Add(item);
            }
            
        }

        public string Dependencia { get; set; }


        private void lb_dependencias_DoubleClick(object sender, EventArgs e)
        {
            if (lb_dependencias.SelectedItem != null)
            {
                Dependencia = lb_dependencias.SelectedItem.ToString();
                this.Close();
            }
        }
    }
}
