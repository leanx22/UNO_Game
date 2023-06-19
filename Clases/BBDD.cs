using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Clases
{
   public class BBDD
    {
        //Encargada de manejar la conexion con la base.
        //Se encarga del Open() y Close() de la base.
        private SqlConnection _connection;

        //Se encarga de realizar las consultas SQL hacia
        //la base de datos especificada por _connection.
        private SqlCommand _command;


        private SqlDataReader _reader; //Lector de datos

        public BBDD()
        {
            //Al inicializarlo, le pasamos la "cadena de conexion" del servidor.
            this._connection = new SqlConnection(@"Data Source = localhost;
                                Database = UNO;
                                Trusted_Connection = True;");

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
            catch //En caso de error
            {
                jugadores = new List<Jugador>();
            }
            finally//Siempre cerrar la conexion.
            {
                this._connection.Close();               
            }
            return jugadores;
        }

        #endregion

        #region PRUEBA
        public void HacerConsulta()
        {
            try
            {
                //Le doy mi consulta.
                this._command.CommandText = "SELECT * FROM MiTabla";

                //Abro la conexion.
                this._connection.Open();

                //ExecuteReader() porque nos va a DEVOLVER REGISTROS.
                this._reader = this._command.ExecuteReader();

                int i = 1;
                //Bucle mientras siga leyendo. Aca va la logica.
                while (_reader.Read())
                {
                    Console.WriteLine("Dato leido: " + i);
                    i++;

                    //Accedo a los datos leidos, pero tengo que saber la identificacion
                    //de las columnas.
                    string id = _reader["id"].ToString();
                    string str = _reader["string"].ToString();
                    string intt = _reader["int"].ToString();

                    Console.WriteLine("datos-> |" + id + "|" + str + "|" + intt + "|");
                }

            }
            catch (Exception ex) //En caso de error
            {
                Console.WriteLine("Exploto todo: " + ex.Message);
            }
            finally { this._connection.Close(); }//Siempre cerrar la conexion.

        }

        public void InsertarEnTabla(string str, int intt, DateTime dt)
        {
            try
            {
                //Abro la conexion
                this._connection.Open();

                //Comando
                this._command.CommandText = "INSERT INTO MiTabla VALUES (@str, @intt, @date)";

                //Le digo el dato que le corresponde a cada parametro.
                this._command.Parameters.AddWithValue("@str", str);
                this._command.Parameters.AddWithValue("@intt", intt);
                this._command.Parameters.AddWithValue("@date", dt);

                //ExecuteNonQuery() ya que no va a devolver nada (NO es una consulta).
                this._command.ExecuteNonQuery();
                //No olvidar de hacer Clear() de los parametros.
                this._command.Parameters.Clear();
                Console.WriteLine("Listo!");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Rip: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Cerrando conexion...");
                this._connection.Close();
            }
        }
        #endregion

    }
}
