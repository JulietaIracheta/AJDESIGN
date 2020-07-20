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
        [StringLength(40, ErrorMessage = "Email demasiado largo")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage ="La password es obligatoria")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])[a-zA-Z0-9]{1,}$", ErrorMessage = "La contraseña debe contener al menos una letra mayúscula, una letra minúscula y un número")]
        [MinLength(8, ErrorMessage = "Su contraseña debe tener 8 digitos como minimo")]
        public string Password { get; set; }



    }
}
