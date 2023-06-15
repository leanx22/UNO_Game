using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Jugador
    {
        private int id;
        private string _nombre;
        private float _suerte;
        private int _partidasGanadas;
        private List<Carta> _cartas;

        public Jugador(int id, string nombre, float suerte, int pGanadas)
        {
            this.id = id;
            this._nombre = nombre;
            this._suerte = suerte;
            this._partidasGanadas = pGanadas;
            this._cartas = new List<Carta>();
        }

        public List<Carta> Cartas { get { return this._cartas; } set { this._cartas = value; } }
        public string Nombre { get { return this._nombre; } }

        public void TomarCarta(int cantidad,Mazo mazo)
        {
            Random rm = new Random();
            for (int i=0;i<cantidad;i++)
            {
                if (rm.Next(0, 100) <= (this._suerte*100))
                {
                    this._cartas.Add(new Carta(ColoresDeCarta.Especial, 0, true));
                }
                else
                {
                    this._cartas.Add(mazo.Cartas.Pop());
                }
            }
        }



        public static Jugador operator +(Jugador j, Carta c)
        {
            j._cartas.Add(c);
            return j;
        }

        public static Jugador operator -(Jugador j, Carta c)
        {
            j._cartas.Remove(c);
            return j;
        }

        public override string ToString()
        {
            return "Jugador: "+this._nombre+" | id: "+this.id+" | Suerte: "+this._suerte+"" +
                " | Ganadas: "+this._partidasGanadas;
        }

    }
}
