using Entidades;
using Entidades.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class HomeDao
    {
        AJDESIGNEntities context;
        public HomeDao(AJDESIGNEntities contexto)
        {
            context = contexto;
        }

        public Usuarios AltaUsuario(Usuarios v)
        {
            Usuarios u = context.Usuarios.Add(v);
            context.SaveChanges();
            return u;
        }

        public Usuarios obtenerUsuarioPorEmail(string email)
        {
            Usuarios usuario = context.Usuarios.Where(o => o.Email == email).FirstOrDefault();
            return usuario;
        }
    }
}
