namespace JuegoParcial
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            FrmUNO ventana = new FrmUNO();
            ventana.Show();
        }
    }
}