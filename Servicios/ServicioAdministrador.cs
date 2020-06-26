using Dao;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioAdministrador
    {

        AdministradorDao administradorDao;
        public ServicioAdministrador(AJDESIGNEntities context)
        {
            administradorDao = new AdministradorDao(context);
        }

    }
}
