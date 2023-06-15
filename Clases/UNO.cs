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

        public UNO()
        {
            this._mazo = new Mazo();
            this._base = new BBDD();
            this._listaJugadores = _base.ObtenerJugadores();
            this._mesa = new Carta(ColoresDeCarta.Especial,0,false);
        }

        public Mazo Mazo { get { return this._mazo; } }

        public List<Jugador> Jugadores { get { return this._listaJugadores; } }

        

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

        public void Iniciar()
        {
            this._mazo.MezclarCartas();
            foreach (Jugador j in this._listaJugadores)
            {
                j.TomarCarta(5,this._mazo);
            }

            this._mesa = this._mazo.ObtenerCartaInicial();

            OnGameOver.Invoke();

        }

    }
}
