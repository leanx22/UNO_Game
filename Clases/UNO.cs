using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class UNO
    {
        private Mazo _mazo; //Mazo de cartas.
        private List<Jugador> _listaJugadores; // Jugadores actuales.
        private BBDD _base; //Conexion a la base de datos.
        private Carta _mesa; //Carta actual en la mesa.

        public event Action OnGameOver;
        public event Action OnCartaActualizada;
        public event Action<string> OnAccionRealizada;
        public event Action<Jugador> OnUNO;
        public event Action<string> OnNotificacion;

        public UNO()
        {
            this._mazo = new Mazo();
            this._base = new BBDD();
            this._listaJugadores = _base.ObtenerJugadores();
            this._mesa = new Carta(ColoresDeCarta.Rojo,0,Comportamiento.Normal);
        }

        public Mazo Mazo { get { return this._mazo; } }
        public List<Jugador> Jugadores { get { return this._listaJugadores; } }
        public Carta EnMesa { get { return this._mesa; } }


        public string ListadoDeJugadores()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Jugadores disponibles: ");
            foreach (Jugador j in _listaJugadores)
            {
                sb.AppendLine(j.ToString());
            }
            return sb.ToString();
        }

        public void Jugar()
        {
            Random rm = new Random();
            Jugador jugador;
            bool continuar = true;

            //Mezclo las cartas.
            this._mazo.MezclarCartas();
            
            //Cada jugador toma 7 cartas
            foreach (Jugador j in this._listaJugadores)
            {
                j.OnCartaTirada += this.CartaTiradaHandler;
                j.OnTomaCarta += this._mazo.ObtenerCarta;
                j.Cartas = this._mazo.ObtenerCarta(7,j.Suerte);//carta de mas
            }

            //Primera carta sobre la mesa.
            this._mesa = this._mazo.ObtenerCarta(1,-1)[0];

            //Selecciono un jugador al azar para ser el primero.
            jugador = this._listaJugadores[rm.Next(0,this._listaJugadores.Count)];

            int indice = 0;
            do
            {
                jugador = this._listaJugadores[indice];
                
                //Se inicia el turno del jugador y se verifica si
                //pudo o no realizar una accion (tirar una carta).
                if (!jugador.IniciarTurno(this._mesa))
                {
                    //En caso de que el jugador no pueda realizar una accion, se le da +1 carta.
                    this.SinAcciones(jugador);
                }

                #region Control de la cantidad de cartas de cada jugador
                if (jugador.Cartas.Count == 1)
                {
                    this.OnUNO.Invoke(jugador);
                }
                else if (jugador.Cartas.Count == 0)
                {
                    //Pasar como parametro al ganador o hacer otro evento
                    this.OnGameOver();
                    continuar = false;
                }
                #endregion

                #region Siguiente turno

                 indice++;
                 //Si el indice se pasa lo reinicio, es decir, vuelvo al primer jugador.
                 if (indice == this._listaJugadores.Count)
                 {
                    indice = 0;
                 }
                #endregion

                //Tiempo de pausa.
                Thread.Sleep(2000);
            }
            while (continuar);

        }

        private void CartaTiradaHandler(CartaArgs a)
        {
            this._mesa = new Carta(a.Color, (short)a.Valor, a.Comportamiento);
            if (this._mesa.Comportamiento == Comportamiento.CambiaColor)
            {
                this._mesa.Usada = true;
            }    
          
            if (a.Comportamiento != Comportamiento.Normal)
            {
                this.OnNotificacion.Invoke(a.Fuente.Nombre + " utilizo un " +
                    a.Comportamiento.ToString());
            }
            else
            {
                this.OnNotificacion.Invoke(a.Fuente.Nombre+" tiro la carta: " +
                    a.Color.ToString() +" | " + a.Valor.ToString()+".\nLe quedan "+
                    a.Fuente.Cartas.Count+" cartas en el mazo.");
            }
        }

        private void SinAcciones(Jugador jugador)
        {
            Carta carta = this._mazo.ObtenerCarta(1, jugador.Suerte)[0];
            jugador += carta;
            if (carta.Comportamiento == Comportamiento.Normal)
            {
                this.OnNotificacion.Invoke(jugador.Nombre + " toma +1 carta " +
                    "(" + carta.Valor + " | " + carta.Color + ") y pasa su turno.");
            }
            else
            {
                this.OnNotificacion.Invoke(jugador.Nombre + " toma +1 carta. Que suerte, le toco un " +
                        "(" + carta.Comportamiento.ToString()+ ") y pasa su turno.");
            }           
        }

    }
}
