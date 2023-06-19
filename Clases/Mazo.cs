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

        /// <summary>
        /// Esta funcion toma la cantidad especificada de cartas del mazo y las retorna en
        /// forma de lista.
        /// </summary>
        /// <param name="cantidad">
        /// Cantidad de cartas necesarias.
        /// </param>
        /// <returns>Lista de cartas.</returns>
        public List<Carta> ObtenerCarta(int cantidad,float probabilidadEspecial)
        {
            Random rm = new Random();
            List<Carta> cartas = new List<Carta>();
            
            for (int i = 0; i < cantidad; i++)
            {
                if (rm.Next(0, 101) <= (probabilidadEspecial * 100))
                {
                    cartas.Add(this.GenerarCartaEspecial());
                }
                else
                {
                    cartas.Add(this._cartas.Pop());
                }
            }
            return cartas;
        }

        public Carta GenerarCartaEspecial()
        {
            int cantidad = Enum.GetValues(typeof(Comportamiento)).Length;
            Carta retorno = new Carta(ColoresDeCarta.Rojo, -1, Comportamiento.Normal);
            Comportamiento co;
            do
            {
                int indiceAleatorio = this._random.Next(0, cantidad);
                co = (Comportamiento)indiceAleatorio;
            } while (co == Comportamiento.Normal);

            switch (co)
            {
                case Comportamiento.TomaDos:
                    retorno = new Carta(ObtenerColorAleatorio(),-2,co);
                    break;
                case Comportamiento.TomaCuatro:
                    retorno = new Carta(ColoresDeCarta.Negro, -4, co);
                    break;
                case Comportamiento.CambiaColor:
                    retorno = new Carta(ColoresDeCarta.Negro, -1, co);
                    break;
                case Comportamiento.CancelaTurno:
                    retorno = new Carta(ObtenerColorAleatorio(), -3, co);
                    break;
            }

            return retorno;
        }

        public ColoresDeCarta ObtenerColorAleatorio()
        {
            int cantidad = Enum.GetValues(typeof(ColoresDeCarta)).Length;
            ColoresDeCarta color;
            do
            {
                int indiceAleatorio = this._random.Next(0, cantidad);
                color = (ColoresDeCarta)indiceAleatorio;
            } while (color==ColoresDeCarta.Negro);
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
