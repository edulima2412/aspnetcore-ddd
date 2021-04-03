using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email em formato inválido.")]
        [MaxLength(100, ErrorMessage = "Email deve ter no máximo 100 caracteres.")]
        public string Email { get; set; }
    }
}
