using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ObligatorioMVC.Models
{
    [Table("Inscripciones")]         
    public class Inscripcion
    {
            [Key]
            public int Numero { get; set; }
            [Required(ErrorMessage = "Debe seleccionar el Alumno")]
            public Alumno Alumno { get; set; }
            [ForeignKey("Alumno")]
            public string DocumentoAlumno { get; set; }
            [Required(ErrorMessage = "Debe seleccionar el Curso Asignatura")]
            public CursoAsignatura CursoAsignatura { get; set; }
            [ForeignKey("CursoAsignatura")]
            public int CodCurAsi { get; set; }

    }
}
