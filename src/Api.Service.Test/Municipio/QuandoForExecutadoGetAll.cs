using Api.Domain.Dtos.Municipio;
using Api.Domain.Interfaces.Services.Municipio;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutadoGetAll : MunicipioTestes
    {
        private IMunicipioService _service;
        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É possivel executar o metodo GET All.")]
        public async Task E_Possivel_Executar_GetAll()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listaDto);
            _service = _serviceMock.Object;

            var _result = await _service.GetAll();
            Assert.NotNull(_result);
            Assert.True(_result.Count() == 10);

            var _listaResult = new List<MunicipioDto>();
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listaResult.AsEnumerable);
            _service = _serviceMock.Object;

            var _resultEmpty = await _service.GetAll();
            Assert.Empty(_resultEmpty);
        }
    }
}
