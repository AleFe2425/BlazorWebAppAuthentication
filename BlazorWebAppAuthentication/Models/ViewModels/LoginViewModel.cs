using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppAuthentication.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Escribe un nombre de usuario por favor")]
        public string? Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Escriba una contraseña por favor")]
        public string? Password { get; set; }
    }
}
