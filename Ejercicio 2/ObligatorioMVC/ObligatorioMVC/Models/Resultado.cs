using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ObligatorioMVC.Models
{
    [Table("Resultados")]
    public class Resultado
    {
        [Key]
        public int Numero { get; set; }
        [Required]
        [Range(0, 100)]
        public int Nota { get; set; }
        [Required]
        public string ResultadoCurso { get; set; }
        [ForeignKey("Alumno")]
        public string DocumentoAlumno { get; set; }
        public Alumno Alumno { get; set; }
        [ForeignKey("CursoAsignatura")]
        public int CodigoCurso { get; set; }
        public CursoAsignatura CursoAsignatura { get; set; }
        
    }
}
   