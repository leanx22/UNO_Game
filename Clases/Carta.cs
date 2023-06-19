using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Carta
    {
        private ColoresDeCarta _color;
        private short _valor;

        //Como se comporta la carta (si es normal, si es un +2, un+4,etc).
        private Comportamiento _comportamiento;

        //Si la carta ya hizo efecto a un jugador.
        private bool _usada;

        public Carta()
        {
            this._color = ColoresDeCarta.Rojo;
            this._valor = -1;
            this._comportamiento = Comportamiento.Normal;
            this._usada = false;
        }

        public Carta(ColoresDeCarta color, short valor, Comportamiento comportamiento)
        {
            this._color = color;
            this._valor = valor;
            this._comportamiento = comportamiento;
            this._usada = false;
        }

        public ColoresDeCarta Color { get { return this._color; } }
        public short Valor { get { return this._valor; } }
        public Comportamiento Comportamiento { get { return this._comportamiento; } set { this._comportamiento = value; } }
        public bool Usada { get { return this._usada; } set { this._usada = value; } }


        public static bool operator ==(Carta c1, Carta c2)
        {
            return (c1.Valor == c2.Valor) && (c1.Color == c2.Color) &&
                (c1._comportamiento == c2._comportamiento);
        }

        public static bool operator !=(Carta c1, Carta c2)
        {
            return !(c1 == c2);
        }

        public override string ToString()
        {
            return "Color: "+this.Color+" | Valor: "+this.Valor+" | Comportamiento: "+this.Comportamiento;
        }

        public override bool Equals(object? obj)
        {
            Carta carta = (Carta)obj;
            return carta is not null && this == carta;
        }

    }
}
