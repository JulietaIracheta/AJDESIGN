using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AJDesign.Controllers
{
    public class PreciosController : Controller
    {
        ServicioPrecios serviciosPrecios;

        public PreciosController()
        {
            AJDESIGNEntities context = new AJDESIGNEntities();
            serviciosPrecios = new ServicioPrecios(context);
        }

        [HttpGet]
        public ActionResult Precio()
        {
          List<Disenios> listaPrecio = serviciosPrecios.TraerListaDePrecios();
          return View("Precio",listaPrecio);
        }

    }
}