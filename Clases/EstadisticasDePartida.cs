﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Clases
{
    public class EstadisticasDePartida
    {
        private string ganador;
        private int cantidadJugadores;
        private int cartasNormalesTiradas;
        private int cartasEspecialesTiradas;
        private int turnos;
        private DateTime fecha;

        public EstadisticasDePartida()
        {
            this.ganador = "";
            this.cantidadJugadores = 0;
            this.turnos = 0;
            this.cartasNormalesTiradas = 0;
            this.cartasEspecialesTiradas= 0;
            this.fecha = DateTime.Now;
        }

        public EstadisticasDePartida(string ganador,int cantJugadores,int turnos,int cartasNormales,
            int cartasEspeciales,DateTime fecha)
        {
            this.ganador = ganador;
            this.cantidadJugadores = cantJugadores;
            this.turnos = turnos;
            this.cartasNormalesTiradas = cartasNormales;
            this.cartasEspecialesTiradas = cartasEspeciales;
            this.fecha = fecha;
        }

        public string Ganador { get { return this.ganador; } set { this.ganador = value; } }
        public int Turnos { get { return this.turnos; } set { this.turnos = value; } }
        public DateTime Fecha { get { return this.fecha; } }
        public int CantidadDeJugadores 
        {
            get { return this.cantidadJugadores; }
            set { this.cantidadJugadores = value; }
        }
        public int CartasNormalesUsadas
        {
            get { return this.cartasNormalesTiradas; }
            set { this.cartasNormalesTiradas = value; }
        }
        public int CartasEspecialesUsadas
        {
            get { return this.cartasEspecialesTiradas; }
            set { this.cartasEspecialesTiradas = value; }
        }
    }
}
