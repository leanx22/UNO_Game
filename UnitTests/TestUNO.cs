using Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class TestUNO
    {
        private UNO unoTest;
        private bool flagJuegoTerminado;
        private int rondas=0;

        private bool flagCartaActualizada;
        private bool flagDiceUNO;
        private bool flagNotificacion;

        [TestMethod]
        public void Test_Juego_terminado()
        {
            //Este test verifica que el juego llame al metodo suscrito a OnGameOver
            //Cuando un jugador ya no tiene cartas.
            
            //Arrange
            this.unoTest = new UNO(JuegoTerminado, ActualizarMesa, UNOhandler,
            NuevaNotificacion, ActualizarCartas);
            //Act
            unoTest.Jugar(1,0);
            //Assert
            Assert.IsTrue(flagJuegoTerminado);
            flagJuegoTerminado = false;
        }

        [TestMethod]
        public void Test_Juego_Cancelado()
        {
            //Este test verifica que el juego se cancele al utilizar el token

            //Arrange
            this.unoTest = new UNO(JuegoTerminado, ActualizarMesa, UNOhandler,
            NuevaNotificacion, ActualizarCartas);
            
            //Act
            Task Juego = Task.Run(() => unoTest.Jugar(5, 0));
            unoTest.cancellationTokenSource.Cancel();
            Juego.Wait();
            
            //Assert
            Assert.IsTrue(flagJuegoTerminado);
            Assert.IsTrue(unoTest.cancellationTokenSource.IsCancellationRequested);
            Assert.AreEqual(0,this.rondas);

            //Reinicio las variables para usarlas con otros test si es necesario.
            this.flagJuegoTerminado = false;
            this.rondas = 0;
        }

        [TestMethod]
        public void Test_Actualizar_Mesa()
        {
            //Este metodo verifica que se llame al metodo suscrito al evento de actualizar la carta en mesa.

            //Arrange
            this.unoTest = new UNO(JuegoTerminado, ActualizarMesa, UNOhandler,
            NuevaNotificacion, ActualizarCartas);

            //Act
            Task Juego = Task.Run(() => unoTest.Jugar(2, 0));
            Juego.Wait();

            //Assert
            Assert.IsTrue(this.flagCartaActualizada);

            //Reinicio las variables para usarlas con otros test si es necesario.
            this.flagCartaActualizada = false;

        }

        [TestMethod]
        public void Test_Dice_UNO()
        {
            //Este metodo verifica que se llame al metodo suscrito al evento UNO(cuando al jugador
            //le queda una carta en mano).

            //Arrange
            this.unoTest = new UNO(JuegoTerminado, ActualizarMesa, UNOhandler,
            NuevaNotificacion, ActualizarCartas);

            //Act
            Task Juego = Task.Run(() => unoTest.Jugar(2, 0));
            Juego.Wait();

            //Assert
            Assert.IsTrue(this.flagDiceUNO);

            //Reinicio las variables para usarlas con otros test si es necesario.
            this.flagDiceUNO = false;

        }

        [TestMethod]
        public void Test_Notificacion()
        {
            //Este metodo verifica que se llame al metodo suscrito al evento UNO(cuando al jugador
            //le queda una carta en mano).

            //Arrange
            this.unoTest = new UNO(JuegoTerminado, ActualizarMesa, UNOhandler,
            NuevaNotificacion, ActualizarCartas);

            //Act
            Task Juego = Task.Run(() => unoTest.Jugar(2, 0));
            Juego.Wait();

            //Assert
            Assert.IsTrue(this.flagNotificacion);

            //Reinicio las variables para usarlas con otros test si es necesario.
            this.flagNotificacion = false;
        }

        #region Metodos para probar eventos
        private void JuegoTerminado(Jugador jugador, EstadisticasDePartida estadisticas)
        {
            this.flagJuegoTerminado = true;
            this.rondas = estadisticas.Turnos;
        }

        private void ActualizarMesa()
        {
            this.flagCartaActualizada = true;
        }

        private void UNOhandler(Jugador jugador)
        {
            //Verifico que se llamo cuando el jugador tenia 1 carta
            if (jugador.Cartas.Count==1)
            {
                this.flagDiceUNO = true;
            }
            else { this.flagDiceUNO = false; }
        }

        private void NuevaNotificacion(string msj)
        {
            if (msj != null && msj != String.Empty)
            {
                this.flagNotificacion = true;
            }
            else { this.flagNotificacion = false; }
        }

        private void ActualizarCartas(Jugador jugador)
        {

        }
        #endregion


    }
}
