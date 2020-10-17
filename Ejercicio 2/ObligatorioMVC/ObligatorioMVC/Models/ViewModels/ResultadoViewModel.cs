using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ObligatorioMVC.Models.ViewModels
{
    public class ResultadoViewModel
    {
        [Key]
        public int Numero { get; set; }
        [Required(ErrorMessage = "Debe seleccionar el Alumno")]
        public string DocumentoAlumno { get; set; }
        public IEnumerable<SelectListItem> ListaAlumnos { get; set; }
        [Required(ErrorMessage = "Debe seleccionar el Curso Asignatura")]
        public int CodigoCurAsig { get; set; }
        public IEnumerable<SelectListItem> ListaCursosAsignatura { get; set; }
        [Required(ErrorMessage = "Debe ingresar la nota")]
        public int Nota { get; set; }
    }
}