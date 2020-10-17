using ObligatorioMVC.Context;
using ObligatorioMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ObligatorioMVC.Controllers.AutenticacionController;

namespace ObligatorioMVC.Controllers
{
    public class CarreraController : Controller
    {
        [FuncionarioFilter]
        public ActionResult Lista()
        {
            return View(new GestoraCarreras(new InstitutoContext()).ObtenerCarreras());
        }
    }
}