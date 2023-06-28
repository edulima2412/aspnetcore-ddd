using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.User
{
    public class UserDtoUpdate
    {
        [Required(ErrorMessage = "Id é obrigatório.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [MaxLength(60, ErrorMessage = "Nome deve ter no máximo 60 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email no formato inválido.")]
        [MaxLength(100, ErrorMessage = "Email deve ter no máximo 100 caracteres.")]
        public string Email { get; set; }
    }
}
