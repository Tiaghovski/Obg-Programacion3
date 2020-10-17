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
    public class ResultadoController : Controller
    {
        private readonly InstitutoContext Contexto;

        public ResultadoController()
        {
            Contexto = new InstitutoContext();
        }

        [DocenteFilter]

        public ActionResult Alta()
        {
            var lista1 = listadoAlumnos();
            var lista2 = listadoCursosAsignatura();
            var v = new ResultadoViewModel();
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
        public ActionResult Alta(ResultadoViewModel res)
        {
            if (!ModelState.IsValid)
            {
                res.ListaAlumnos = listadoAlumnos();
                res.ListaCursosAsignatura = listadoCursosAsignatura();
                return View(res);
            }
            else
            {

                var alumno = Contexto.Alumnos.Find(res.DocumentoAlumno);
                var cursoasignatura = Contexto.CursosAsignaturas.Find(res.CodigoCurAsig);
                if (alumno != null && cursoasignatura != null)
                {
                    Resultado nuevoResultado = new Resultado()
                    {
                        Nota = res.Nota,
                        Alumno = alumno,
                        CursoAsignatura = cursoasignatura,
                        ResultadoCurso = ResultadoFinal(res.Nota),
                };
                    GestoraResultados gr = new GestoraResultados(Contexto);
                    gr.AgregarResultado(nuevoResultado);
                    Contexto.SaveChanges();
                    ViewData["Mensaje"] = "Resultado Agregado!";
                    return RedirectToAction("Alta");
                }
                return RedirectToAction("Alta");
            }
        }

        public ActionResult Lista()
        {
            return View(new GestoraResultados(Contexto).ObtenerResultados());
        }


        private string ResultadoFinal(int nota)
        {
                string Resultado = ""; 
                if (nota>= 70 && nota < 86)
                {
                    Resultado = "Aprobada";
                }
                else
                 if (nota >= 86)
                {
                    Resultado = "Exonerada";
                }
                else if (nota < 70 && nota >= 0)
                {
                    Resultado = "A exámen";
                }
                return Resultado;
        }
       
    }
}


    


