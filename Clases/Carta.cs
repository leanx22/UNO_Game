using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Carta
    {
        private ColoresDeCarta _color;
        private short _valor;
        private Comportamiento _comportamiento;

        public Carta(ColoresDeCarta color, short valor, Comportamiento comportamiento)
        {
            this._color = color;
            this._valor = valor;
            this._comportamiento = comportamiento;
        }

        public ColoresDeCarta Color { get { return this._color; } }
        public short Valor { get { return this._valor; } }
        public Comportamiento Comportamiento { get { return this._comportamiento; } set { this._comportamiento = value; } }



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
