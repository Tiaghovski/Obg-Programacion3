using Dominio;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioWCFObligatorio
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AlumnoService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AlumnoService.svc or AlumnoService.svc.cs at the Solution Explorer and start debugging.
    public class AlumnoService : IAlumnoService
    { 

        public bool AgregarAlumno(ServicioWCFObligatorio.Alumno alumno)
        {
            if(GestoraAlumnos.Instancia.AgregarAlumno(new Dominio.Alumno
            {
                apellido = alumno.apellido,
                cedula = alumno.cedula,
                nombre = alumno.nombre,
                numero = alumno.numero
            }))
                return true;
            else
            {
                return false;
            }
        }

        public List<ServicioWCFObligatorio.Alumno> ObtenerTodos()
        {
            return GestoraAlumnos.Instancia.ObtenerTodos().Select(
                a=> new ServicioWCFObligatorio.Alumno
                {
                    apellido = a.apellido,
                    cedula = a.cedula,
                    nombre = a.nombre,
                    numero = a.numero
                }).ToList();
        }
    }
}
