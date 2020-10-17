using ObligatorioMVC.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObligatorioMVC.Models
{
    public class GestoraAsignaturas
    {
        private readonly InstitutoContext Contexto;

        public GestoraAsignaturas(InstitutoContext context)
        {
            Contexto = context;
        }
       
        public List<Asignatura> ObtenerAsignaturas()
        {
            return new InstitutoContext().Asignaturas.ToList();
        }

        public Asignatura ObtenerAsignatura(string nombre)
        {
            return new InstitutoContext().Asignaturas.FirstOrDefault(a => a.Nombre == nombre);
        }

    }
}