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
            //Instancio la clase del juego y me suscribo a sus eventos
            uno = new UNO(this.JuegoTerminado, this.ActualizarMesa, this.UNOhandler,
                this.NuevaNotificacion, this.ActualizarCartas);         
        }

        private void FrmUNO_Load(object sender, EventArgs e)
        {
            #region Borrar
            // uno.OnGameOver += this.JuegoTerminado;
            //uno.OnNotificacion += this.NuevaNotificacion;
            // uno.OnUNO += this.UNOhandler;
            // uno.OnNuevaCartaEnMesa += this.ActualizarMesa;
            //uno.actualizarVistaCartas = this.ActualizarCartas;            
            //MessageBox.Show(juego.ListadoDeJugadores());
            #endregion

            this.lBoxJuan.Enabled = false;
            this.lBoxLean.Enabled = false;

            //Inicio la tarea del juego.
            Task Juego = Task.Run(()=>this.uno.Jugar(7,3500));
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

        private void JuegoTerminado(Jugador jugador,EstadisticasDePartida estadisticas)
        {
            jugador.PartidasGanadas++;
            FrmFinal ventana = new FrmFinal(estadisticas);
            ventana.ShowDialog();
            
            if (this.InvokeRequired)
            {
                Action funcion = new Action(this.Close);
                this.Invoke(funcion);
            }
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

        private void ActualizarMesa()
        {
            if (lblCartaEnMesa.InvokeRequired)
            {
                Action funcion = new Action(ActualizarMesa);
                this.lblCartaEnMesa.Invoke(funcion);
            }
            else
            {
                this.lblCartaEnMesa.Text = "Carta actual: " + uno.EnMesa.ToString();
            }

        }

        private void btnPararJuego_Click(object sender, EventArgs e)
        {
            this.btnPararJuego.Text = "Cancelando...";
            this.lblEventos.Text = "El juego fue interrupido.\nCalculando el ganador segun cantidad de" +
                " cartas...";
            this.uno.cancellationTokenSource.Cancel();
        }
    }
}
