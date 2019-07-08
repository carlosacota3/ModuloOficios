namespace Modulo_Oficios
{
    partial class frm_oficios
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_oficios));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.txt_asunto = new System.Windows.Forms.TextBox();
            this.cmb_dependencias = new System.Windows.Forms.ComboBox();
            this.cmb_tipo = new System.Windows.Forms.ComboBox();
            this.cmb_estado = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_modificar = new System.Windows.Forms.RadioButton();
            this.rb_eliminar = new System.Windows.Forms.RadioButton();
            this.rb_registrar = new System.Windows.Forms.RadioButton();
            this.dtp_recibido = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtp_envio = new System.Windows.Forms.DateTimePicker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btn_regresar = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.btn_accion = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(333, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registro de Oficios";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(96, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(57, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Asunto";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(57, 399);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Dependencia";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(117, 455);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Tipo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(471, 458);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Estado";
            // 
            // txt_id
            // 
            this.txt_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_id.Location = new System.Drawing.Point(130, 168);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(100, 23);
            this.txt_id.TabIndex = 1;
            // 
            // txt_asunto
            // 
            this.txt_asunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_asunto.Location = new System.Drawing.Point(130, 197);
            this.txt_asunto.MaxLength = 1500;
            this.txt_asunto.Multiline = true;
            this.txt_asunto.Name = "txt_asunto";
            this.txt_asunto.Size = new System.Drawing.Size(605, 62);
            this.txt_asunto.TabIndex = 2;
            // 
            // cmb_dependencias
            // 
            this.cmb_dependencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_dependencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmb_dependencias.FormattingEnabled = true;
            this.cmb_dependencias.Location = new System.Drawing.Point(170, 396);
            this.cmb_dependencias.Name = "cmb_dependencias";
            this.cmb_dependencias.Size = new System.Drawing.Size(565, 24);
            this.cmb_dependencias.TabIndex = 5;
            // 
            // cmb_tipo
            // 
            this.cmb_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_tipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmb_tipo.FormattingEnabled = true;
            this.cmb_tipo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cmb_tipo.Location = new System.Drawing.Point(170, 452);
            this.cmb_tipo.Name = "cmb_tipo";
            this.cmb_tipo.Size = new System.Drawing.Size(191, 24);
            this.cmb_tipo.TabIndex = 6;
            // 
            // cmb_estado
            // 
            this.cmb_estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmb_estado.FormattingEnabled = true;
            this.cmb_estado.Location = new System.Drawing.Point(544, 455);
            this.cmb_estado.Name = "cmb_estado";
            this.cmb_estado.Size = new System.Drawing.Size(191, 24);
            this.cmb_estado.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_modificar);
            this.groupBox1.Controls.Add(this.rb_eliminar);
            this.groupBox1.Controls.Add(this.rb_registrar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox1.Location = new System.Drawing.Point(60, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 80);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Accion a Realizar";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // rb_modificar
            // 
            this.rb_modificar.AutoSize = true;
            this.rb_modificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rb_modificar.Location = new System.Drawing.Point(171, 25);
            this.rb_modificar.Name = "rb_modificar";
            this.rb_modificar.Size = new System.Drawing.Size(123, 21);
            this.rb_modificar.TabIndex = 11;
            this.rb_modificar.Text = "Modificar Oficio";
            this.rb_modificar.UseVisualStyleBackColor = true;
            this.rb_modificar.CheckedChanged += new System.EventHandler(this.rb_modificar_CheckedChanged);
            // 
            // rb_eliminar
            // 
            this.rb_eliminar.AutoSize = true;
            this.rb_eliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rb_eliminar.Location = new System.Drawing.Point(325, 25);
            this.rb_eliminar.Name = "rb_eliminar";
            this.rb_eliminar.Size = new System.Drawing.Size(116, 21);
            this.rb_eliminar.TabIndex = 12;
            this.rb_eliminar.Text = "Eliminar Oficio";
            this.rb_eliminar.UseVisualStyleBackColor = true;
            this.rb_eliminar.CheckedChanged += new System.EventHandler(this.rb_eliminar_CheckedChanged);
            // 
            // rb_registrar
            // 
            this.rb_registrar.AutoSize = true;
            this.rb_registrar.Checked = true;
            this.rb_registrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rb_registrar.Location = new System.Drawing.Point(17, 22);
            this.rb_registrar.Name = "rb_registrar";
            this.rb_registrar.Size = new System.Drawing.Size(124, 21);
            this.rb_registrar.TabIndex = 10;
            this.rb_registrar.TabStop = true;
            this.rb_registrar.Text = "Registrar Oficio";
            this.rb_registrar.UseVisualStyleBackColor = true;
            this.rb_registrar.CheckedChanged += new System.EventHandler(this.rb_registrar_CheckedChanged_1);
            // 
            // dtp_recibido
            // 
            this.dtp_recibido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtp_recibido.Location = new System.Drawing.Point(441, 322);
            this.dtp_recibido.Name = "dtp_recibido";
            this.dtp_recibido.Size = new System.Drawing.Size(321, 23);
            this.dtp_recibido.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(168, 299);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha Envio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(546, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Fecha Recibido";
            // 
            // dtp_envio
            // 
            this.dtp_envio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtp_envio.Location = new System.Drawing.Point(60, 322);
            this.dtp_envio.Name = "dtp_envio";
            this.dtp_envio.Size = new System.Drawing.Size(321, 23);
            this.dtp_envio.TabIndex = 3;
            // 
            // btn_regresar
            // 
            this.btn_regresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btn_regresar.Image = global::Modulo_Oficios.Properties.Resources.regresar_reducida;
            this.btn_regresar.Location = new System.Drawing.Point(12, 12);
            this.btn_regresar.Name = "btn_regresar";
            this.btn_regresar.Size = new System.Drawing.Size(55, 34);
            this.btn_regresar.TabIndex = 33;
            this.btn_regresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_regresar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btn_regresar, "Regresar al Menu Principal");
            this.btn_regresar.UseVisualStyleBackColor = true;
            this.btn_regresar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_limpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btn_limpiar.Image = global::Modulo_Oficios.Properties.Resources.reinicio_redu;
            this.btn_limpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_limpiar.Location = new System.Drawing.Point(247, 589);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_limpiar.Size = new System.Drawing.Size(362, 35);
            this.btn_limpiar.TabIndex = 9;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // btn_accion
            // 
            this.btn_accion.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_accion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btn_accion.Image = global::Modulo_Oficios.Properties.Resources.guardar_reducido;
            this.btn_accion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_accion.Location = new System.Drawing.Point(247, 511);
            this.btn_accion.Name = "btn_accion";
            this.btn_accion.Size = new System.Drawing.Size(362, 52);
            this.btn_accion.TabIndex = 8;
            this.btn_accion.Text = "Registrar Oficio";
            this.btn_accion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_accion.UseVisualStyleBackColor = true;
            this.btn_accion.Click += new System.EventHandler(this.btn_accion_Click);
            // 
            // frm_oficios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(829, 658);
            this.Controls.Add(this.btn_regresar);
            this.Controls.Add(this.dtp_recibido);
            this.Controls.Add(this.dtp_envio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_accion);
            this.Controls.Add(this.cmb_estado);
            this.Controls.Add(this.cmb_tipo);
            this.Controls.Add(this.cmb_dependencias);
            this.Controls.Add(this.txt_asunto);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_oficios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Oficios";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_oficios_FormClosing);
            this.Load += new System.EventHandler(this.frm_oficios_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.TextBox txt_asunto;
        private System.Windows.Forms.ComboBox cmb_dependencias;
        private System.Windows.Forms.ComboBox cmb_tipo;
        private System.Windows.Forms.ComboBox cmb_estado;
        private System.Windows.Forms.Button btn_accion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_modificar;
        private System.Windows.Forms.RadioButton rb_eliminar;
        private System.Windows.Forms.RadioButton rb_registrar;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.DateTimePicker dtp_recibido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtp_envio;
        private System.Windows.Forms.Button btn_regresar;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

