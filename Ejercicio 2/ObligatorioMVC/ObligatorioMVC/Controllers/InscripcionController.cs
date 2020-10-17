using ObligatorioMVC.Context;
using ObligatorioMVC.Models;
using ObligatorioMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ObligatorioMVC.Controllers.AutenticacionController;

namespace ObligatorioMVC.Controllers
{
    public class InscripcionController : Controller
    {
        private readonly InstitutoContext Contexto;

        public InscripcionController()
        {
            Contexto = new InstitutoContext();
        }

        [FuncionarioFilter]

        public ActionResult Alta()
        {
            var lista1 = listadoAlumnos();
            var lista2 = listadoCursosAsignatura();
            var v = new InscripcionViewModel();
            v.ListaAlumnos = lista1;
            v.ListaCursosAsignatura = lista2;
            return View(v);
        }

        private List<SelectListItem> listadoAlumnos()
        {
            var lista = new List<SelectListItem>();
            foreach (var a in new GestoraAlumnos(Contexto).ObtenerAlumnos())
            {
                lista.Add(new SelectListItem()
                {
                    Value = a.Cedula.ToString(),
                    Text = a.Nombre + " " + a.Apellido
                });

            }
            return lista;
        }

        private List<SelectListItem> listadoCursosAsignatura()
        {
            var lista = new List<SelectListItem>();
            foreach (var ca in new GestoraCursosAsignatura(Contexto).ObtenerCursosAsignaturas())
            {
                lista.Add(new SelectListItem()
                {
                    Value = ca.Numero.ToString(),
                    Text = "Curso Nº: " + ca.Numero + " - " + "Asignatura: " + ca.NombreAsignatura + " - " + "Docente: " + ca.DocumentoDocente,
                });

            }
            return lista;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alta(InscripcionViewModel ins)
        {
            if (!ModelState.IsValid)
            {
                ins.ListaAlumnos = listadoAlumnos();
                ins.ListaCursosAsignatura = listadoCursosAsignatura();
                return View(ins);
            }
            else
            {              

                var alumno = Contexto.Alumnos.Find(ins.DocumentoAlumno);
                var cursoasignatura = Contexto.CursosAsignaturas.Find(ins.CodigoCurAsig);
                bool existe = false;
                foreach (Inscripcion I in Contexto.Inscripciones)
                {
                    if (I.Alumno == alumno && I.CursoAsignatura == cursoasignatura)
                    {
                        existe = true;
                    }
                }
                if (alumno != null && cursoasignatura != null && cursoasignatura.Finalizado == Finalizado.No && existe == false)
                {                    
                    Inscripcion nuevaInscripcion = new Inscripcion()
                    {
                        Alumno = alumno,
                        CursoAsignatura = cursoasignatura,                     

                    };                    
                    GestoraInscripciones gi = new GestoraInscripciones(Contexto);
                    gi.AgregarInscripcion(nuevaInscripcion);
                    Contexto.SaveChanges();
                    ViewData["Mensaje"] = "Inscripción Agregada!";
                    return RedirectToAction("Alta");
                }                
                return RedirectToAction("Alta");
            }
        }

        public ActionResult Lista()
        {
            return View(new GestoraInscripciones(Contexto).ObtenerInscripciones());
        }
    }
}