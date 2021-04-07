using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Cep
{
    public class CepDtoCreate
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public Guid MunicipioId { get; set; }
    }
}
