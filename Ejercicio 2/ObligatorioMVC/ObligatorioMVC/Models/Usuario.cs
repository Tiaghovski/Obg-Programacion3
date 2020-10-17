using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ObligatorioMVC.Models
{
    public class Usuario
    {
        [Required(ErrorMessage = "Debe ingresar el nombre de usuario")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "Debe ingresar la clave")]
        public string Clave { get; set; }    
        public RolUsuario Rol { get; set; }
    }
}