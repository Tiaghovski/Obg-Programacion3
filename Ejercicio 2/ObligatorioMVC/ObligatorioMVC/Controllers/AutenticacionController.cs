using ObligatorioMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ObligatorioMVC.Controllers
{
    public class AutenticacionController : Controller
    {
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(Usuario u)
        {
            var rol = GestoraUsuarios.ValidarCredencialesUsuario(u);
            if (rol != RolUsuario.Anonimo)
            {
                //Agrega una cookie de autenticación por lo que genera el token a partir del nombre de usuario.
                 //Se le pasa falso para que la cookie no sea persistente
                FormsAuthentication.SetAuthCookie(u.NombreUsuario, false);
                Session["Rol"] = rol;
                return RedirectToAction("Index", "Inicio");
            }
            else
            {
                ModelState.AddModelError("", "Usuario y/o clave incorrectos");
                return View();
            }
        }


        public class DocenteFilter : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if(filterContext.HttpContext.Session["rol"]==null || !Enum.Parse(typeof(RolUsuario), filterContext.HttpContext.Session["rol"].ToString()).Equals(RolUsuario.Docente))
                {
                    filterContext.Result = new ContentResult()
                    {
                        Content = "Los usuarios tipo Funcionario no tienen permiso para utilizar ésta función"
                    };
                }
                base.OnActionExecuting(filterContext);
            }
        }

        public class FuncionarioFilter : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (filterContext.HttpContext.Session["rol"] == null || !Enum.Parse(typeof(RolUsuario), filterContext.HttpContext.Session["rol"].ToString()).Equals(RolUsuario.Funcionario))
                {
                    filterContext.Result = new ContentResult()
                    {
                        Content = "Los usuarios tipo Docente no tienen permiso para utilizar ésta función"
                    };
                }
                base.OnActionExecuting(filterContext);
            }
        }      

    }
}