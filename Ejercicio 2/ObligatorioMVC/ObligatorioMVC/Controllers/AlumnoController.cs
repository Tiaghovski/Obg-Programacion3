using ObligatorioMVC.Context;
using ObligatorioMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ObligatorioMVC.Controllers.AutenticacionController;

namespace ObligatorioMVC.Controllers
{
    public class AlumnoController : Controller
    {        
        public ActionResult CargaArchivo()
        {
            return View();
        }

        [HttpPost]
        public string SubidaArchivo()
        {
            var resultado = "";
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    StreamReader reader = new StreamReader(file.InputStream);
                    do
                    {
                        string textLine = reader.ReadLine();
                        resultado += textLine + "<br>";
                        String[] arr = textLine.Split(',');
                        Alumno nuevoAlumno = new Alumno()
                        {
                            Numero = Convert.ToInt32(arr[0]),
                            Cedula = arr[1],
                            Nombre = arr[2],
                            Apellido = arr[3],
                        };
                        InstitutoContext context = new InstitutoContext();
                        GestoraAlumnos ga = new GestoraAlumnos(context);
                        ga.AgregarAlumno(nuevoAlumno);
                        context.SaveChanges();                        
                    } while (reader.Peek() != -1);
                    reader.Close();
                    return resultado + "<h4>Alumnos Cargados!</h4>";
                }
            }
            return "No se pudo procesar nada";         

        }
    }
}