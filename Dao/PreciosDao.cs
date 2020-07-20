using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class PreciosDao
    {
        AJDESIGNEntities context;
        public PreciosDao(AJDESIGNEntities contexto)
        {
            context = contexto;
        }

        public List<Disenios> TraerListaPrecio()
        {
            List<Disenios> listaP = context.Disenios.ToList();
            return listaP;
        }
    }
}
