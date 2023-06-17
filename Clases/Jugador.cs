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

        public event Action<Carta> OnCartaUsada;
        public event Action<int> OnTomaCarta;
        public event Action<CartaArgs> OnCartaEspecial;

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

        /// <summary>
        /// Esta funcion saca una carta del mazo(stack) y la agrega a la lista de cartas del
        /// jugador
        /// </summary>
        /// <param name="cantidad">Cantidad de cartas a tomar del mazo</param>
        /// <param name="mazo">Mazo de donde tomar la carta</param>
        public void TomarCarta(int cantidad, Mazo mazo)
        {
            Random rm = new Random();
            for (int i = 0; i < cantidad; i++)
            {
                if (rm.Next(0, 101) <= (this._suerte * 100))
                {
                    short j;
                    //Nuevamente al azar, se selecciona una de las 3 cartas especiales.
                    j = (short)rm.Next(0, 3);
                    switch (j)
                    {
                        case 0: //Carta especial de +2
                            this._cartas.Add(new Carta(ColoresDeCarta.Especial, 2, true));
                            break;
                        case 1: //Carta especial de +4
                            this._cartas.Add(new Carta(ColoresDeCarta.Especial, 4, true));
                            break;
                        case 2: //Carta especial de cambio de color.
                            this._cartas.Add(new Carta(ColoresDeCarta.Especial, 0, true));
                            break;
                    }
                }
                else
                {
                    this._cartas.Add(mazo.Cartas.Pop());
                }
            }
        }

        public void IniciarTurno(Carta CartaSobreLaMesa)
        {

            if (CartaSobreLaMesa.Especial)
            {
                 if (CartaSobreLaMesa.Valor == 1) //Si es +4
                {
                    this.OnTomaCarta.Invoke(4);
                    return;
                }
                else //Si es +2
                {
                    this.OnTomaCarta.Invoke(2);
                    return;
                }

            }

            //Primero recorro todas las cartas en busqueda de
            //alguna que sea igual en color y valor
            foreach (Carta c in this._cartas)
            {
                if ((c.Valor == CartaSobreLaMesa.Valor) ||
                    c.Color == CartaSobreLaMesa.Color)
                {
                    this._cartas.Remove(c);
                    OnCartaUsada.Invoke(c);
                    return;
                }
            }

            //Si no encontre ninguna, entonces hago lo mismo buscando especiales.
            foreach (Carta c in this._cartas)
            {
                if (c.Color == ColoresDeCarta.Especial)
                {
                    if (c.Valor == 2)//Si es cambio de color
                    {
                        OnCartaEspecial.Invoke(new CartaArgs(ObtenerColorMasRepetidoEnMano(), 0));
                        this._cartas.Remove(c);
                        return;
                    }
                    else if (c.Valor == 1) //Si es +4
                    {
                        OnCartaEspecial.Invoke(new CartaArgs(ColoresDeCarta.Especial, 4));
                        this._cartas.Remove(c);
                        return;
                    }
                    else //Si es +2
                    {
                        OnCartaEspecial.Invoke(new CartaArgs(ColoresDeCarta.Especial, 2));
                        this._cartas.Remove(c);
                        return;
                    }
                }
            }

            //En ultima instancia, tomo una carta.
            OnTomaCarta.Invoke(1);
        }

        private ColoresDeCarta ObtenerColorMasRepetidoEnMano()
        {
            int rojas = 0;
            int amarillas = 0;
            int verdes = 0;
            int azules = 0;
            ColoresDeCarta ret;

            foreach (Carta c in this._cartas)
            {
                switch (c.Color)
                {
                    case ColoresDeCarta.Rojo:
                        rojas++;
                        break;
                    case ColoresDeCarta.Amarillo:
                        amarillas++;
                        break;
                    case ColoresDeCarta.Verde:
                        verdes++;
                        break;
                    case ColoresDeCarta.Azul:
                        azules++;
                        break;
                }
            }

            if (rojas > amarillas && rojas > verdes && rojas > azules)
            {
                ret = ColoresDeCarta.Rojo;
            }
            else if (amarillas > verdes && amarillas > azules)
            {
                ret = ColoresDeCarta.Amarillo;
            }
            else if (verdes > azules)
            {
                ret = ColoresDeCarta.Verde;
            }
            else
            {
                ret = ColoresDeCarta.Azul;
            }
            return ret;
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
