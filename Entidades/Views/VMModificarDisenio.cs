using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Views
{
    public class VMModificarDisenio
    {
        public int Precio { get; set; }

        public string Nombre { get; set; }

        public int IdDisenios { get; set; }
    }
}
