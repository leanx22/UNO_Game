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
        private Comportamiento comportamiento;
        private Jugador fuente; //Quien tiro la carta

        public CartaArgs(ColoresDeCarta color, int valor, Comportamiento comportamiento,
            Jugador fuente)
        {
            this.color = color;
            this.valor = valor;
            this.comportamiento = comportamiento;
            this.fuente = fuente;
        }

        public ColoresDeCarta Color { get { return this.color; } }
        public int Valor { get { return this.valor;} }
        public Comportamiento Comportamiento { get { return this.comportamiento; } }
        public Jugador Fuente { get {  return this.fuente;}}
    }
}
