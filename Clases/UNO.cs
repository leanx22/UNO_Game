using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class UNO : IJuego
    {
        private Mazo _mazo; //Mazo de cartas.
        private List<Jugador> _listaJugadores; // Jugadores actuales.
        private BBDD _base; //Conexion a la base de datos.
        private Carta _mesa; //Carta actual en la mesa.
        private EstadisticasDePartida _estadisticasDePartida;

        //Evento disparado cuando se termina la partida.
        public event DelegadoGameOver OnGameOver;

        //Evento que se llama cuando se actualiza la carta de la mesa.
        public event Action OnNuevaCartaEnMesa;

        //Evento que se llama cuando algun jugador tiene solo una carta en la mano.
        public event Action<Jugador> OnUNO;

        //Evento llamado cuando se necesite mostrar un mensaje en el lbl de eventos en juego.
        public event DelegadoNotificacion OnNotificacion;

        //Delegado que necesita un jugador como parametro, este se utiliza para guardar y llamar a la
        //funcion de actualizar la vista de las cartas del jugador en el juego.
        public DelegadoJugador actualizarVistaCartas;

        public CancellationTokenSource cancellationTokenSource;
        private CancellationToken cancellationToken;

        public UNO(DelegadoGameOver OnGameOver, Action OnNuevaCartaEnMesa, Action<Jugador> OnUNO,
            DelegadoNotificacion OnNotificacion, DelegadoJugador ActualizadorVistaCartas)
        {
            this._mazo = new Mazo();
            this._base = new BBDD();
            this._listaJugadores = _base.ObtenerJugadores();
            this._mesa = new Carta();
            this._estadisticasDePartida = new EstadisticasDePartida();

            this.OnGameOver += OnGameOver;
            this.OnNuevaCartaEnMesa += OnNuevaCartaEnMesa;
            this.OnUNO += OnUNO;
            this.OnNotificacion += OnNotificacion;
            this.actualizarVistaCartas = ActualizadorVistaCartas;

            cancellationTokenSource = new CancellationTokenSource();
            cancellationToken = cancellationTokenSource.Token;
        }

        #region Propiedades
        public List<Jugador> Jugadores { get { return this._listaJugadores; } }
        public Carta EnMesa { get { return this._mesa; } }
        #endregion

        #region Metodos

        /// <summary>
        /// Funcion principal, donde se inicializa y ocurre el juego dentro del gameLoop.
        /// </summary>
        /// <param name="cartasIniciales">
        /// Cantidad de cartas con las que inicia cada jugador.
        /// </param>
        /// <param name="msVelocidad">
        /// Cantidad de tiempo entre turnos (en milisegundos).
        /// </param>
        public void Jugar(int cartasIniciales,int msVelocidad)
        {
            Random rm = new Random();
            Jugador jugador;
            bool continuar = true;

            //Cada jugador toma las cartas especificadas en "cartasIniciales"
            //y me suscribo a sus eventos.
            foreach (Jugador j in this._listaJugadores)
            {
                j.OnCartaTirada += this.CartaTiradaHandler;
                j.OnTomaCarta += this._mazo.ObtenerCarta;
                j.Cartas = this._mazo.ObtenerCarta(cartasIniciales, j.Suerte);
            }

            //Obtengo la primera utilizando la funcion "ObtenerCarta" del mazo pasandole como
            //parametro la cantidad (1) y probabilidad de que sea especial en -1 (para que no toque)
            //al devolver una lista de cartas, (que en este caso solo contendra una) accedo al indice
            // 0 y la coloco en la mesa.
            this._mesa = this._mazo.ObtenerCarta(1, -1)[0];

            //Selecciono un jugador al azar para ser el primero.
            jugador = this._listaJugadores[rm.Next(0, this._listaJugadores.Count)];
            int indice = this._listaJugadores.IndexOf(jugador);

            this._estadisticasDePartida.CantidadDeJugadores = this._listaJugadores.Count;

            do//Comienza el GameLoop
            {
                //Siempre valido primero si se pidio cancelar el juego.
                if (this.cancellationToken.IsCancellationRequested)
                {
                    //Rompo el bucle
                    continuar = false;
                    //Llamo al evento de terminar partida
                    this._estadisticasDePartida.Ganador = this.JugadorConMenosCartas(this._listaJugadores).Nombre;
                    OnGameOver.Invoke(this.JugadorConMenosCartas(this._listaJugadores),
                        this._estadisticasDePartida);
                }
                
                //Sumo un turno a las estadisticas de la partida.
                this._estadisticasDePartida.Turnos++;
                jugador = this._listaJugadores[indice];
                //Se inicia el turno del jugador y se verifica si
                //pudo o no realizar una accion (accion = tirar una carta).
                if (!jugador.IniciarTurno(this._mesa))
                {
                    //En caso de que el jugador no pueda realizar una accion, se le da +1 carta.
                    this.SinAcciones(jugador);
                }

                //Actualizo la vista de cartas en el form.
                this.actualizarVistaCartas.Invoke(jugador);

                #region Control de la cantidad de cartas de cada jugador
                //Si el jugador tiene una carta se llama al evento OnUNO.
                if (jugador.Cartas.Count == 1)
                {
                    this.OnUNO.Invoke(jugador);
                }
                //Verifico si gano el juego.
                else if (jugador.Cartas.Count == 0)
                {
                    continuar = false;
                    this._estadisticasDePartida.Ganador = jugador.Nombre;
                    this.OnGameOver.Invoke(jugador,this._estadisticasDePartida);                    
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

                //Tiempo muerto antes del siguiente jugador
                Thread.Sleep(msVelocidad);
            }
            while (continuar);

        }

        /// <summary>
        /// Este controlador de evento se encarga de las acciones necesarias luego
        /// de que un jugador tire una carta. Actualiza la carta en mesa, y envia una notificacion
        /// segun el comportamiento de la carta al Form.
        /// </summary>
        /// <param name="a"></param>
        private void CartaTiradaHandler(CartaArgs a)
        {            
            this._mesa = new Carta(a.Color, (short)a.Valor, a.Comportamiento);
            if (this._mesa.Comportamiento == Comportamiento.CambiaColor)
            {
                this._mesa.Usada = true;
            }

            if (a.Comportamiento != Comportamiento.Normal)
            {
                this._estadisticasDePartida.CartasEspecialesUsadas++;
                this.OnNotificacion.Invoke(a.Fuente.Nombre + " utilizo un " +
                    a.Comportamiento.ToString());
            }
            else
            {
                this._estadisticasDePartida.CartasNormalesUsadas++;
                this.OnNotificacion.Invoke(a.Fuente.Nombre + " tiro la carta: " +
                    a.Color.ToString() + " | " + a.Valor.ToString() + ".\nLe quedan " +
                    a.Fuente.Cartas.Count + " cartas en el mazo.");
            }
            this.OnNuevaCartaEnMesa.Invoke();
        }

        /// <summary>
        /// Este metodo se llama cuando el jugador no pudo realizar ninguna accion.
        /// Le da una carta y envia una notificacion al Form de juego.
        /// </summary>
        /// <param name="jugador"></param>
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
                        "(" + carta.Comportamiento.ToString() + ") y pasa su turno.");
            }
        }

        /// <summary>
        /// Este metodo busca quien es el jugador con la menor cantidad de cartas.
        /// </summary>
        /// <param name="jugadores">
        /// Lista de jugadores.
        /// </param>
        /// <returns>
        /// Retorna el jugador con menor cantidad de cartas.
        /// </returns>
        private Jugador JugadorConMenosCartas(List<Jugador> jugadores)
        {
            int minimaCartas=0;
            Jugador jugador = new Jugador(-1,"",0,0);
            bool esPrimero = true;
            foreach (Jugador j in jugadores)
            {
                if (esPrimero)
                {
                    jugador = j;
                    minimaCartas = j.Cartas.Count;
                    esPrimero = false;
                }
                else if (j.Cartas.Count <= minimaCartas)
                {
                    jugador = j;
                    minimaCartas = j.Cartas.Count;
                }
            }
            return jugador;
        }

        #endregion
    }
}
