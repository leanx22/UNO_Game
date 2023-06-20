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
            lblJuan = new Label();
            lblLean = new Label();
            SuspendLayout();
            // 
            // lblEventos
            // 
            lblEventos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblEventos.AutoSize = true;
            lblEventos.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblEventos.Location = new Point(224, 432);
            lblEventos.Name = "lblEventos";
            lblEventos.Size = new Size(72, 30);
            lblEventos.TabIndex = 0;
            lblEventos.Text = "label1";
            lblEventos.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lBoxLean
            // 
            lBoxLean.FormattingEnabled = true;
            lBoxLean.ItemHeight = 15;
            lBoxLean.Location = new Point(224, 230);
            lBoxLean.Name = "lBoxLean";
            lBoxLean.Size = new Size(333, 169);
            lBoxLean.TabIndex = 1;
            // 
            // lBoxJuan
            // 
            lBoxJuan.FormattingEnabled = true;
            lBoxJuan.ItemHeight = 15;
            lBoxJuan.Location = new Point(224, 12);
            lBoxJuan.Name = "lBoxJuan";
            lBoxJuan.Size = new Size(333, 184);
            lBoxJuan.TabIndex = 2;
            // 
            // lblCartaEnMesa
            // 
            lblCartaEnMesa.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblCartaEnMesa.AutoSize = true;
            lblCartaEnMesa.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblCartaEnMesa.Location = new Point(224, 199);
            lblCartaEnMesa.Name = "lblCartaEnMesa";
            lblCartaEnMesa.Size = new Size(51, 21);
            lblCartaEnMesa.TabIndex = 3;
            lblCartaEnMesa.Text = "label1";
            lblCartaEnMesa.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblJuan
            // 
            lblJuan.AutoSize = true;
            lblJuan.Location = new Point(162, 91);
            lblJuan.Name = "lblJuan";
            lblJuan.Size = new Size(31, 15);
            lblJuan.TabIndex = 4;
            lblJuan.Text = "Juan";
            // 
            // lblLean
            // 
            lblLean.AutoSize = true;
            lblLean.Location = new Point(162, 318);
            lblLean.Name = "lblLean";
            lblLean.Size = new Size(32, 15);
            lblLean.TabIndex = 5;
            lblLean.Text = "Lean";
            // 
            // FrmUNO
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 547);
            Controls.Add(lblLean);
            Controls.Add(lblJuan);
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
        private Label lblJuan;
        private Label lblLean;
    }
}