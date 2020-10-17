using ObligatorioMVC.Context;
using ObligatorioMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static ObligatorioMVC.Controllers.AutenticacionController;

namespace ObligatorioMVC.Controllers
{
    public class DocenteController : Controller
    {
        private readonly InstitutoContext Contexto;

        public DocenteController()
        {
            Contexto = new InstitutoContext();
        }
        
        public ActionResult Index()
        {
            return View();
        }

        [FuncionarioFilter]

        [HttpGet]
        public ActionResult Alta()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alta(Docente docente)
        {
            if (!this.ModelState.IsValid)
            {
                return View(docente);
            }
            else
            {
                try
                {                    
                    GestoraDocentes gd = new GestoraDocentes(Contexto);
                    gd.AgregarDocente(docente);
                    Contexto.SaveChanges();
                    ViewData["Mensaje"] = "Docente agregado!";
                    RedirectToAction("Alta");
                }
                catch (DomainException ex)
                {
                    this.ModelState.AddModelError("", ex.Message);
                }
                catch (Exception ex)
                {
                    this.ModelState.AddModelError("", "No se pudo agregar al Docente");
                }
                return View(docente);
            }

        }

        public ActionResult Lista()
        {
            return View(new GestoraDocentes(Contexto).ObtenerDocentes());
        }

      
        [HttpGet]
        [Route("docente/eliminar/{Documento}")]
        public ActionResult Eliminar(string documento)
        {
            string id = documento;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Docente d = new GestoraDocentes(Contexto).ObtenerDocente(id);
                if (d == null)
                {
                    return HttpNotFound();
                }

                return View(d);
            }
        }

        [HttpPost]
        [Route("docente/eliminar/{Documento}")]
        public ActionResult Eliminarx(string documento)
        {            
            var res = new GestoraDocentes(Contexto).EliminarDocente(documento);
            if (res)
            {
                ViewBag.Mensaje = "Docente eliminado";
                Contexto.SaveChanges();
            }
            else
            {
                ViewBag.Mensaje = "No se pudo eliminar el Docente";
            }
            return View("Lista", new GestoraDocentes(Contexto).ObtenerDocentes());
        }

        [HttpGet]
        [Route("docente/editar/{Documento}")]
        public ActionResult Editar(string documento)
        {
            if (documento == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var d = new GestoraDocentes(Contexto).ObtenerDocente(documento);
                if (d == null)
                {
                    return HttpNotFound();
                }
                return View(d);
            }
        }

        [HttpPost]
        [Route("docente/editar/{Documento}")]
        public ActionResult Modificar(Docente docente)
        {
            if (!this.ModelState.IsValid)
            {
                return View(docente);
            }            
            GestoraDocentes gd = new GestoraDocentes(Contexto);
            gd.ModificarDocente(docente);
            ViewBag.Mensaje = "Se modificó el Docente";
            Contexto.SaveChanges();
            return View("Lista", gd.ObtenerDocentes());
        }
    }
}
