namespace T3_P_ORM_SQL.Vistas.Citas_Crud
{
    partial class Citas_Crear
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Citas_Crear));
            label1 = new Label();
            BtnAgendar = new Button();
            monthCalendar1 = new MonthCalendar();
            CmbDoctor = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            CmbPaciente = new ComboBox();
            label4 = new Label();
            CmbHorario = new ComboBox();
            textBox1 = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(196, 37);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 0;
            label1.Text = "Agendar una Cita";
            // 
            // BtnAgendar
            // 
            BtnAgendar.Location = new Point(179, 459);
            BtnAgendar.Name = "BtnAgendar";
            BtnAgendar.Size = new Size(116, 23);
            BtnAgendar.TabIndex = 1;
            BtnAgendar.Text = "Agendar Cita";
            BtnAgendar.UseVisualStyleBackColor = true;
            BtnAgendar.Click += BtnAgendar_Click;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(122, 74);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.SelectionRange = new SelectionRange(new DateTime(2025, 10, 5, 0, 0, 0, 0), new DateTime(2025, 10, 11, 0, 0, 0, 0));
            monthCalendar1.TabIndex = 2;
            // 
            // CmbDoctor
            // 
            CmbDoctor.FormattingEnabled = true;
            CmbDoctor.Location = new Point(131, 266);
            CmbDoctor.Name = "CmbDoctor";
            CmbDoctor.Size = new Size(223, 23);
            CmbDoctor.TabIndex = 3;
            CmbDoctor.SelectedIndexChanged += CmbDoctor_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(221, 245);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 4;
            label2.Text = "Doctor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(221, 296);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 6;
            label3.Text = "Paciente";
            // 
            // CmbPaciente
            // 
            CmbPaciente.FormattingEnabled = true;
            CmbPaciente.Location = new Point(131, 317);
            CmbPaciente.Name = "CmbPaciente";
            CmbPaciente.Size = new Size(223, 23);
            CmbPaciente.TabIndex = 5;
            CmbPaciente.SelectedIndexChanged += CmbPaciente_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(221, 343);
            label4.Name = "label4";
            label4.Size = new Size(47, 15);
            label4.TabIndex = 8;
            label4.Text = "Horario";
            // 
            // CmbHorario
            // 
            CmbHorario.FormattingEnabled = true;
            CmbHorario.Location = new Point(131, 364);
            CmbHorario.Name = "CmbHorario";
            CmbHorario.Size = new Size(223, 23);
            CmbHorario.TabIndex = 7;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(131, 417);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(223, 23);
            textBox1.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(221, 399);
            label5.Name = "label5";
            label5.Size = new Size(45, 15);
            label5.TabIndex = 10;
            label5.Text = "Motivo";
            // 
            // Citas_Crear
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(477, 489);
            Controls.Add(label5);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(CmbHorario);
            Controls.Add(label3);
            Controls.Add(CmbPaciente);
            Controls.Add(label2);
            Controls.Add(CmbDoctor);
            Controls.Add(monthCalendar1);
            Controls.Add(BtnAgendar);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Citas_Crear";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agendar Cita";
            Load += Citas_Crear_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button BtnAgendar;
        private MonthCalendar monthCalendar1;
        private ComboBox CmbDoctor;
        private Label label2;
        private Label label3;
        private ComboBox CmbPaciente;
        private Label label4;
        private ComboBox CmbHorario;
        private TextBox textBox1;
        private Label label5;
    }
}