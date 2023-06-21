using Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoParcial
{
    public partial class FrmHistorial : Form
    {
        private BBDD _base;
        public FrmHistorial()
        {
            InitializeComponent();
            _base = new BBDD();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void FrmHistorial_Load(object sender, EventArgs e)
        {
            this.Text = "Partidas recientes.";
            this.MaximizeBox = false;
            this.gridHistorial.ReadOnly = true;
            this.gridHistorial.AllowUserToResizeRows = false;
            this.gridHistorial.EnableHeadersVisualStyles = true;
            this.gridHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.gridHistorial.MultiSelect = false;

            this.gridHistorial.DataSource = _base.ObtenerHistorialDePartidas();
        }
    }
}
