using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ObligatorioMVC.Models
{
    [Table("Carreras")]
    public class Carrera
    {
        
        public string Codigo { get; set; }
        [Key]
        public string Nombre { get; set; }
    }
}