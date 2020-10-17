using ObligatorioMVC.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObligatorioMVC.Models
{
    public class GestoraInscripciones
    {
        private readonly InstitutoContext Contexto;

        public GestoraInscripciones(InstitutoContext context)
        {
            Contexto = context;
        }

        public void AgregarInscripcion(Inscripcion I)
        {
            Contexto.Inscripciones.Add(I);
        }

        public List<Inscripcion> ObtenerInscripciones()
        {
            return new InstitutoContext().Inscripciones.ToList();
        }

        public Inscripcion ObtenerInscripcion(int numero)
        {
            return new InstitutoContext().Inscripciones.FirstOrDefault(i => i.Numero == numero);
        }

      
    }
}