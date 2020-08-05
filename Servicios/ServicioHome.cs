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
