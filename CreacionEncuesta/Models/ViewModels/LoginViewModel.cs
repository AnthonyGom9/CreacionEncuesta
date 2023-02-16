using System.ComponentModel.DataAnnotations;

namespace CreacionEncuesta.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
    }
}
