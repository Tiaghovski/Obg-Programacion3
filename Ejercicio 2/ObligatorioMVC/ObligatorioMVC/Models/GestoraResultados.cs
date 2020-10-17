using ObligatorioMVC.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObligatorioMVC.Models
{
    public class GestoraResultados
    {
        private readonly InstitutoContext Contexto;

        public GestoraResultados(InstitutoContext context)
        {
            Contexto = context;
        }

        public void AgregarResultado(Resultado R)
        {
            Contexto.Resultados.Add(R);
        }

        public List<Resultado> ObtenerResultados()
        {
            return new InstitutoContext().Resultados.ToList();
        }

        public Resultado ObtenerResultado(string cedula)
        {
            return new InstitutoContext().Resultados.FirstOrDefault(r => r.DocumentoAlumno == cedula);

        }
    }
}
