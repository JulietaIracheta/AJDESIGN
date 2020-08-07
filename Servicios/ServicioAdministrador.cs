using Dao;
using Entidades;
using Entidades.Views;
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

        public Disenios actualizarPrecio(VMModificarDisenio vmPrecio)
        {
            Disenios diseñoPorId = BuscarDiseñoPorId(vmPrecio.IdDisenios);
            return administradorDao.ActualizarPrecio(diseñoPorId, vmPrecio);
        }

        public Disenios BuscarDiseñoPorId(int idDisenios)
        {
            Disenios d = administradorDao.BuscarPorId(idDisenios);
            return d;
        }

        public Disenios AgregarDisenio(VMAgregarDisenios vmD)
        {
            Disenios d = new Disenios()
            {
                Nombre = vmD.Nombre,
                Precio = vmD.Precio
            };
            return administradorDao.AgregarDisenio(d);
        }

        public Boolean ValidarDatos(VMLogin vmlogin)
        {
            List<Usuarios> usuario = administradorDao.TraerUnicoUsuario();

            foreach (var item in usuario)
            {
                if (item.Email == vmlogin.Email && item.Password == vmlogin.Password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } return false;
        }

        public Disenios Eliminar(int idDisenios)
        {
            return administradorDao.Eliminar(idDisenios);
        }
    }
}
