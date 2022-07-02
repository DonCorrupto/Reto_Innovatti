using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Backend_Reto.Models
{
    public class Asociado
    {
        public string nombre  { get; set; }

        public string apellido { get; set; }

        public int cedula { get; set; }

        public string correo { get; set; }


        public Asociado() { }  

        public Asociado(string Nombre, string Apellido, int Cedula, string Correo)
        {
            nombre = Nombre;
            apellido = Apellido;
            cedula= Cedula;
            correo = Correo;
        }

        // Prueba de informacion de asociados

        private string conn;
        public string strinCon(string nomBD)
        {
            conn = ConfigurationManager.ConnectionStrings[nomBD].ConnectionString;
            return conn;
        }

    }
}