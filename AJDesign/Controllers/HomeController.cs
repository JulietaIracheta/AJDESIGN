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

        [HttpGet]
        public ActionResult Registro()
        {
            VMRegistro vmregistro = new VMRegistro();
            return View(vmregistro);
        }

        [HttpPost]
        public ActionResult Registro(VMRegistro vMRegistro)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(vMRegistro);
                }
                else
                {
                    Usuarios user = servicioHome.Registrarse(vMRegistro);
                }
                TempData["Mensaje"] = "Login";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error: ", ex.Message);
            }
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            VMLogin vmLogin = new VMLogin();
            return View(vmLogin);
        }

        [HttpPost]
        public ActionResult Login(VMLogin vmLogin)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(vmLogin);
                }
                Usuarios usuarios = new Usuarios();
                usuarios = servicioHome.Login(vmLogin);

                string userExistente = servicioHome.ValidoSiExisteUsuario(usuarios);
                if (userExistente == null)
                {
                    ViewData.Add("mensajeError", "No existe el email ingresado, debe registrarse");
                    return View();
                }
                else if (userExistente == "incorrecto")
                {
                    ViewData.Add("mensajeErrorC", "La contraseña es incorrecta");
                }
                else if (userExistente == "ok")
                {
                    TipoEmail estadoEmail = servicioHome.ValidoEstadoEmail(usuarios);
                    if (estadoEmail != TipoEmail.EmailActivo)
                    {
                        ViewData.Add("mensajeAdvertencia", "Su usuario está inactivo. Actívelo desde el email recibido");
                        return View();
                    }
                    //seteo de session
                    servicioHome.SetearSession(usuarios);
                    //Lo lleva a la vista a donde queria ir
                    return RedirectToAction("AsignarRuta", usuarios);
                }
                //Mensaje de bienvenida que se muestra en la vista Index.
                TempData["Mensaje"] = "Bienvenidx";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error: ", ex.Message);
            }
            return View("Index");
        }

        public ActionResult AsignarRuta(Usuarios u)
        {

            //Validar si es un Usuario o un Administrador
            TipoUsuario tipoUsuario = servicioHome.tipoDeUsuario(u);
            if (tipoUsuario == TipoUsuario.Usuario)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Session["Admin"] = u.IdUsuario;
                return RedirectToAction("Administrador");
            }
        }
    }
}