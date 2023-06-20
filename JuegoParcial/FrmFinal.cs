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
    public partial class FrmFinal : Form
    {
        EstadisticasDePartida datos;
        BBDD baseDts;
        public FrmFinal(EstadisticasDePartida datos)
        {
            InitializeComponent();
            this.datos = datos;
            this.baseDts = new BBDD();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void FrmFinal_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.lblCantJugadores.Text = "(" + this.datos.CantidadDeJugadores + " jugadores)";
            this.lblGanador.Text = "Ganador: " + this.datos.Ganador;
            this.lblTurnos.Text = "Turnos: " + this.datos.Turnos;
            this.lblCantCartas.Text = "Cartas tiradas: " + this.datos.CartasNormalesUsadas;
            this.lblCantEspeciales.Text = "Cartas especiales usadas: " + this.datos.CartasEspecialesUsadas;
            this.dtPicker.Value = this.datos.Fecha;
            this.dtPicker.Enabled = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            baseDts.GuardarPartidaEnHistorial(datos);
            this.Close();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (Archivos<EstadisticasDePartida>.Serializar(datos, "Partida.json"))
            {
                MessageBox.Show("La partida se exporto de manera satisfactoria!","Listo",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            this.Close();
        }

        private void FrmFinal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
       
    }
}
