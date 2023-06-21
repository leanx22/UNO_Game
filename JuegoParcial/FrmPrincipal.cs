namespace JuegoParcial
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            this.Text = "UNO";
            this.MaximizeBox = false;
        }

        private void btnNuevaPartida_Click(object sender, EventArgs e)
        {
            FrmUNO ventana = new FrmUNO();
            ventana.Show();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            FrmHistorial ventana = new FrmHistorial();
            ventana.ShowDialog();
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Seguro que quiere cerrar el juego?","Confirmar",
                MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (res != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}