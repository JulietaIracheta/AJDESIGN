using Entidades;
using Entidades.Enum;
using Entidades.Views;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AJDesign.Controllers
{
    public class HomeController : Controller
    {
        ServicioHome servicioHome;
        public HomeController()
        {
            AJDESIGNEntities context = new AJDESIGNEntities();
            servicioHome = new ServicioHome(context);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}