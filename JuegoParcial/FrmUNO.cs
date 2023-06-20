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
            uno.actualizarCartas = this.ActualizarCartas;
            uno.actualizarMesa = this.ActualizarMesa;
            //MessageBox.Show(juego.ListadoDeJugadores());

            this.lBoxJuan.Enabled = false;
            this.lBoxLean.Enabled = false;

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
            if (this.lblEventos.InvokeRequired)
            {
                DelegadoNotificacion funcion = new DelegadoNotificacion(NuevaNotificacion);
                object[] parametros = { msj };
                this.lblEventos.Invoke(funcion, parametros);
            }
            else
            {
                lblEventos.Text = msj;
            }

        }

        private void JuegoTerminado()
        {
            MessageBox.Show("Evento");
        }

        private void UNOhandler(Jugador jugador)
        {
            if (this.lblEventos.InvokeRequired)
            {
                DelegadoJugador funcion = new DelegadoJugador(UNOhandler);
                object[] parametros = { jugador };
                this.lblEventos.Invoke(funcion, parametros);
            }
            else
            {
                lblEventos.Text = jugador.Nombre + " dice UNO.";
            }
        }

        private void ActualizarCartas(Jugador jugador)
        {
            if (jugador.Nombre == "Lean")
            {
                if (this.lBoxLean.InvokeRequired)
                {
                    DelegadoJugador funcion = new DelegadoJugador(ActualizarCartas);
                    object[] parametros = { jugador };
                    this.lBoxLean.Invoke(funcion, parametros);
                }
                else
                {
                    this.lBoxLean.DataSource = null;
                    this.lBoxLean.DataSource = jugador.Cartas;
                    this.lBoxLean.SelectedItem = null;

                }
            }

            if (jugador.Nombre == "Juan")
            {
                if (this.lBoxJuan.InvokeRequired)
                {
                    DelegadoJugador funcion = new DelegadoJugador(ActualizarCartas);
                    object[] parametros = { jugador };
                    this.lBoxJuan.Invoke(funcion, parametros);
                }
                else
                {
                    this.lBoxJuan.DataSource = null;
                    this.lBoxJuan.DataSource = jugador.Cartas;
                    this.lBoxJuan.SelectedItem = null;
                }
            }

        }

        private void ActualizarMesa(Carta carta)
        {
            if (lblCartaEnMesa.InvokeRequired)
            {
                DelegadoCarta funcion = new DelegadoCarta(ActualizarMesa);
                object[] parametros = { carta };
                this.lblCartaEnMesa.Invoke(funcion, parametros);
            }
            else
            {
                this.lblCartaEnMesa.Text = "Carta actual: " + carta.ToString();
            }

        }
    }
}
