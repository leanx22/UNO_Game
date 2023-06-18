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
                this._poolCartas.Add(new Carta(ColoresDeCarta.Rojo, i, Comportamiento.Normal));
                this._poolCartas.Add(new Carta(ColoresDeCarta.Azul, i, Comportamiento.Normal));
                this._poolCartas.Add(new Carta(ColoresDeCarta.Amarillo, i, Comportamiento.Normal));
                this._poolCartas.Add(new Carta(ColoresDeCarta.Verde, i, Comportamiento.Normal));
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

        public Carta GenerarCartaEspecial()
        {
            int cantidad = Enum.GetValues(typeof(Comportamiento)).Length;
            Carta retorno;
            Comportamiento co;
            do
            {
                int indiceAleatorio = this._random.Next(0, cantidad);
                co = (Comportamiento)indiceAleatorio;
            } while (co == Comportamiento.Normal);

            switch (co)
            {
                case Comportamiento.TomaDos:
                    retorno = new Carta(ObtenerColorAleatorio(),0,co);
                    break;
                case Comportamiento.TomaCuatro:
                    retorno = new Carta(ColoresDeCarta.Negro, 0, co);
                    break;
                case Comportamiento.CambiaColor:
                    retorno = new Carta(ColoresDeCarta.Negro, 0, co);
                    break;
                case Comportamiento.CancelaTurno:
                    retorno = new Carta(ObtenerColorAleatorio(), 0, co);
                    break;
                case Comportamiento.CambioDeSentido:
                    retorno = new Carta(ObtenerColorAleatorio(), 0, co);
                        break;
            }

            return this._cartas.Pop();
        }

        public ColoresDeCarta ObtenerColorAleatorio()
        {
            int cantidad = Enum.GetValues(typeof(ColoresDeCarta)).Length;
            
            int indiceAleatorio = this._random.Next(0, cantidad);
            
            ColoresDeCarta color = (ColoresDeCarta)indiceAleatorio;

            return color;
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
