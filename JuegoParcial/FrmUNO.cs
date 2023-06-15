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
    public partial class FrmUNO : Form
    {
        private UNO juego;
        public FrmUNO()
        {
            InitializeComponent();
            juego = new UNO();
            juego.OnGameOver += this.JuegoTerminado;
        }

        private void FrmUNO_Load(object sender, EventArgs e)
        {
            MessageBox.Show(juego.ListadoDeJugadores());
            this.juego.Iniciar();
            List<Jugador> lista = this.juego.Jugadores;
            foreach (Jugador item in lista)
            {
                MessageBox.Show("Jugador: "+item.Nombre);
                foreach (Carta c in item.Cartas)
                {
                    MessageBox.Show("Carta: "+c.ToString());
                }
            }
            MessageBox.Show(juego.Mazo.ToString());
        }

        private void JuegoTerminado()
        {
            MessageBox.Show("Evento");
        }

    }
}
