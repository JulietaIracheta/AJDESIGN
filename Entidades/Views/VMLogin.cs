using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Views
{
    public class VMLogin
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de Email incorrecto")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage ="La password es obligatoria")]
        public string Password { get; set; }
    }
}
