using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class AdministradorDao
    {

        AJDESIGNEntities context;
        public AdministradorDao(AJDESIGNEntities contexto)
        {
            context = contexto;
        }
    }
}
