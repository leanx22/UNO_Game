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
        public event Action OnCambioDeTurno;
        public event Action OnCartaActualizada;

        public UNO()
        {
            this._mazo = new Mazo();
            this._base = new BBDD();
            this._listaJugadores = _base.ObtenerJugadores();
            this._mesa = new Carta(ColoresDeCarta.Especial,0,false);
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
            
            //Cada jugador toma 5 cartas
            foreach (Jugador j in this._listaJugadores)
            {
                j.TomarCarta(5,this._mazo);
            }

            //Primera carta sobre la mesa.
            this._mesa = this._mazo.ObtenerCartaInicial();

            //Selecciono un jugador al azar para ser el primero.
            jugador = this._listaJugadores[rm.Next(0,this._listaJugadores.Count)];

            do
            {



            }
            while (continuar);

        }

    }
}
