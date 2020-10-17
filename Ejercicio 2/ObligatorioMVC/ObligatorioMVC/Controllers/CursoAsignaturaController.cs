using ObligatorioMVC.Context;
using ObligatorioMVC.Models;
using ObligatorioMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static ObligatorioMVC.Controllers.AutenticacionController;

namespace ObligatorioMVC.Controllers
{
    public class CursoAsignaturaController : Controller
    {
        private readonly InstitutoContext Contexto;

        public CursoAsignaturaController()
        {
            Contexto = new InstitutoContext();
        }

        [FuncionarioFilter]
        public ActionResult Alta()
        {
            var lista1 = listadoAsignaturas();
            var lista2 = listadoDocentes();
            var v = new CursoAsignaturaViewModel();
            v.ListaAsignaturas = lista1;
            v.ListaDocentes = lista2;
            return View(v);
        }

        private List<SelectListItem> listadoAsignaturas()
        {
            var lista = new List<SelectListItem>();
            foreach (var a in new GestoraAsignaturas(Contexto).ObtenerAsignaturas())
            {
                lista.Add(new SelectListItem()
                {
                    Value = a.Nombre,
                    Text = a.Nombre
                });

            }
            return lista;
        }

        private List<SelectListItem> listadoDocentes()
        {
            var lista = new List<SelectListItem>();
            foreach (var d in new GestoraDocentes(Contexto).ObtenerDocentes())
            {
                lista.Add(new SelectListItem()
                {
                    Value = d.Documento.ToString(),
                    Text = d.Nombre + " " + d.Apellido,
                });

            }
            return lista;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alta(CursoAsignaturaViewModel ca)
        {
            if (!ModelState.IsValid)
            {
                ca.ListaAsignaturas = listadoAsignaturas();
                ca.ListaDocentes = listadoDocentes();
                return View(ca);
            }
            else
            {
                //var docente = new GestoraDocentes(Contexto).ObtenerDocente(ca.DocumentoDocente);

                //MODIFICAR EL OBTENERDOCENTE DE GESTORADOCENTE, PARA QUE UTILICE FIND EN LUGAR DE FIRSTORDEFAULT
                //POR AHORA LLAMO AL CONTEXTO AQUÍ PARA QUE VEAS QUE ES LO QUE HAY QUE HACER.

                var docente = Contexto.Docentes.Find(ca.DocumentoDocente);
                var asignatura = Contexto.Asignaturas.Find(ca.NombreAsignatura);
                if (docente != null && asignatura != null )
                {
                    CursoAsignatura nuevoCA = new CursoAsignatura()
                    {
                        fechaComienzo = ca.fechaComienzo,
                        fechaFin = ca.fechaFin,
                        Finalizado = ca.Finalizado,
                        Asignatura = asignatura,
                        Docente = docente,
                        DocumentoDocente = ca.DocumentoDocente

                    };
                    GestoraCursosAsignatura gca = new GestoraCursosAsignatura(Contexto);
                    gca.AgregarCursoAsignatura(nuevoCA);
                    Contexto.SaveChanges();
                    ViewData["Mensaje"]= "Curso de Asignatura Agregado!";
                    return RedirectToAction("Alta");
                }                
                return RedirectToAction("Alta");
            }
        }

        public ActionResult Lista()
        {
            return View(new GestoraCursosAsignatura(Contexto).ObtenerCursosAsignaturas());
        }



    }
}

