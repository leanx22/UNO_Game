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
        private bool _esEspecial;

        public Carta(ColoresDeCarta color, short valor, bool especial)
        {
            this._color = color;
            this._valor = valor;
            this._esEspecial = especial;
        }

        public ColoresDeCarta Color { get { return this._color; } }
        public short Valor { get { return this._valor; } }
        public bool Especial { get { return this._esEspecial; } set { this._esEspecial = value; } }



        public static bool operator ==(Carta c1, Carta c2)
        {
            return (c1.Valor == c2.Valor) && (c1.Color == c2.Color);
        }

        public static bool operator !=(Carta c1, Carta c2)
        {
            return !(c1 == c2);
        }

        public override string ToString()
        {
            return "Color: "+this.Color+" | Valor: "+this.Valor+" | Especial: "+this.Especial;
        }

        public override bool Equals(object? obj)
        {
            Carta carta = (Carta)obj;
            return carta is not null && this == carta;
        }

    }
}
