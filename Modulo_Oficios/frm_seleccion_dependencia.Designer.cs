namespace Modulo_Oficios
{
    partial class frm_seleccion_dependencia
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_seleccion_dependencia));
            this.lb_dependencias = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lb_dependencias
            // 
            this.lb_dependencias.Cursor = System.Windows.Forms.Cursors.Default;
            this.lb_dependencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lb_dependencias.FormattingEnabled = true;
            this.lb_dependencias.ItemHeight = 18;
            this.lb_dependencias.Location = new System.Drawing.Point(14, 14);
            this.lb_dependencias.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lb_dependencias.Name = "lb_dependencias";
            this.lb_dependencias.Size = new System.Drawing.Size(483, 148);
            this.lb_dependencias.TabIndex = 36;
            this.lb_dependencias.DoubleClick += new System.EventHandler(this.lb_dependencias_DoubleClick);
            // 
            // frm_seleccion_dependencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 180);
            this.Controls.Add(this.lb_dependencias);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frm_seleccion_dependencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccion Dependencia";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lb_dependencias;
    }
}