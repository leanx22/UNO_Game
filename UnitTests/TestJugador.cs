using Clases;
namespace UnitTests
{
    [TestClass]
    public class TestJugador
    {
        private Mazo mazo = new Mazo();

        [TestMethod]
        public void Test_tirar_carta()
        {
            //Arrange
            bool tiroUnaCarta;
            Carta cartaEnMesa = new Carta(ColoresDeCarta.Verde,4,Comportamiento.Normal);           
            Jugador jugador = new Jugador(-1, "Tester", 0.2f, 0);
            jugador.Cartas.Add(new Carta(ColoresDeCarta.Verde,8,Comportamiento.Normal));

            //Act
            tiroUnaCarta = jugador.IniciarTurno(cartaEnMesa);

            //Assert
            Assert.IsTrue(tiroUnaCarta);        
        }

        [TestMethod]
        public void Test_tirar_especial()
        {
            //Arrange
            bool tiroUnaCarta=false;
            Carta cartaEnMesa = new Carta(ColoresDeCarta.Verde, 4, Comportamiento.Normal);
            Jugador jugador = new Jugador(-1, "Tester", 0.2f, 0);
            jugador.Cartas.Add(new Carta(ColoresDeCarta.Rojo, 8, Comportamiento.Normal));
            jugador.Cartas.Add(new Carta(ColoresDeCarta.Negro, -4, Comportamiento.TomaCuatro));
            jugador.OnCartaTirada += Console.WriteLine;
            //Act
            tiroUnaCarta = jugador.IniciarTurno(cartaEnMesa);

            //Assert
            Assert.IsTrue(tiroUnaCarta);
        }

        [TestMethod]
        public void Test_Jugador_sin_acciones()
        {
            //Arrange
            bool tiroUnaCarta;
            Carta cartaEnMesa = new Carta(ColoresDeCarta.Verde, 4, Comportamiento.Normal);
            Jugador jugador = new Jugador(-1, "Tester", 0.2f, 0);
            jugador.Cartas.Add(new Carta(ColoresDeCarta.Rojo, 8, Comportamiento.Normal));
            //Act
            tiroUnaCarta = jugador.IniciarTurno(cartaEnMesa);

            //Assert
            Assert.IsFalse(tiroUnaCarta);
        }

        [TestMethod]
        public void Test_Jugador_Toma_MasCuatro()
        {
            //Arrange
            Carta cartaEnMesa = new Carta(ColoresDeCarta.Negro, -4, Comportamiento.TomaCuatro);
            Jugador jugador = new Jugador(-1, "Tester", 0.2f, 0);
            jugador.Cartas.Add(new Carta(ColoresDeCarta.Rojo, 8, Comportamiento.Normal));
            jugador.OnTomaCarta = this.mazo.ObtenerCarta;
            
            //Act
            jugador.IniciarTurno(cartaEnMesa);

            //Assert
            Assert.AreEqual(5,jugador.Cartas.Count);
        }

        [TestMethod]
        public void Test_Jugador_Toma_MasDos()
        {
            //Arrange
            Carta cartaEnMesa = new Carta(ColoresDeCarta.Amarillo, -2, Comportamiento.TomaDos);
            Jugador jugador = new Jugador(-1, "Tester", 0.2f, 0);
            jugador.Cartas.Add(new Carta(ColoresDeCarta.Rojo, 8, Comportamiento.Normal));
            jugador.OnTomaCarta = this.mazo.ObtenerCarta;
            jugador.OnCartaTirada += Console.WriteLine;

            //Act
            jugador.IniciarTurno(cartaEnMesa);

            //Assert
            Assert.IsTrue(jugador.Cartas.Count>=2);
        }

        [TestMethod]
        public void Test_Sobrecarga_Operadores()
        {
            Carta cartaPrueba = new Carta();
            Jugador jugador = new Jugador(0,"",-1f,0);

            jugador += cartaPrueba;
            Assert.AreEqual(1, jugador.Cartas.Count);
            jugador -= cartaPrueba;
            Assert.AreEqual(0, jugador.Cartas.Count);
        }

        [TestMethod]
        public void Test_Obtener_Color_Mas_Repetido()
        {
            Jugador jugador = new Jugador(0, "", 0, 0);
            jugador.Cartas.Add(new Carta(ColoresDeCarta.Amarillo,2,Comportamiento.Normal));
            jugador.Cartas.Add(new Carta(ColoresDeCarta.Amarillo, 8, Comportamiento.Normal));
            jugador.Cartas.Add(new Carta(ColoresDeCarta.Amarillo, -2, Comportamiento.TomaDos));
            jugador.Cartas.Add(new Carta(ColoresDeCarta.Verde, 5, Comportamiento.Normal));

            ColoresDeCarta color = jugador.ObtenerColorMasRepetidoEnMano();
            Assert.AreEqual(color, ColoresDeCarta.Amarillo);
        }

    }
}