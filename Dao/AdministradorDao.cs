using Entidades;
using Entidades.Views;
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

        public Disenios BuscarPorId(int IdDisenios)
        {
            Disenios d = context.Disenios.Find(IdDisenios);
            return d;
        }

        public Disenios ActualizarPrecio(Disenios diseñoPorId, VMModificarDisenio p)
        {
            Disenios d = BuscarPorId(diseñoPorId.IdDisenios);
            d.Precio = p.Precio;
            d.Nombre = p.Nombre;
            context.SaveChanges();
            return d;
        }

        public Disenios Eliminar(int idDisenios)
        {
            Disenios d = BuscarPorId(idDisenios);
            context.Disenios.Remove(d);
            context.SaveChanges();
            return d;
        }

        public Disenios AgregarDisenio(Disenios d)
        {
            Disenios di = context.Disenios.Add(d);            
            context.SaveChanges();
            return di;
        }
    }
}
