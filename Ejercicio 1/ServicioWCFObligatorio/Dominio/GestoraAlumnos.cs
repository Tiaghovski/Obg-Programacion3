using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class GestoraAlumnos
    {
        public static IMapperAlumno Mapper { get; set; }
        private static GestoraAlumnos gestora = null;

        public static GestoraAlumnos Instancia
        {
            get
            {
                if (gestora == null)
                {
                    gestora = new GestoraAlumnos();
                }
                return gestora;
            }
        }       

        public bool AgregarAlumno(Alumno alumno)
        {
            if (String.IsNullOrWhiteSpace(alumno.cedula) || String.IsNullOrWhiteSpace(alumno.nombre) ||
                String.IsNullOrWhiteSpace(alumno.apellido))
            {                
                throw new DException("Debe ingresar la cédula");
                throw new DException("Debe ingresar el nombre");
                throw new DException("Debe ingresar el apellido");
            }
            if (BuscarAlumnoPorNumero(alumno.numero) == null)
            {
                if (BuscarAlumnoPorCedula(alumno.cedula) == null)
                {
                    Mapper.AgregarAlumnoDB(alumno);
                    return true;
                }
            }
            return false;
        }           

        public List<Alumno> ObtenerTodos()
        {
            return Mapper.ObtenerTodos();
        }

        public Alumno BuscarAlumnoPorCedula(string xCedula)
        {
            foreach (Alumno a in Mapper.ObtenerTodos())
            {
                if (a.cedula == xCedula)
                {
                    return a;
                }
            }
            return null;
        }

        public Alumno BuscarAlumnoPorNumero(int xNumero)
        {
            foreach (Alumno a in Mapper.ObtenerTodos())
            {
                if (a.numero == xNumero)
                {
                    return a;
                }
            }
            return null;
        }
    }
}

