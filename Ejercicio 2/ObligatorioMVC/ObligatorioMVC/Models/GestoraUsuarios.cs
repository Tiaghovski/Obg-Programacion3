using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObligatorioMVC.Models
{
    public class GestoraUsuarios
    {
        public static List<Usuario> colUsuarios = new List<Usuario>
        {
             new Usuario{NombreUsuario= "juan", Clave = "123", Rol = RolUsuario.Docente},
             new Usuario{NombreUsuario= "elisa", Clave = "321", Rol = RolUsuario.Funcionario},             
        };

        public static RolUsuario ValidarCredencialesUsuario(Usuario u)
        {
            var rol = colUsuarios.Where(usu => usu.NombreUsuario.Equals(u.NombreUsuario) &&
            usu.Clave.Equals(u.Clave)).Select(usu => usu.Rol).FirstOrDefault();
            return rol;
        }
    }
}
