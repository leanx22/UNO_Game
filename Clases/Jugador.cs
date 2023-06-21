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

        //Delegado en el que guardo la direccion de memoria de la funcion "ObtenerCarta" del mazo
        public obtenerCartas OnTomaCarta;
        public event Action<CartaArgs> OnCartaTirada;

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
        public float Suerte { get {  return this._suerte; } }
        public int PartidasGanadas { get { return this._partidasGanadas; } set { this._partidasGanadas = value; } }
        public int ID { get { return this.id; } }

        public bool IniciarTurno(Carta CartaSobreLaMesa)
        {
            //Verifico si la carta en mesa necesita una accion especifica del usuario (es decir,
            //si el comportamiento de la carta NO es normal) y si esta carta ya surgio efecto
            //en otro jugador.
            if ((CartaSobreLaMesa.Comportamiento != Comportamiento.Normal) &&
                (!CartaSobreLaMesa.Usada))      
            {
                //Cambio la propiedad a TRUE ya que la carta va a aplicar efecto.
                CartaSobreLaMesa.Usada = true;
                //El jugador realiza la accion que corresponda y si debe
                //perder el turno se hace return, caso contrario se continua con la funcion IniciarTurno.
                if (RespuestaCartasEspeciales(CartaSobreLaMesa))                
                return true;
            }

            //Intento tirar una carta normal, si no se puede entonces intento con alguna especial.
            if (!IntentarUsarCartaNormal(CartaSobreLaMesa))
            {
                //Al ser la ultima opcion, directamente retorno si la funcion pudo o no utilizar
                //una carta especial.
                return IntentarUsarCartaEspecial(CartaSobreLaMesa);           
            }

            return true;
        }

        /// <summary>
        /// Esta funcion recorre y cuenta los distintos colores de las cartas en mano del
        /// jugador.
        /// </summary>
        /// <returns>
        /// Retorna el Color mas repetido en la mano del jugador.
        /// </returns>
        public ColoresDeCarta ObtenerColorMasRepetidoEnMano()
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

        /// <summary>
        /// Esta funcion se encarga de la respuesta del jugador ante una carta especial y
        /// si debe o no perder el turno.
        /// </summary>
        /// <param name="carta">
        /// Carta que requiera alguna accion del jugador.
        /// </param>
        /// <returns>
        /// Retorna Verdadero si el jugador debe perder el turno, caso contrario
        /// retornara False.
        /// </returns>
        private bool RespuestaCartasEspeciales(Carta carta)
        {
            bool ret=false;
            List<Carta> cartasAagregar = new List<Carta>();
            switch (carta.Comportamiento) //Segun el comportamiento
            {
                case Comportamiento.TomaDos: //Si es un +2
                    cartasAagregar = this.OnTomaCarta.Invoke(2, this._suerte);
                    ret = false;
                break;
                
                case Comportamiento.TomaCuatro://Si es un +4
                    cartasAagregar = this.OnTomaCarta.Invoke(4, this._suerte);
                    ret = true;
                break;
                
                case Comportamiento.CancelaTurno:
                    ret = true;
                break;
            }

            if (cartasAagregar.Count > 0)
            {
                foreach (Carta c in cartasAagregar)
                {
                    this._cartas.Add(c);
                }
            }

            return ret;
        }
        
        /// <summary>
        /// Esta funcion busca y utiliza alguna carta NORMAL (numerica) que sea compatible
        /// con aquella que este en la mesa (ultima carta tirada).
        /// </summary>
        /// <param name="cartaEnMesa">
        /// Carta actual sobre la mesa (ultima carta tirada por el jugador anterior).
        /// </param>
        /// <returns>
        /// Retorna True si se encontro y utilizo una carta, caso contrario retornara false.
        /// </returns>
        private bool IntentarUsarCartaNormal(Carta cartaEnMesa)
        {
            bool ret = false;
            Carta cartaAeliminar = new Carta();
            
            //Busco en las cartas del jugador alguna que sea compatible con la carta en mesa
            foreach (Carta c in this._cartas)
            {
                if ((c.Valor == cartaEnMesa.Valor && c.Valor >= 0) ||
                    (c.Color == cartaEnMesa.Color && c.Color != ColoresDeCarta.Negro))
                {
                    //Guardo la carta que debo eliminar de la mano del Jugador.
                    cartaAeliminar = c;
                    ret = true;
                    break;
                }
                else if (cartaEnMesa.Color == ColoresDeCarta.Negro && c.Color!= ColoresDeCarta.Negro)
                {
                    cartaAeliminar = c;
                    ret = true;
                    break;
                }
            }

            //Elimino la carta de la mano del jugador.
            if (this._cartas.Contains(cartaAeliminar)&&ret==true)
            {
                this._cartas.Remove(cartaAeliminar);
                //Evento de cuando se tira una carta.
                if (OnCartaTirada != null)
                {
                    OnCartaTirada.Invoke(new CartaArgs(cartaAeliminar.Color, cartaAeliminar.Valor,
                        cartaAeliminar.Comportamiento, this));
                }
            }

            return ret;
        }

        /// <summary>
        /// Esta funcion busca una carta especial en la mano del jugador y utiliza la primera
        /// que encuentre y sea compatible con el color (si es el caso).
        /// </summary>
        /// <param name="cartaEnMesa">
        /// Carta actual en la mesa (ultima carta tirada por el jugador anterior).
        /// </param>
        /// <returns>
        /// Retorna Verdadero si se utilizo alguna, caso contrario retorna False.
        /// </returns>
        private bool IntentarUsarCartaEspecial(Carta cartaEnMesa)
        {
            bool ret = false;
            Carta cartaAEliminar = new Carta();

            //Busco en la mano del jugador
            foreach (Carta c in this._cartas)
            {
                //Comparo los comportamientos, y la  
                switch (c.Comportamiento)
                {
                    case Comportamiento.CambiaColor: //Puede usarse sin importar el color.
                        //this._cartas.Remove(c);
                        OnCartaTirada.Invoke(new CartaArgs(ObtenerColorMasRepetidoEnMano(),
                            -1, Comportamiento.CambiaColor, this));
                        ret = true;
                        break;
                    case Comportamiento.TomaCuatro: //Puede usarse sin importar el color.                       
                        //this._cartas.Remove(c);
                        OnCartaTirada.Invoke(new CartaArgs(ColoresDeCarta.Negro, -4,
                        Comportamiento.TomaCuatro, this));
                        ret = true;
                        break;
                    case Comportamiento.TomaDos:
                        //Verifico que el +2 sea del mismo color que la carta en mesa para usarlo.
                        if (cartaEnMesa.Color == c.Color) 
                        {
                            //this._cartas.Remove(c);
                            OnCartaTirada.Invoke(new CartaArgs(c.Color, -2, Comportamiento.TomaDos,
                                this));                            
                            ret = true;
                        }                       
                        break;
                    case Comportamiento.CancelaTurno:
                        //Verifico que la carta sea del mismo color que la carta en mesa para usarla.
                        if (cartaEnMesa.Color == c.Color)
                        {
                            //this._cartas.Remove(c);
                            OnCartaTirada.Invoke(new CartaArgs(c.Color, -3, Comportamiento.CancelaTurno,
                                this));                            
                            ret = true;
                        }                           
                        break;
                }

                if (ret)
                {
                    this._cartas.Remove(c);
                    break;
                }

            }

            /*Elimino la carta de la mano del jugador.
            if (this._cartas.Contains(cartaAEliminar))
            {
                this._cartas.Remove(cartaAEliminar);
            }
            */
            return ret;
        }


        /// <summary>
        /// Esta sobrecarga agrega la carta dada a la mano del jugador.
        /// </summary>
        /// <param name="j">
        /// Jugador al cual se le desea agregar la carta.
        /// </param>
        /// <param name="c">
        /// Carta a agregarle al jugador.
        /// </param>
        /// <returns>
        /// Retorna al jugador actualizado con la nueva carta.
        /// </returns>
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
