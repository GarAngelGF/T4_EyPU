namespace T3_P_ORM_SQL
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            Titulo = new Label();
            CitasBtn = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // Titulo
            // 
            Titulo.AutoSize = true;
            Titulo.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Titulo.Location = new Point(49, 23);
            Titulo.Name = "Titulo";
            Titulo.Size = new Size(230, 74);
            Titulo.TabIndex = 0;
            Titulo.Text = "Tarea 3 \r\nRegistro de citas";
            Titulo.TextAlign = ContentAlignment.MiddleCenter;
            Titulo.Click += Titulo_Click;
            // 
            // CitasBtn
            // 
            CitasBtn.Location = new Point(79, 203);
            CitasBtn.Name = "CitasBtn";
            CitasBtn.Size = new Size(170, 23);
            CitasBtn.TabIndex = 1;
            CitasBtn.Text = "Citas";
            CitasBtn.UseVisualStyleBackColor = true;
            CitasBtn.Click += CitasBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(106, 97);
            label1.Name = "label1";
            label1.Size = new Size(112, 20);
            label1.TabIndex = 4;
            label1.Text = "Elaborado por:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(93, 127);
            label2.Name = "label2";
            label2.Size = new Size(140, 60);
            label2.TabIndex = 5;
            label2.Text = "Gárcia Francisco Ángel \r\nPérez Nava Yael Mauricio\r\nSerrano Acosta Alejandro\r\nTrejo López Fernando";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(334, 259);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(CitasBtn);
            Controls.Add(Titulo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Main";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu Principal T3";
            Load += Main_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Titulo;
        private Button CitasBtn;
        private Label label1;
        private Label label2;
    }
}
