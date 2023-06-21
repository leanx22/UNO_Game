using Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class TestBBDD
    {
        bool error;

        [TestMethod]
        public void Test_Obtener_Jugadores()
        {
            BBDD _base = new BBDD();
            _base.OnError += this.ErrorHandler;
            List<Jugador> lista = _base.ObtenerJugadores();
           
            Assert.IsNotNull(lista);
            Assert.IsTrue(lista.Any());            
            Assert.IsFalse(this.error);
            this.error = false;
        }

        [TestMethod]
        public void Test_Obtener_Historial()
        {
            BBDD _base = new BBDD();
            _base.OnError += this.ErrorHandler;
            List<EstadisticasDePartida> historial = _base.ObtenerHistorialDePartidas();
            
            Assert.IsNotNull(historial);
            Assert.IsTrue(historial.Any());
            Assert.IsFalse(this.error);
            this.error = false;
        }

        [TestMethod]
        public void Test_Guardar_Jugador()
        {
            int registros;

            BBDD _base = new BBDD();
            _base.OnError += this.ErrorHandler;
            Jugador jugador = new Jugador(-1,"testeo",(float)0.25,0);
                       
            registros = _base.ObtenerJugadores().Count();
            _base.AgregarJugador(jugador);
            
            Assert.IsTrue(registros<_base.ObtenerJugadores().Count());

            _base.BorrarJugador(jugador);
            Assert.AreEqual(registros,_base.ObtenerJugadores().Count());
        }

        [TestMethod]
        public void Test_Actualizar_Jugador()
        {
            BBDD _base = new BBDD();
            Jugador jugador = _base.ObtenerJugadores()[0];
            int ganadas = jugador.PartidasGanadas;
            jugador.PartidasGanadas++;
            _base.ActualizarPartidasGanadas(jugador);
            jugador = _base.ObtenerJugadores()[0];
            Assert.IsTrue(ganadas<jugador.PartidasGanadas);
            jugador.PartidasGanadas = ganadas;
            _base.ActualizarPartidasGanadas(jugador);
        }
        

        private void ErrorHandler(Exception e)
        {
            this.error = true;
        }
    }
}
