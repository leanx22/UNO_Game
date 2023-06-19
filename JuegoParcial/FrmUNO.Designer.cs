namespace JuegoParcial
{
    partial class FrmUNO
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
            lblEventos = new Label();
            lBoxLean = new ListBox();
            lBoxJuan = new ListBox();
            lblCartaEnMesa = new Label();
            SuspendLayout();
            // 
            // lblEventos
            // 
            lblEventos.AutoSize = true;
            lblEventos.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblEventos.Location = new Point(365, 411);
            lblEventos.Name = "lblEventos";
            lblEventos.Size = new Size(72, 30);
            lblEventos.TabIndex = 0;
            lblEventos.Text = "label1";
            // 
            // lBoxLean
            // 
            lBoxLean.FormattingEnabled = true;
            lBoxLean.ItemHeight = 15;
            lBoxLean.Location = new Point(317, 272);
            lBoxLean.Name = "lBoxLean";
            lBoxLean.Size = new Size(159, 124);
            lBoxLean.TabIndex = 1;
            // 
            // lBoxJuan
            // 
            lBoxJuan.FormattingEnabled = true;
            lBoxJuan.ItemHeight = 15;
            lBoxJuan.Location = new Point(317, 12);
            lBoxJuan.Name = "lBoxJuan";
            lBoxJuan.Size = new Size(159, 124);
            lBoxJuan.TabIndex = 2;
            // 
            // lblCartaEnMesa
            // 
            lblCartaEnMesa.AutoSize = true;
            lblCartaEnMesa.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblCartaEnMesa.Location = new Point(365, 199);
            lblCartaEnMesa.Name = "lblCartaEnMesa";
            lblCartaEnMesa.Size = new Size(51, 21);
            lblCartaEnMesa.TabIndex = 3;
            lblCartaEnMesa.Text = "label1";
            // 
            // FrmUNO
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblCartaEnMesa);
            Controls.Add(lBoxJuan);
            Controls.Add(lBoxLean);
            Controls.Add(lblEventos);
            Name = "FrmUNO";
            Text = "FrmUNO";
            Load += FrmUNO_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEventos;
        private ListBox lBoxLean;
        private ListBox lBoxJuan;
        private Label lblCartaEnMesa;
    }
}