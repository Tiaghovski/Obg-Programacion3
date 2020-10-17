using ObligatorioMVC.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObligatorioMVC.Models
{
    public class GestoraAlumnos
    {
        private readonly InstitutoContext Contexto;

        public GestoraAlumnos(InstitutoContext context)
        {
            Contexto = context;
        }

        public List<Alumno> ObtenerAlumnos()
        {
            return new InstitutoContext().Alumnos.ToList();
        }

        public Alumno ObtenerAlumno(string cedula)
        {
            return new InstitutoContext().Alumnos.FirstOrDefault(a => a.Cedula == cedula);
        }

        public void AgregarAlumno(Alumno a)
        {
            Contexto.Alumnos.Add(a);
        }
    }
}