namespace Modulo_Oficios
{
    partial class frm_filtros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_filtros));
            this.dgv_oficios = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.chb_tipo = new System.Windows.Forms.CheckBox();
            this.chb_estado = new System.Windows.Forms.CheckBox();
            this.cmb_tipo = new System.Windows.Forms.ComboBox();
            this.cmb_estado = new System.Windows.Forms.ComboBox();
            this.chb_dependencia = new System.Windows.Forms.CheckBox();
            this.cmb_dependencias = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtp_final = new System.Windows.Forms.DateTimePicker();
            this.dtp_inicio = new System.Windows.Forms.DateTimePicker();
            this.lbl_fecha_final = new System.Windows.Forms.Label();
            this.lbl_fecha_inicio = new System.Windows.Forms.Label();
            this.chb_rango = new System.Windows.Forms.CheckBox();
            this.rb_f_recibido = new System.Windows.Forms.RadioButton();
            this.rb_f_envio = new System.Windows.Forms.RadioButton();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_oficios)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_oficios
            // 
            this.dgv_oficios.AllowUserToDeleteRows = false;
            this.dgv_oficios.AllowUserToOrderColumns = true;
            this.dgv_oficios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_oficios.Location = new System.Drawing.Point(31, 383);
            this.dgv_oficios.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_oficios.Name = "dgv_oficios";
            this.dgv_oficios.ReadOnly = true;
            this.dgv_oficios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_oficios.Size = new System.Drawing.Size(791, 245);
            this.dgv_oficios.TabIndex = 0;
            this.dgv_oficios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_oficios_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(341, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "Filtros de Busqueda";
            // 
            // chb_tipo
            // 
            this.chb_tipo.AutoSize = true;
            this.chb_tipo.Location = new System.Drawing.Point(30, 99);
            this.chb_tipo.Name = "chb_tipo";
            this.chb_tipo.Size = new System.Drawing.Size(55, 21);
            this.chb_tipo.TabIndex = 1;
            this.chb_tipo.Text = "Tipo";
            this.chb_tipo.UseVisualStyleBackColor = true;
            this.chb_tipo.CheckedChanged += new System.EventHandler(this.chb_tipo_CheckedChanged);
            // 
            // chb_estado
            // 
            this.chb_estado.AutoSize = true;
            this.chb_estado.Location = new System.Drawing.Point(31, 156);
            this.chb_estado.Name = "chb_estado";
            this.chb_estado.Size = new System.Drawing.Size(71, 21);
            this.chb_estado.TabIndex = 2;
            this.chb_estado.Text = "Estado";
            this.chb_estado.UseVisualStyleBackColor = true;
            this.chb_estado.CheckedChanged += new System.EventHandler(this.chb_estado_CheckedChanged);
            // 
            // cmb_tipo
            // 
            this.cmb_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_tipo.Enabled = false;
            this.cmb_tipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmb_tipo.FormattingEnabled = true;
            this.cmb_tipo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cmb_tipo.Location = new System.Drawing.Point(30, 126);
            this.cmb_tipo.Name = "cmb_tipo";
            this.cmb_tipo.Size = new System.Drawing.Size(791, 24);
            this.cmb_tipo.Sorted = true;
            this.cmb_tipo.TabIndex = 7;
            // 
            // cmb_estado
            // 
            this.cmb_estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_estado.Enabled = false;
            this.cmb_estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmb_estado.FormattingEnabled = true;
            this.cmb_estado.Location = new System.Drawing.Point(31, 183);
            this.cmb_estado.Name = "cmb_estado";
            this.cmb_estado.Size = new System.Drawing.Size(790, 24);
            this.cmb_estado.Sorted = true;
            this.cmb_estado.TabIndex = 8;
            // 
            // chb_dependencia
            // 
            this.chb_dependencia.AutoSize = true;
            this.chb_dependencia.Location = new System.Drawing.Point(30, 42);
            this.chb_dependencia.Name = "chb_dependencia";
            this.chb_dependencia.Size = new System.Drawing.Size(111, 21);
            this.chb_dependencia.TabIndex = 0;
            this.chb_dependencia.Text = "Dependencia";
            this.chb_dependencia.UseVisualStyleBackColor = true;
            this.chb_dependencia.CheckedChanged += new System.EventHandler(this.chb_dependencia_CheckedChanged);
            // 
            // cmb_dependencias
            // 
            this.cmb_dependencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_dependencias.Enabled = false;
            this.cmb_dependencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmb_dependencias.FormattingEnabled = true;
            this.cmb_dependencias.Location = new System.Drawing.Point(30, 69);
            this.cmb_dependencias.Name = "cmb_dependencias";
            this.cmb_dependencias.Size = new System.Drawing.Size(791, 24);
            this.cmb_dependencias.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtp_final);
            this.groupBox2.Controls.Add(this.dtp_inicio);
            this.groupBox2.Controls.Add(this.lbl_fecha_final);
            this.groupBox2.Controls.Add(this.lbl_fecha_inicio);
            this.groupBox2.Controls.Add(this.chb_rango);
            this.groupBox2.Controls.Add(this.rb_f_recibido);
            this.groupBox2.Controls.Add(this.rb_f_envio);
            this.groupBox2.Location = new System.Drawing.Point(31, 213);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 163);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Por Fechas";
            // 
            // dtp_final
            // 
            this.dtp_final.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtp_final.Location = new System.Drawing.Point(28, 132);
            this.dtp_final.Name = "dtp_final";
            this.dtp_final.Size = new System.Drawing.Size(321, 23);
            this.dtp_final.TabIndex = 10;
            this.dtp_final.Visible = false;
            // 
            // dtp_inicio
            // 
            this.dtp_inicio.Enabled = false;
            this.dtp_inicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtp_inicio.Location = new System.Drawing.Point(25, 81);
            this.dtp_inicio.Name = "dtp_inicio";
            this.dtp_inicio.Size = new System.Drawing.Size(321, 23);
            this.dtp_inicio.TabIndex = 9;
            // 
            // lbl_fecha_final
            // 
            this.lbl_fecha_final.AutoSize = true;
            this.lbl_fecha_final.Location = new System.Drawing.Point(25, 112);
            this.lbl_fecha_final.Name = "lbl_fecha_final";
            this.lbl_fecha_final.Size = new System.Drawing.Size(81, 17);
            this.lbl_fecha_final.TabIndex = 15;
            this.lbl_fecha_final.Text = "Fecha Final";
            this.lbl_fecha_final.Visible = false;
            // 
            // lbl_fecha_inicio
            // 
            this.lbl_fecha_inicio.AutoSize = true;
            this.lbl_fecha_inicio.Location = new System.Drawing.Point(25, 62);
            this.lbl_fecha_inicio.Name = "lbl_fecha_inicio";
            this.lbl_fecha_inicio.Size = new System.Drawing.Size(47, 17);
            this.lbl_fecha_inicio.TabIndex = 14;
            this.lbl_fecha_inicio.Text = "Fecha";
            // 
            // chb_rango
            // 
            this.chb_rango.AutoSize = true;
            this.chb_rango.Enabled = false;
            this.chb_rango.Location = new System.Drawing.Point(111, 50);
            this.chb_rango.Name = "chb_rango";
            this.chb_rango.Size = new System.Drawing.Size(139, 21);
            this.chb_rango.TabIndex = 13;
            this.chb_rango.Text = "Rango de Fechas";
            this.chb_rango.UseVisualStyleBackColor = true;
            this.chb_rango.CheckedChanged += new System.EventHandler(this.chb_rango_CheckedChanged);
            // 
            // rb_f_recibido
            // 
            this.rb_f_recibido.AutoSize = true;
            this.rb_f_recibido.Location = new System.Drawing.Point(208, 25);
            this.rb_f_recibido.Name = "rb_f_recibido";
            this.rb_f_recibido.Size = new System.Drawing.Size(124, 21);
            this.rb_f_recibido.TabIndex = 12;
            this.rb_f_recibido.TabStop = true;
            this.rb_f_recibido.Text = "Fecha Recibido";
            this.rb_f_recibido.UseVisualStyleBackColor = true;
            this.rb_f_recibido.CheckedChanged += new System.EventHandler(this.rb_f_recibido_CheckedChanged_1);
            // 
            // rb_f_envio
            // 
            this.rb_f_envio.AutoSize = true;
            this.rb_f_envio.Location = new System.Drawing.Point(43, 23);
            this.rb_f_envio.Name = "rb_f_envio";
            this.rb_f_envio.Size = new System.Drawing.Size(104, 21);
            this.rb_f_envio.TabIndex = 11;
            this.rb_f_envio.TabStop = true;
            this.rb_f_envio.Text = "Fecha Envio";
            this.rb_f_envio.UseVisualStyleBackColor = true;
            this.rb_f_envio.CheckedChanged += new System.EventHandler(this.rb_f_envio_CheckedChanged_1);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_limpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btn_limpiar.Image = global::Modulo_Oficios.Properties.Resources.reinicio_redu;
            this.btn_limpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_limpiar.Location = new System.Drawing.Point(417, 307);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_limpiar.Size = new System.Drawing.Size(404, 36);
            this.btn_limpiar.TabIndex = 15;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // btn_buscar
            // 
            this.btn_buscar.Image = global::Modulo_Oficios.Properties.Resources.lupa2_reducida;
            this.btn_buscar.Location = new System.Drawing.Point(418, 264);
            this.btn_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(403, 36);
            this.btn_buscar.TabIndex = 14;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // btn_modificar
            // 
            this.btn_modificar.Image = global::Modulo_Oficios.Properties.Resources.lapiz_reducido;
            this.btn_modificar.Location = new System.Drawing.Point(589, 636);
            this.btn_modificar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(233, 50);
            this.btn_modificar.TabIndex = 3;
            this.btn_modificar.Text = "Modificar";
            this.btn_modificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_modificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_modificar.UseVisualStyleBackColor = true;
            this.btn_modificar.Click += new System.EventHandler(this.btn_modificar_Click);
            // 
            // btn_agregar
            // 
            this.btn_agregar.Image = global::Modulo_Oficios.Properties.Resources.check_mark_reducida;
            this.btn_agregar.Location = new System.Drawing.Point(30, 636);
            this.btn_agregar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(233, 50);
            this.btn_agregar.TabIndex = 1;
            this.btn_agregar.Text = "Agregar";
            this.btn_agregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_agregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_agregar.UseVisualStyleBackColor = true;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Image = global::Modulo_Oficios.Properties.Resources.limpiar_red;
            this.btn_eliminar.Location = new System.Drawing.Point(309, 636);
            this.btn_eliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(233, 50);
            this.btn_eliminar.TabIndex = 2;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_eliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // frm_filtros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 710);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmb_dependencias);
            this.Controls.Add(this.chb_dependencia);
            this.Controls.Add(this.cmb_estado);
            this.Controls.Add(this.cmb_tipo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chb_estado);
            this.Controls.Add(this.btn_modificar);
            this.Controls.Add(this.chb_tipo);
            this.Controls.Add(this.btn_agregar);
            this.Controls.Add(this.dgv_oficios);
            this.Controls.Add(this.btn_eliminar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_filtros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";
            this.Load += new System.EventHandler(this.frm_filtros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_oficios)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_oficios;
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.Button btn_modificar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chb_tipo;
        private System.Windows.Forms.CheckBox chb_estado;
        private System.Windows.Forms.ComboBox cmb_tipo;
        private System.Windows.Forms.ComboBox cmb_estado;
        private System.Windows.Forms.CheckBox chb_dependencia;
        private System.Windows.Forms.ComboBox cmb_dependencias;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtp_final;
        private System.Windows.Forms.DateTimePicker dtp_inicio;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.RadioButton rb_f_recibido;
        private System.Windows.Forms.RadioButton rb_f_envio;
        private System.Windows.Forms.Label lbl_fecha_final;
        private System.Windows.Forms.Label lbl_fecha_inicio;
        private System.Windows.Forms.CheckBox chb_rango;
    }
}