using Api.Domain.Dtos.Cep;
using Api.Domain.Interfaces.Services.Cep;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class QuandoForExecutadoGet : CepTestes
    {
        private ICepService _service;
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "É possivel executar o metodo GET.")]
        public async Task E_Possivel_Executar_Get()
        {
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Get(Id)).ReturnsAsync(cepDto);
            _service = _serviceMock.Object;

            var _result = await _service.Get(Id);
            Assert.NotNull(_result);
            Assert.Equal(Id, _result.Id);
            Assert.Equal(Logradouro, _result.Logradouro);
            Assert.Equal(Numero, _result.Numero);
            Assert.Equal(Cep, _result.Cep);

            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Get(Cep)).ReturnsAsync(cepDto);
            _service = _serviceMock.Object;

            _result = await _service.Get(Cep);
            Assert.NotNull(_result);
            Assert.Equal(Id, _result.Id);
            Assert.Equal(Logradouro, _result.Logradouro);
            Assert.Equal(Numero, _result.Numero);
            Assert.Equal(Cep, _result.Cep);

            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((CepDto)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(Guid.NewGuid());
            Assert.Null(_record);
        }
    }
}
