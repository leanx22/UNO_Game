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
            lBoxLean = new ListBox();
            lBoxJuan = new ListBox();
            lblCartaEnMesa = new Label();
            lblJuan = new Label();
            lblLean = new Label();
            btnPararJuego = new Button();
            tBoxNotificaciones = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // lBoxLean
            // 
            lBoxLean.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lBoxLean.FormattingEnabled = true;
            lBoxLean.ItemHeight = 20;
            lBoxLean.Location = new Point(446, 33);
            lBoxLean.Name = "lBoxLean";
            lBoxLean.Size = new Size(348, 284);
            lBoxLean.TabIndex = 1;
            // 
            // lBoxJuan
            // 
            lBoxJuan.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lBoxJuan.FormattingEnabled = true;
            lBoxJuan.ItemHeight = 20;
            lBoxJuan.Location = new Point(12, 33);
            lBoxJuan.Name = "lBoxJuan";
            lBoxJuan.Size = new Size(348, 284);
            lBoxJuan.TabIndex = 2;
            // 
            // lblCartaEnMesa
            // 
            lblCartaEnMesa.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblCartaEnMesa.AutoSize = true;
            lblCartaEnMesa.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblCartaEnMesa.ForeColor = Color.White;
            lblCartaEnMesa.Location = new Point(362, 367);
            lblCartaEnMesa.Name = "lblCartaEnMesa";
            lblCartaEnMesa.Size = new Size(76, 25);
            lblCartaEnMesa.TabIndex = 3;
            lblCartaEnMesa.Text = "Azul | 0";
            lblCartaEnMesa.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblJuan
            // 
            lblJuan.AutoSize = true;
            lblJuan.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblJuan.ForeColor = SystemColors.ButtonHighlight;
            lblJuan.Location = new Point(12, 9);
            lblJuan.Name = "lblJuan";
            lblJuan.Size = new Size(43, 21);
            lblJuan.TabIndex = 4;
            lblJuan.Text = "Juan";
            // 
            // lblLean
            // 
            lblLean.AutoSize = true;
            lblLean.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblLean.ForeColor = SystemColors.ButtonHighlight;
            lblLean.Location = new Point(446, 9);
            lblLean.Name = "lblLean";
            lblLean.Size = new Size(44, 21);
            lblLean.TabIndex = 5;
            lblLean.Text = "Lean";
            // 
            // btnPararJuego
            // 
            btnPararJuego.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnPararJuego.Location = new Point(683, 414);
            btnPararJuego.Name = "btnPararJuego";
            btnPararJuego.Size = new Size(111, 31);
            btnPararJuego.TabIndex = 6;
            btnPararJuego.Text = "Terminar juego";
            btnPararJuego.UseVisualStyleBackColor = true;
            btnPararJuego.Click += btnPararJuego_Click;
            // 
            // tBoxNotificaciones
            // 
            tBoxNotificaciones.Dock = DockStyle.Bottom;
            tBoxNotificaciones.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            tBoxNotificaciones.Location = new Point(0, 451);
            tBoxNotificaciones.Name = "tBoxNotificaciones";
            tBoxNotificaciones.Size = new Size(806, 33);
            tBoxNotificaciones.TabIndex = 7;
            tBoxNotificaciones.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(308, 337);
            label1.Name = "label1";
            label1.Size = new Size(187, 30);
            label1.TabIndex = 8;
            label1.Text = "CARTA EN MESA";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmUNO
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(806, 484);
            Controls.Add(label1);
            Controls.Add(tBoxNotificaciones);
            Controls.Add(btnPararJuego);
            Controls.Add(lblLean);
            Controls.Add(lblJuan);
            Controls.Add(lblCartaEnMesa);
            Controls.Add(lBoxJuan);
            Controls.Add(lBoxLean);
            Name = "FrmUNO";
            Text = "FrmUNO";
            Load += FrmUNO_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox lBoxLean;
        private ListBox lBoxJuan;
        private Label lblCartaEnMesa;
        private Label lblJuan;
        private Label lblLean;
        private Button btnPararJuego;
        private TextBox tBoxNotificaciones;
        private Label label1;
    }
}