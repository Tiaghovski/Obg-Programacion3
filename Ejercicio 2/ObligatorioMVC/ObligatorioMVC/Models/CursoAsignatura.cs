using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ObligatorioMVC.Models
{
    [Table("CursosAsignaturas")]
    public class CursoAsignatura
    {
        [Key]
        public int Numero { get; set; }
        [Required(ErrorMessage = "Debe ingresar la fecha de comienzo")]
        public DateTime fechaComienzo { get; set; }
        [Required(ErrorMessage = "Debe ingresar la fecha de finalización")]
        public DateTime fechaFin { get; set; }
        [Required(ErrorMessage = "Debe seleccionar si ha finalizado o no")]
        public Finalizado Finalizado { get; set; }
        [Required(ErrorMessage = "Debe seleccionar la asignatura")]        
        public Asignatura Asignatura { get; set; }
        [ForeignKey("Asignatura")]
        public string NombreAsignatura { get; set; }        
        [Required(ErrorMessage = "Debe seleccionar el docente")]        
        public Docente Docente { get; set; }
        [ForeignKey ("Docente")]
        public string DocumentoDocente { get; set; }
        





    }
}