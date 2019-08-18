namespace Modulo_Oficios
{
    partial class frm_max_datagrid_oficios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_max_datagrid_oficios));
            this.dgv_oficios = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_oficios)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_oficios
            // 
            this.dgv_oficios.AllowUserToDeleteRows = false;
            this.dgv_oficios.AllowUserToOrderColumns = true;
            this.dgv_oficios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_oficios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_oficios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_oficios.Location = new System.Drawing.Point(0, 0);
            this.dgv_oficios.Margin = new System.Windows.Forms.Padding(5);
            this.dgv_oficios.Name = "dgv_oficios";
            this.dgv_oficios.ReadOnly = true;
            this.dgv_oficios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_oficios.Size = new System.Drawing.Size(379, 321);
            this.dgv_oficios.TabIndex = 1;
            this.dgv_oficios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_oficios_CellDoubleClick);
            // 
            // frm_max_datagrid_oficios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 321);
            this.Controls.Add(this.dgv_oficios);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_max_datagrid_oficios";
            this.Text = "Oficios";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_max_datagrid_oficios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_oficios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_oficios;
    }
}