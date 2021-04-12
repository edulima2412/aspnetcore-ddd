using Api.Domain.Dtos.Municipio;
using Api.Domain.Interfaces.Services.Municipio;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutadoGet : MunicipioTestes
    {
        private IMunicipioService _service;
        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É possivel executar o metodo GET.")]
        public async Task E_Possivel_Executar_Get()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.Get(Id)).ReturnsAsync(municipioDto);
            _service = _serviceMock.Object;

            var _result = await _service.Get(Id);
            Assert.NotNull(_result);
            Assert.Equal(Id, _result.Id);
            Assert.Equal(Nome, _result.Nome);
            Assert.Equal(CodIBGE, _result.CodIBGE);
            Assert.Equal(UfId, _result.UfId);

            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((MunicipioDto)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(Guid.NewGuid());
            Assert.Null(_record);
        }
    }
}
