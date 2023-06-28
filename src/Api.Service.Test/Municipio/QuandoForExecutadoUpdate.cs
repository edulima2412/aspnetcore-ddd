using Api.Domain.Interfaces.Services.Municipio;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutadoUpdate : MunicipioTestes
    {
        private IMunicipioService _service;
        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É possivel executar o metodo PUT.")]
        public async Task E_Possivel_Executar_Put()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.Post(municipioDtoCreate)).ReturnsAsync(municipioDtoCreateResult);
            _service = _serviceMock.Object;

            var _result = await _service.Post(municipioDtoCreate);
            Assert.NotNull(_result);
            Assert.Equal(Id, _result.Id);
            Assert.Equal(Nome, _result.Nome);
            Assert.Equal(CodIBGE, _result.CodIBGE);
            Assert.Equal(UfId, _result.UfId);

            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.Put(municipioDtoUpdate)).ReturnsAsync(municipioDtoUpdateResult);
            _service = _serviceMock.Object;

            var _resultUpdate = await _service.Put(municipioDtoUpdate);
            Assert.NotNull(_resultUpdate);
            Assert.Equal(Id, _resultUpdate.Id);
            Assert.Equal(NomeAlterado, _resultUpdate.Nome);
            Assert.Equal(CodIBGEAlterado, _resultUpdate.CodIBGE);
        }
    }
}
