using ObligatorioMVC.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObligatorioMVC.Models
{
    public class GestoraCarreras
    {
        private readonly InstitutoContext Contexto;

        public GestoraCarreras(InstitutoContext context)
        {
            Contexto = context;
        }

        public List<Carrera> ObtenerCarreras()
        {
            return new InstitutoContext().Carreras.ToList();
        }

       
            
    }
}