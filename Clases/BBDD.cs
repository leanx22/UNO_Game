using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Clases
{
   public class BBDD : IBaseDeDatosParaJuegoDeCartas
    {
        //Encargada de manejar la conexion con la base.
        //Se encarga del Open() y Close() de la base.
        private SqlConnection _connection;

        //Se encarga de realizar las consultas SQL hacia
        //la base de datos especificada por _connection.
        private SqlCommand _command;

        //Lector de datos
        private SqlDataReader _reader;

        public event Error OnError;

        public BBDD()
        {
            //Al inicializarlo, le pasamos la "cadena de conexion" del servidor.
            this._connection = new SqlConnection(@"Data Source = .;
                                Database = UNO;
                                Trusted_Connection = True;
                                User ID = sa;
                                Password = alumno");

            this._command = new SqlCommand();
            //Luego de instanciar, debemos definir el tipo, nosotros usamos "Text".
            this._command.CommandType = System.Data.CommandType.Text;
            //Con la prop Connection establecemos cual es la conexion a usar.
            this._command.Connection = _connection;
            //Hay una propiedad que es .CommandText en la que escribimos nuestra consulta.

        }

        #region Lectura
        public List<Jugador> ObtenerJugadores()
        {
            List<Jugador> jugadores = new List<Jugador>();
            try
            {
                //Le doy mi consulta.
                this._command.CommandText = "SELECT * FROM Jugador";

                //Abro la conexion.
                this._connection.Open();

                //ExecuteReader() porque nos va a DEVOLVER REGISTROS.
                this._reader = this._command.ExecuteReader();

                //Bucle mientras siga leyendo. Aca va la logica.
                while (_reader.Read())
                {
                    //Accedo a los datos leidos, pero tengo que saber la identificacion
                    //de las columnas.
                    int id = (int)_reader["id"];
                    string nombre = _reader["Nombre"].ToString();
                    double suerte = (double)_reader["Suerte"];
                    int pGanadas = (int)_reader["PartidasGanadas"];

                    jugadores.Add(new Jugador(id, nombre, (float)suerte, pGanadas));
                    
                }
            }
            catch(Exception ex) //En caso de error
            {
                this.OnError(ex);
                jugadores = new List<Jugador>();
            }
            finally//Siempre cerrar la conexion.
            {
                this._connection.Close();               
            }
            return jugadores;
        }

        public List<EstadisticasDePartida> ObtenerHistorialDePartidas()
        {
            List<EstadisticasDePartida> historial = new List<EstadisticasDePartida>();
            try
            {
                //Le doy mi consulta.
                this._command.CommandText = "SELECT * FROM HistorialPartidas";

                //Abro la conexion.
                this._connection.Open();

                //ExecuteReader() porque nos va a DEVOLVER REGISTROS.
                this._reader = this._command.ExecuteReader();

                //Bucle mientras siga leyendo. Aca va la logica.
                while (_reader.Read())
                {
                    //Accedo a los datos leidos, pero tengo que saber la identificacion
                    //de las columnas.
                    string nombre = _reader["nombre_ganador"].ToString();
                    int cantJugadores = (int)_reader["cantidad_jugadores"];
                    int cantCartasNormales = (int)_reader["cartas_tiradas"];
                    int cantCartasEspeciales = (int)_reader["especiales_tiradas"];
                    int cantTurnos = (int)_reader["cantidad_turnos"];
                    DateTime fecha = (DateTime)_reader["fecha"];

                    historial.Add(new EstadisticasDePartida(nombre,cantJugadores,cantTurnos,cantCartasNormales
                        ,cantCartasEspeciales ,fecha));

                }
            }
            catch(Exception ex) //En caso de error
            {
                this.OnError(ex);
                historial = new List<EstadisticasDePartida>();
            }
            finally//Siempre cerrar la conexion.
            {
                this._connection.Close();
            }
            return historial;
        }

        #endregion

        
        #region Escritura
        public void GuardarPartidaEnHistorial(EstadisticasDePartida partida)
        {
            try
            {
                //Abro la conexion
                this._connection.Open();

                //Comando
                this._command.CommandText = "INSERT INTO HistorialPartidas VALUES (@nombre, @jugadores," +
                    "@cartasNormales, @cartasEsp, @turnos, @fecha)";

                //Le digo el dato que le corresponde a cada parametro.
                this._command.Parameters.AddWithValue("@nombre", partida.Ganador);
                this._command.Parameters.AddWithValue("@jugadores", partida.CantidadDeJugadores);
                this._command.Parameters.AddWithValue("@cartasNormales", partida.CartasNormalesUsadas);
                this._command.Parameters.AddWithValue("@cartasEsp", partida.CartasEspecialesUsadas);
                this._command.Parameters.AddWithValue("@turnos", partida.Turnos);
                this._command.Parameters.AddWithValue("@fecha", partida.Fecha);

                //ExecuteNonQuery() ya que no va a devolver nada (NO es una consulta).
                this._command.ExecuteNonQuery();
                //No olvidar de hacer Clear() de los parametros.
                this._command.Parameters.Clear();
            }
            catch (Exception ex)
            {
                this.OnError(ex);
            }
            finally
            {
                this._connection.Close();
            }
        }

        public void AgregarJugador(Jugador jugador)
        {
            try
            {
                //Abro la conexion
                this._connection.Open();

                //Comando
                this._command.CommandText = "INSERT INTO Jugador VALUES (@nombre, @suerte, @partidasGanadas)";


                //Le digo el dato que le corresponde a cada parametro.
                this._command.Parameters.AddWithValue("@nombre", jugador.Nombre);
                this._command.Parameters.AddWithValue("@suerte", jugador.Suerte);
                this._command.Parameters.AddWithValue("@partidasGanadas", jugador.PartidasGanadas);

                //ExecuteNonQuery() ya que no va a devolver nada (NO es una consulta).
                this._command.ExecuteNonQuery();
                this._command.Parameters.Clear();
            }
            catch (Exception ex)
            {
                this.OnError(ex);
            }
            finally
            {
                this._connection.Close();
            }
        }

        public void BorrarJugador(Jugador jugador)
        {
            try
            {
                //Comando
                this._command.CommandText = "DELETE FROM Jugador WHERE Nombre = @nombre";

                //Le digo el dato que le corresponde a cada parametro.
                this._command.Parameters.AddWithValue("@nombre", jugador.Nombre);

                this._connection.Open();
                this._command.ExecuteNonQuery();
                this._command.Parameters.Clear();
            }
            catch (Exception ex)
            {
                this.OnError(ex);
            }
            finally
            {
                this._connection.Close();
            }
        }

        public void ActualizarPartidasGanadas(Jugador jugador)
        {
            try
            {
                //Abro la conexion
                this._connection.Open();

                //Comando
                this._command.CommandText = "UPDATE Jugador SET PartidasGanadas = @partidasGanadas" +
                    " WHERE id = @id;";


                //Le digo el dato que le corresponde a cada parametro.
                this._command.Parameters.AddWithValue("@partidasGanadas", jugador.PartidasGanadas);
                this._command.Parameters.AddWithValue("@id", jugador.ID);

                //ExecuteNonQuery() ya que no va a devolver nada (NO es una consulta).
                this._command.ExecuteNonQuery();
                this._command.Parameters.Clear();
            }
            catch (Exception ex)
            {
                this.OnError(ex);
            }
            finally
            {
                this._connection.Close();
            }
        }
        
        #endregion

    }
}
