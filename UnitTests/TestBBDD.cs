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

        private void ErrorHandler(Exception e)
        {
            this.error = true;
        }
    }
}
