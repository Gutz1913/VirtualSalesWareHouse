using System.ComponentModel.DataAnnotations;

namespace VirtualSalesWareHouse.Models;

public class ResetPasswordViewModel
{
    [Display(Name = "Email")]
    [EmailAddress(ErrorMessage = "Debes ingresar un correo válido.")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string Username { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [StringLength(20, MinimumLength = 6, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres.")]
    public string Password { get; set; }

    [Compare("Password", ErrorMessage = "La nueva contraseña y la confirmación de contraseña son diferentes")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [StringLength(20, MinimumLength = 6, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
    public string ConfirmPassword { get; set; }

    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string Token { get; set; }
}
