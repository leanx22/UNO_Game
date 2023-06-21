using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    //Interfaz con los elementos minimos necesarios para cualquier juego de cartas.
    //Esta interfaz podria ser utilizada para programar otro juego de cartas como
    //por ejemplo el truco, chinchon, etc.
    public interface IJuegoDeCartas
    {
        public event DelegadoGameOver OnGameOver; //Evento de juego terminado
        public event Action OnNuevaCartaEnMesa; //Evento hay nuevas cartas en mesa
        public event DelegadoNotificacion OnNotificacion; //Evento que envia un mensaje a imprimir en el formulario.


        public void Jugar(int cartasPorJugador, int sleep); //Funcion de inicializacion y gameLoop

    }

    //Si quisiera agregar otro juego de cartas, la clase que maneje la conexion de su base
    //de datos debera tener estas funcionalidades minimas y necesarias para funcionar.
    public interface IBaseDeDatosParaJuegoDeCartas
    {
        public event Error OnError;

        //Cualquier juego de cartas necesitara obtener jugadores desde la base de datos.
        public List<Jugador> ObtenerJugadores(); 

        //Metodo para obtener el historial de partidas recientes desde la base de datos.
        public List<EstadisticasDePartida> ObtenerHistorialDePartidas();

        //Metodo para guardar las estadisticas de una partida reciente en la BBDD.
        public void GuardarPartidaEnHistorial(EstadisticasDePartida partida);
    }
}
