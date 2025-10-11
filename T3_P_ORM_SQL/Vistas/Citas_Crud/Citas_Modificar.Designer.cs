namespace T3_P_ORM_SQL.Vistas.Citas_Crud
{
    partial class Citas_Modificar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Citas_Modificar));
            label5 = new Label();
            textBox1 = new TextBox();
            label4 = new Label();
            CmbHorario = new ComboBox();
            label3 = new Label();
            CmbPaciente = new ComboBox();
            CmbDoctor = new ComboBox();
            BtnModificar = new Button();
            label1 = new Label();
            DgvCitas = new DataGridView();
            label2 = new Label();
            BtnGuardar = new Button();
            BtnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)DgvCitas).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(300, 362);
            label5.Name = "label5";
            label5.Size = new Size(45, 15);
            label5.TabIndex = 21;
            label5.Text = "Motivo";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(210, 380);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(223, 23);
            textBox1.TabIndex = 20;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(300, 306);
            label4.Name = "label4";
            label4.Size = new Size(47, 15);
            label4.TabIndex = 19;
            label4.Text = "Horario";
            // 
            // CmbHorario
            // 
            CmbHorario.FormattingEnabled = true;
            CmbHorario.Location = new Point(210, 327);
            CmbHorario.Name = "CmbHorario";
            CmbHorario.Size = new Size(223, 23);
            CmbHorario.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(300, 259);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 17;
            label3.Text = "Paciente";
            // 
            // CmbPaciente
            // 
            CmbPaciente.FormattingEnabled = true;
            CmbPaciente.Location = new Point(210, 280);
            CmbPaciente.Name = "CmbPaciente";
            CmbPaciente.Size = new Size(223, 23);
            CmbPaciente.TabIndex = 16;
            // 
            // CmbDoctor
            // 
            CmbDoctor.FormattingEnabled = true;
            CmbDoctor.Location = new Point(210, 229);
            CmbDoctor.Name = "CmbDoctor";
            CmbDoctor.Size = new Size(223, 23);
            CmbDoctor.TabIndex = 14;
            // 
            // BtnModificar
            // 
            BtnModificar.Location = new Point(141, 422);
            BtnModificar.Name = "BtnModificar";
            BtnModificar.Size = new Size(116, 23);
            BtnModificar.TabIndex = 12;
            BtnModificar.Text = "Modificar Cita";
            BtnModificar.UseVisualStyleBackColor = true;
            BtnModificar.Click += BtnModificar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(274, 9);
            label1.Name = "label1";
            label1.Size = new Size(105, 15);
            label1.TabIndex = 11;
            label1.Text = "Modificar una Cita";
            // 
            // DgvCitas
            // 
            DgvCitas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvCitas.Location = new Point(40, 36);
            DgvCitas.Name = "DgvCitas";
            DgvCitas.Size = new Size(585, 171);
            DgvCitas.TabIndex = 22;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(300, 210);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 23;
            label2.Text = "Doctor";
            // 
            // BtnGuardar
            // 
            BtnGuardar.Location = new Point(263, 422);
            BtnGuardar.Name = "BtnGuardar";
            BtnGuardar.Size = new Size(116, 23);
            BtnGuardar.TabIndex = 24;
            BtnGuardar.Text = "Guardar";
            BtnGuardar.UseVisualStyleBackColor = true;
            BtnGuardar.Click += BtnGuardar_Click;
            // 
            // BtnCancelar
            // 
            BtnCancelar.Location = new Point(385, 422);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(116, 23);
            BtnCancelar.TabIndex = 25;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.UseVisualStyleBackColor = true;
            BtnCancelar.Click += BtnCancelar_Click;
            // 
            // Citas_Modificar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(668, 457);
            Controls.Add(BtnCancelar);
            Controls.Add(BtnGuardar);
            Controls.Add(label2);
            Controls.Add(DgvCitas);
            Controls.Add(label5);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(CmbHorario);
            Controls.Add(label3);
            Controls.Add(CmbPaciente);
            Controls.Add(CmbDoctor);
            Controls.Add(BtnModificar);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Citas_Modificar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modificar Citas";
            Load += Citas_Modificar_Load;
            ((System.ComponentModel.ISupportInitialize)DgvCitas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private TextBox textBox1;
        private Label label4;
        private ComboBox CmbHorario;
        private Label label3;
        private ComboBox CmbPaciente;
        private ComboBox CmbDoctor;
        private Button BtnModificar;
        private Label label1;
        private DataGridView DgvCitas;
        private Label label2;
        private Button BtnGuardar;
        private Button BtnCancelar;
    }
}