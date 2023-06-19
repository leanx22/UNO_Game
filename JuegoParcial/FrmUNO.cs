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
        private UNO uno;
        public FrmUNO()
        {
            InitializeComponent();
            uno = new UNO();
        }

        private void FrmUNO_Load(object sender, EventArgs e)
        {
            uno.OnGameOver += this.JuegoTerminado;
            uno.OnNotificacion += this.NuevaNotificacion;
            uno.OnUNO += this.UNOhandler;
            //MessageBox.Show(juego.ListadoDeJugadores());

            Task Juego = Task.Run(this.uno.Jugar);

            /* test
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
            */

        }

        private void NuevaNotificacion(string msj)
        {
            lblEventos.Text=msj;
        }

        private void JuegoTerminado()
        {
            MessageBox.Show("Evento");
        }

        private void UNOhandler(Jugador jugador)
        {
            lblEventos.Text = jugador.Nombre + " dice UNO.";
        }

        private void ActualizarCartas(Jugador jugador1, Jugador jugador2)
        {
            this.lBoxLean.DataSource = null;
            this.lBoxLean.DataSource = jugador1;

            this.lBoxJuan.DataSource = null;
            this.lBoxJuan.DataSource = jugador2;
        }

        private void ActualizarMesa(Carta carta)
        {
            this.lblCartaEnMesa.Text = "Carta actual: "+carta.ToString();
        }
    }
}
