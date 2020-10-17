using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Dominio
{
    public class Alumno
    {
        public int numero { get; set; }
        public string cedula { get; set; }       
        public string nombre { get; set; }        
        public string apellido { get; set; }
    }
}