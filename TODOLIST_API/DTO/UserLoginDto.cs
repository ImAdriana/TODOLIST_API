using System.ComponentModel.DataAnnotations;

namespace TODOLIST_API.DTO
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "El campo {PropertyName} es requerido")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "El campo {PropertyName} es requerido")]
        public string? Password { get; set; }
    }
}
