using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ObligatorioMVC.Models
{
    [Table("Docentes")]
    public class Docente
    {
        [Key]
        [Required(ErrorMessage = "Debe ingresar la cédula")]
        public string Documento { get; set; }
        [Required(ErrorMessage = "Debe ingresar el nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar el apellido")]
        public string Apellido { get; set; }

        public List<CursoAsignatura> CursosAsignatura { get; set; }
    }
}