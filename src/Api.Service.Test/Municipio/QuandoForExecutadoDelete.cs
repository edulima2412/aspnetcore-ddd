using Api.Domain.Interfaces.Services.Municipio;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutadoDelete : MunicipioTestes
    {
        private IMunicipioService _service;
        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É possivel executar o metodo DELETE.")]
        public async Task E_Possivel_Executar_Delete()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.Delete(Id)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var _result = await _service.Delete(Id);
            Assert.True(_result);
        }
    }
}
