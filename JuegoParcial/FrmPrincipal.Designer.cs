namespace JuegoParcial
{
    partial class FrmPrincipal
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
            lblTitulo = new Label();
            btnNuevaPartida = new Button();
            btnHistorial = new Button();
            btn_Salir = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(142, 29);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(61, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "UNO";
            // 
            // btnNuevaPartida
            // 
            btnNuevaPartida.Location = new Point(82, 92);
            btnNuevaPartida.Name = "btnNuevaPartida";
            btnNuevaPartida.Size = new Size(182, 34);
            btnNuevaPartida.TabIndex = 1;
            btnNuevaPartida.Text = "Nueva partida";
            btnNuevaPartida.UseVisualStyleBackColor = true;
            btnNuevaPartida.Click += btnNuevaPartida_Click;
            // 
            // btnHistorial
            // 
            btnHistorial.Location = new Point(82, 132);
            btnHistorial.Name = "btnHistorial";
            btnHistorial.Size = new Size(182, 34);
            btnHistorial.TabIndex = 2;
            btnHistorial.Text = "Historial";
            btnHistorial.UseVisualStyleBackColor = true;
            btnHistorial.Click += btnHistorial_Click;
            // 
            // btn_Salir
            // 
            btn_Salir.Location = new Point(82, 172);
            btn_Salir.Name = "btn_Salir";
            btn_Salir.Size = new Size(182, 34);
            btn_Salir.TabIndex = 4;
            btn_Salir.Text = "Salir";
            btn_Salir.UseVisualStyleBackColor = true;
            btn_Salir.Click += btn_Salir_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(354, 321);
            Controls.Add(btn_Salir);
            Controls.Add(btnHistorial);
            Controls.Add(btnNuevaPartida);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(370, 360);
            Name = "FrmPrincipal";
            Text = "Form1";
            FormClosing += FrmPrincipal_FormClosing;
            Load += FrmPrincipal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Button btnNuevaPartida;
        private Button btnHistorial;
        private Button btn_Salir;
    }
}