using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Cep
{
    public class CepDtoUpdate
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public Guid MunicipioId { get; set; }
    }
}
