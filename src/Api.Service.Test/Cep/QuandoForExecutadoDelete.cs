using Api.Domain.Interfaces.Services.Cep;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class QuandoForExecutadoDelete : CepTestes
    {
        private ICepService _service;
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "É possivel executar o metodo DELETE.")]
        public async Task E_Possivel_Executar_Delete()
        {
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Delete(Id)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var _result = await _service.Delete(Id);
            Assert.True(_result);
        }
    }
}
