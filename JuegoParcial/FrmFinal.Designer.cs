namespace JuegoParcial
{
    partial class FrmFinal
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
            lblTitulo = new Label();
            lblGanador = new Label();
            lblCantJugadores = new Label();
            lblTurnos = new Label();
            lblCantCartas = new Label();
            lblCantEspeciales = new Label();
            dtPicker = new DateTimePicker();
            lblFecha = new Label();
            btnExportar = new Button();
            btnOK = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(106, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(146, 21);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Juego Terminado";
            // 
            // lblGanador
            // 
            lblGanador.AutoSize = true;
            lblGanador.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblGanador.Location = new Point(34, 86);
            lblGanador.Name = "lblGanador";
            lblGanador.Size = new Size(64, 17);
            lblGanador.TabIndex = 1;
            lblGanador.Text = "Ganador:";
            // 
            // lblCantJugadores
            // 
            lblCantJugadores.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblCantJugadores.AutoSize = true;
            lblCantJugadores.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblCantJugadores.Location = new Point(133, 30);
            lblCantJugadores.Name = "lblCantJugadores";
            lblCantJugadores.Size = new Size(89, 17);
            lblCantJugadores.TabIndex = 2;
            lblCantJugadores.Text = "(x Jugadores)";
            // 
            // lblTurnos
            // 
            lblTurnos.AutoSize = true;
            lblTurnos.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblTurnos.Location = new Point(34, 125);
            lblTurnos.Name = "lblTurnos";
            lblTurnos.Size = new Size(52, 17);
            lblTurnos.TabIndex = 3;
            lblTurnos.Text = "Turnos:";
            // 
            // lblCantCartas
            // 
            lblCantCartas.AutoSize = true;
            lblCantCartas.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblCantCartas.Location = new Point(34, 163);
            lblCantCartas.Name = "lblCantCartas";
            lblCantCartas.Size = new Size(94, 17);
            lblCantCartas.TabIndex = 4;
            lblCantCartas.Text = "Cartas tiradas:";
            // 
            // lblCantEspeciales
            // 
            lblCantEspeciales.AutoSize = true;
            lblCantEspeciales.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblCantEspeciales.Location = new Point(34, 200);
            lblCantEspeciales.Name = "lblCantEspeciales";
            lblCantEspeciales.Size = new Size(158, 17);
            lblCantEspeciales.TabIndex = 5;
            lblCantEspeciales.Text = "Cartas especiales tiradas:";
            // 
            // dtPicker
            // 
            dtPicker.Location = new Point(34, 255);
            dtPicker.Name = "dtPicker";
            dtPicker.Size = new Size(230, 23);
            dtPicker.TabIndex = 6;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblFecha.Location = new Point(34, 235);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(46, 17);
            lblFecha.TabIndex = 7;
            lblFecha.Text = "Fecha:";
            // 
            // btnExportar
            // 
            btnExportar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExportar.Location = new Point(34, 300);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(127, 23);
            btnExportar.TabIndex = 8;
            btnExportar.Text = "Exportar a json";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOK.Location = new Point(204, 300);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(127, 23);
            btnOK.TabIndex = 9;
            btnOK.Text = "Listo";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // FrmFinal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(367, 351);
            Controls.Add(btnOK);
            Controls.Add(btnExportar);
            Controls.Add(lblFecha);
            Controls.Add(dtPicker);
            Controls.Add(lblCantEspeciales);
            Controls.Add(lblCantCartas);
            Controls.Add(lblTurnos);
            Controls.Add(lblCantJugadores);
            Controls.Add(lblGanador);
            Controls.Add(lblTitulo);
            Name = "FrmFinal";
            Text = "FrmFinal";
            FormClosing += FrmFinal_FormClosing;
            Load += FrmFinal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblGanador;
        private Label lblCantJugadores;
        private Label lblTurnos;
        private Label lblCantCartas;
        private Label lblCantEspeciales;
        private DateTimePicker dtPicker;
        private Label lblFecha;
        private Button btnExportar;
        private Button btnOK;
    }
}