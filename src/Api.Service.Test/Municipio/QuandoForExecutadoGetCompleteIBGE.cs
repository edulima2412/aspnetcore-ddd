using Api.Domain.Dtos.Municipio;
using Api.Domain.Interfaces.Services.Municipio;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutadoGetCompleteIBGE : MunicipioTestes
    {
        private IMunicipioService _service;
        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É possivel executar o metodo GET Complete IBGE.")]
        public async Task E_Possivel_Executar_Get_Complete_IBGE()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.GetCompletoByIBGE(CodIBGE)).ReturnsAsync(municipioDtoCompleto);
            _service = _serviceMock.Object;

            var _result = await _service.GetCompletoByIBGE(CodIBGE);
            Assert.NotNull(_result);
            Assert.Equal(Id, _result.Id);
            Assert.Equal(Nome, _result.Nome);
            Assert.Equal(CodIBGE, _result.CodIBGE);
            Assert.NotNull(_result.Uf);
        }
    }
}
