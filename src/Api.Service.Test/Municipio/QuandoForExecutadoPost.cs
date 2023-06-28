﻿using Api.Domain.Interfaces.Services.Municipio;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutadoPost : MunicipioTestes
    {
        private IMunicipioService _service;
        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É possivel executar o metodo POST.")]
        public async Task E_Possivel_Executar_Post()
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
        }
    }
}
