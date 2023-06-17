using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class CartaArgs : EventArgs
    {
        private ColoresDeCarta color;
        private int valor;

        public CartaArgs(ColoresDeCarta color, int valor)
        {
            this.color = color;
            this.valor = valor;
        }

        public ColoresDeCarta Color { get { return this.color; } }
        public int Valor { get { return this.valor;} }

    }
}
