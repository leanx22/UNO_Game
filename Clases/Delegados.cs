namespace Clases
{
    public delegate void Error(string textoExcepcion);
    public delegate List<Carta> obtenerCartas(int cant, float probabilidadEspecial);
    public delegate void DelegadoNotificacion(string txt);
    public delegate void DelegadoJugador(Jugador jugador);
    public delegate void DelegadoCarta(Carta carta);
    public delegate void DelegadoGameOver(Jugador jugador,EstadisticasDePartida estadisticasDeLaPartida);
}