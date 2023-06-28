using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Municipio
{
    public class MunicipioDtoCreate
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(60, ErrorMessage = "Nome do municipio deve ter no máximo 60 caracteres")]
        public string Nome { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Codigo do IBGE inválido")]
        public int CodIBGE { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public Guid UfId { get; set; }
    }
}
