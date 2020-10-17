using ObligatorioMVC.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ObligatorioMVC.Models
{
    public class GestoraDocentes
    {
        private readonly InstitutoContext Contexto;

        public GestoraDocentes(InstitutoContext context)
        {
            Contexto = context;
        }

        public void AgregarDocente(Docente d)
        {
            Contexto.Docentes.Add(d);
        }

        public List<Docente> ObtenerDocentes()
        {
            return new InstitutoContext().Docentes.ToList();
        }

        public Docente ObtenerDocente(string documento)
        {
            return new InstitutoContext().Docentes.FirstOrDefault(d => d.Documento == documento);
        }

        public bool EliminarDocente(string documento)
        {
            var docente = Contexto.Docentes.Find(documento);
            if (docente != null)
            {
                Contexto.Docentes.Remove(docente);
                return true;
            }
            return false;
        }

        public bool ModificarDocente(Docente docenteConDatos)
        {
            Contexto.Entry(docenteConDatos).State = EntityState.Modified;
            return true;
        }
    }
}