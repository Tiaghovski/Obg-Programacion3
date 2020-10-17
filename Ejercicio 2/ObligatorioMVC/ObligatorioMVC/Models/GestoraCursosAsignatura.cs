using ObligatorioMVC.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObligatorioMVC.Models
{
    public class GestoraCursosAsignatura
    {
        private readonly InstitutoContext Contexto;

        public GestoraCursosAsignatura(InstitutoContext context)
        {
            Contexto = context;
        }

        public void AgregarCursoAsignatura(CursoAsignatura ca)
        {
            Contexto.CursosAsignaturas.Add(ca);
        }

        public List<CursoAsignatura> ObtenerCursosAsignaturas()
        {
            return new InstitutoContext().CursosAsignaturas.ToList();
        }

        public CursoAsignatura ObtenerCursoAsignatura(int numero)
        {
            return new InstitutoContext().CursosAsignaturas.FirstOrDefault(ca => ca.Numero == numero);
        }

      
    }
}