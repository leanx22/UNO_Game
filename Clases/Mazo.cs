using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Clases
{
    public class Mazo
    {
        private Stack<Carta> _cartas;
        private List<Carta> _poolCartas;
        private Random _random;

        public Mazo()
        {
            this._cartas = new Stack<Carta>();
            this._poolCartas = new List<Carta>();
            this.GenerarCartas();
            this._random = new Random();
        }

        public Stack<Carta> Cartas { get { return this._cartas; } }

        private void GenerarCartas()
        {
            for (short i = 0; i <= 9; i++)
            {
                this._poolCartas.Add(new Carta(ColoresDeCarta.Rojo, i, false));
                this._poolCartas.Add(new Carta(ColoresDeCarta.Azul, i, false));
                this._poolCartas.Add(new Carta(ColoresDeCarta.Amarillo, i, false));
                this._poolCartas.Add(new Carta(ColoresDeCarta.Verde, i, false));
            }
        }

        public void MezclarCartas()
        {
            int contador = 0;
            this._cartas.Clear();
            while (contador<_poolCartas.Count)
            { 
                int indice = _random.Next(0,_poolCartas.Count);
                Carta carta = this._poolCartas[indice];
                if (!_cartas.Contains(carta))
                {
                    _cartas.Push(_poolCartas[indice]);
                    contador++;
                }
            }
        }

        public Carta ObtenerCartaInicial()
        {
            return this._cartas.Pop();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Cartas disponibles: ");
            foreach (Carta c in _cartas)
            { 
                sb.AppendLine(c.ToString());
            }
            return sb.ToString();
        }

    }
}
