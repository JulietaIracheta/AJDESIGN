using Dao;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioPrecios
    {
        PreciosDao DaoPrecio;
        public ServicioPrecios(AJDESIGNEntities context)
        {
            DaoPrecio = new PreciosDao(context);
        }

        public List<Disenios> TraerListaDePrecios()
        {
            List<Disenios> listaP = DaoPrecio.TraerListaPrecio();
            return listaP;
        }
    }
}
