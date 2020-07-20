using Entidades;
using Entidades.Views;
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

        [HttpGet]
        public ActionResult AgregarDisenio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarDisenio(VMAgregarDisenios agregardisenio)
        {
            servicioAdministrador.AgregarDisenio(agregardisenio);
            return RedirectToAction("Precio", "Precios");
        }

        [HttpGet]
        public ActionResult ModificarDisenio(int idDisenios)
        {
            VMModificarDisenio vm = new VMModificarDisenio();
            vm.IdDisenios = idDisenios;
            return View(vm);
        }
       
        [HttpPost]
        public ActionResult ModificarDisenio(VMModificarDisenio p)
        {
            servicioAdministrador.actualizarPrecio(p);
            return RedirectToAction("Precio", "Precios"); 
        }


        [HttpGet]
        public ActionResult Eliminar(int idDisenios)
        {
            servicioAdministrador.Eliminar(idDisenios);
            return RedirectToAction("Precio", "Precios");
        }

    }
}