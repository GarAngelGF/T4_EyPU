namespace T3_P_ORM_SQL.Vistas.Citas_Crud
{
    partial class Citas_Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Citas_Menu));
            BtnVer = new Button();
            Titulo = new Label();
            BtnCrear = new Button();
            BtnModificar = new Button();
            BtnEliminar = new Button();
            SuspendLayout();
            // 
            // BtnVer
            // 
            BtnVer.Location = new Point(63, 132);
            BtnVer.Name = "BtnVer";
            BtnVer.Size = new Size(107, 23);
            BtnVer.TabIndex = 0;
            BtnVer.Text = "Ver citas";
            BtnVer.UseVisualStyleBackColor = true;
            BtnVer.Click += BtnVer_Click;
            // 
            // Titulo
            // 
            Titulo.AutoSize = true;
            Titulo.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Titulo.Location = new Point(107, 47);
            Titulo.Name = "Titulo";
            Titulo.Size = new Size(199, 37);
            Titulo.TabIndex = 2;
            Titulo.Text = "Menu de Citas";
            Titulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BtnCrear
            // 
            BtnCrear.Location = new Point(240, 132);
            BtnCrear.Name = "BtnCrear";
            BtnCrear.Size = new Size(107, 23);
            BtnCrear.TabIndex = 3;
            BtnCrear.Text = "Crear Cita";
            BtnCrear.UseVisualStyleBackColor = true;
            BtnCrear.Click += BtnCrear_Click;
            // 
            // BtnModificar
            // 
            BtnModificar.Location = new Point(63, 170);
            BtnModificar.Name = "BtnModificar";
            BtnModificar.Size = new Size(107, 23);
            BtnModificar.TabIndex = 4;
            BtnModificar.Text = "Modificar Cita";
            BtnModificar.UseVisualStyleBackColor = true;
            BtnModificar.Click += BtnModificar_Click;
            // 
            // BtnEliminar
            // 
            BtnEliminar.Location = new Point(240, 170);
            BtnEliminar.Name = "BtnEliminar";
            BtnEliminar.Size = new Size(107, 23);
            BtnEliminar.TabIndex = 5;
            BtnEliminar.Text = "Eliminar Cita";
            BtnEliminar.UseVisualStyleBackColor = true;
            BtnEliminar.Click += BtnEliminar_Click;
            // 
            // Citas_Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(419, 285);
            Controls.Add(BtnEliminar);
            Controls.Add(BtnModificar);
            Controls.Add(BtnCrear);
            Controls.Add(Titulo);
            Controls.Add(BtnVer);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Citas_Menu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu de Citas";
            Load += Citas_Menu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnVer;
        private Label Titulo;
        private Button BtnCrear;
        private Button BtnModificar;
        private Button BtnEliminar;
    }
}