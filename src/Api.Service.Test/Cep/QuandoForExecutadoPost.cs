using Api.Domain.Interfaces.Services.Cep;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class QuandoForExecutadoPost : CepTestes
    {
        private ICepService _service;
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "É possivel executar o metodo POST.")]
        public async Task E_Possivel_Executar_Post()
        {
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Post(cepDtoCreate)).ReturnsAsync(cepDtoCreateResult);
            _service = _serviceMock.Object;

            var _result = await _service.Post(cepDtoCreate);
            Assert.NotNull(_result);
            Assert.Equal(Id, _result.Id);
            Assert.Equal(Cep, _result.Cep);
            Assert.Equal(Logradouro, _result.Logradouro);
            Assert.Equal(Numero, _result.Numero);
        }
    }
}
