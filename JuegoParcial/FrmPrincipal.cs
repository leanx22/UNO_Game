namespace JuegoParcial
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
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
    }
}