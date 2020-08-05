using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Views
{
    public class VMAgregarDisenios
    {
        [Required(ErrorMessage = "Debe ingresar el nombre del diseño")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar el valor")]
        public int Precio { get; set; }
    }
}
