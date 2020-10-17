using ObligatorioMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ObligatorioMVC.Context
{
    public class InstitutoContext : DbContext
    {
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<CursoAsignatura> CursosAsignaturas { get; set; }   
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Resultado> Resultados { get; set; }


        public InstitutoContext() : base("strConexion")
        {

        }
    }
}