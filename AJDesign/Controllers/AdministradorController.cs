using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AJDesign.Controllers
{
    public class AdministradorController : Controller
    {
        ServicioAdministrador servicioAdministrador;

        public AdministradorController()
        {
            AJDESIGNEntities context = new AJDESIGNEntities();
            servicioAdministrador = new ServicioAdministrador(context);
        }


        // GET: Administrador
        public ActionResult Index()
        {
            return View();
        }
    }
}