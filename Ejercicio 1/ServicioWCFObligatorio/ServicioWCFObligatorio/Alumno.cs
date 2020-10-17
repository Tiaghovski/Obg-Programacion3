using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServicioWCFObligatorio
{
    [DataContract]
    public class Alumno
    {
        [DataMember]       
        public int numero { get; set; }
        [DataMember]
        public string cedula { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string apellido { get; set; }
    }
}