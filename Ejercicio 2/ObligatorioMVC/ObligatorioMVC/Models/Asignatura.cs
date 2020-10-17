using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ObligatorioMVC.Models
{
    [Table("Asignaturas")]
    public class Asignatura
    {   
        
        public string Codigo { get; set; }
        [Key]
        public string Nombre { get; set; }      
        [ForeignKey("Carrera")]
        public string NombreCarrera { get; set; }
        public Carrera Carrera { get; set; }
        public bool Exonerable { get; set; }
        public bool GananciaCurso { get; set; }
    }
}