namespace T3_P_ORM_SQL.Vistas.Citas_Crud
{
    partial class Citas_Ver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Citas_Ver));
            DgvCitas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DgvCitas).BeginInit();
            SuspendLayout();
            // 
            // DgvCitas
            // 
            DgvCitas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvCitas.Location = new Point(12, 12);
            DgvCitas.Name = "DgvCitas";
            DgvCitas.Size = new Size(607, 241);
            DgvCitas.TabIndex = 0;
            // 
            // Citas_Ver
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(631, 274);
            Controls.Add(DgvCitas);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Citas_Ver";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ver Citas";
            Load += Citas_Ver_Load;
            ((System.ComponentModel.ISupportInitialize)DgvCitas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DgvCitas;
    }
}