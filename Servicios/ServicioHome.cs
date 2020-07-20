using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Entidades.Views;
using Entidades.Enum;
using System.Web;

namespace Servicios
{
    public class ServicioHome
    {
        HomeDao DaoHome;
        public ServicioHome(AJDESIGNEntities context)
        {
            DaoHome = new HomeDao(context);
        }

        public Usuarios Registrarse(VMRegistro vMRegistro)
        {
            Usuarios u = new Usuarios()
            {
                Activo = false,
                Apellido = vMRegistro.Apellido,
                Email = vMRegistro.Email,
                Nombre = vMRegistro.Nombre,
                Password = EncriptarPassword.GetSHA256(vMRegistro.Password), //De esta forma con la funcion se encripta la password.
                FechaCreacion = DateTime.Now,
                TipoUsuario = 1
            };
            return DaoHome.AltaUsuario(u);
        }

        public Usuarios Login(VMLogin vmLogin)
        {
            Usuarios usuario = new Usuarios();
            usuario.Email = vmLogin.Email;
            usuario.Password = vmLogin.Password;
            return usuario;
        }

        public string ValidoSiExisteUsuario(Usuarios usuarios)
        {
            Usuarios usuarioObtenido = DaoHome.obtenerUsuarioPorEmail(usuarios.Email);
            if (usuarioObtenido == null)
            {
                return null;
            }
            String passwordEncriptada = EncriptarPassword.GetSHA256(usuarios.Password);
            if (usuarioObtenido.Password == passwordEncriptada)
            {
                return "ok";
            }

            return "incorrecto";
        }

        public TipoEmail ValidoEstadoEmail(Usuarios usuario)
        {
            Usuarios usuarioObtenido = DaoHome.obtenerUsuarioPorEmail(usuario.Email);

            //Si no se encontro usuario, el email es nuevo
            if (usuarioObtenido == null)
            {
                return TipoEmail.EmailNuevo;
            }
            else if (!usuarioObtenido.Activo) //Si el email aun no fue activo, entonces ya fue solicitado
            {
                return TipoEmail.EmailSolicitado;
            }
            else //Y sino, el email ya esta anotado
            {
                return TipoEmail.EmailActivo;
            }
        }

        public void SetearSession(Usuarios usuario)
        {
            TipoUsuario tipoUsuario = tipoDeUsuario(usuario);
            if (tipoUsuario == TipoUsuario.Administrador)
            {
                HttpContext.Current.Session["Admin"] = usuario.IdUsuario;
            }
            Usuarios user = obtenerUsuarioPorEmail(usuario.Email);
            HttpContext.Current.Session["UserId"] = user.IdUsuario;

        }

        public TipoUsuario tipoDeUsuario(Usuarios usuarioObtenido)
        {
            //Obtengo datos del usuario
            Usuarios usuarioRegistrado = obtenerUsuarioPorEmail(usuarioObtenido.Email);

            if (usuarioRegistrado.TipoUsuario == 1)
            {
                return TipoUsuario.Usuario;
            }
            else
            {
                return TipoUsuario.Administrador;
            }
        }

        public Usuarios obtenerUsuarioPorEmail(string email)
        {
            Usuarios usuarioObtenido = DaoHome.obtenerUsuarioPorEmail(email);
            return usuarioObtenido;
        }
    }
}
