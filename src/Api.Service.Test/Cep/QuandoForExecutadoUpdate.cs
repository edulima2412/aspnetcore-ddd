using Api.Domain.Interfaces.Services.Cep;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class QuandoForExecutadoUpdate : CepTestes
    {
        private ICepService _service;
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "É possivel executar o metodo PUT.")]
        public async Task E_Possivel_Executar_Put()
        {
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Post(cepDtoCreate)).ReturnsAsync(cepDtoCreateResult);
            _service = _serviceMock.Object;

            var _result = await _service.Post(cepDtoCreate);
            Assert.NotNull(_result);
            Assert.Equal(Id, _result.Id);
            Assert.Equal(Logradouro, _result.Logradouro);
            Assert.Equal(Cep, _result.Cep);
            Assert.Equal(Numero, _result.Numero);
            Assert.Equal(MunicipioId, _result.MunicipioId);

            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Put(cepDtoUpdate)).ReturnsAsync(cepDtoUpdateResult);
            _service = _serviceMock.Object;

            var _resultUpdate = await _service.Put(cepDtoUpdate);
            Assert.NotNull(_resultUpdate);
            Assert.Equal(Id, _resultUpdate.Id);
            Assert.Equal(LogradouroAlterado, _resultUpdate.Logradouro);
            Assert.Equal(NumeroAlterado, _resultUpdate.Numero);
            Assert.Equal(CepAlterado, _resultUpdate.Cep);
        }
    }
}
