using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Municipio
{
    public class QuandoRequisitarUpdate
    {
        private MunicipiosController _controller;

        [Fact(DisplayName = "É possivel realizar o update com sucesso")]
        public async Task E_Possivel_Invocar_Updated_Sucesso()
        {
            var serviceMock = new Mock<IMunicipioService>();

            serviceMock.Setup(m => m.Put(It.IsAny<MunicipioDtoUpdate>())).ReturnsAsync(
                new MunicipioDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Nome = "São Paulo",
                    CodIBGE = 1,
                    UfId = Guid.NewGuid(),
                    UpdateAt = DateTime.Now
                }
            );

            _controller = new MunicipiosController(serviceMock.Object);

            var municipioDtoUpdate = new MunicipioDtoUpdate
            {
                Id = Guid.NewGuid(),
                Nome = "Fortaleza",
                CodIBGE = 2,
                UfId = Guid.NewGuid()
            };

            var result = await _controller.Put(municipioDtoUpdate);
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as MunicipioDtoUpdateResult;
            Assert.NotNull(resultValue);
        }

        [Fact(DisplayName = "É possivel realizar o update com falha")]
        public async Task E_Possivel_Invocar_Updated_Error()
        {
            var serviceMock = new Mock<IMunicipioService>();

            serviceMock.Setup(m => m.Put(It.IsAny<MunicipioDtoUpdate>())).ReturnsAsync(
                new MunicipioDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Nome = "São Paulo",
                    CodIBGE = 1,
                    UfId = Guid.NewGuid(),
                    UpdateAt = DateTime.Now
                }
            );

            _controller = new MunicipiosController(serviceMock.Object);
            _controller.ModelState.AddModelError("CodIBGE", "É um campo obrigatório");

            var municipioDtoUpdate = new MunicipioDtoUpdate
            {
                Id = Guid.NewGuid(),
                Nome = "Fortaleza",
                CodIBGE = 2
            };

            var result = await _controller.Put(municipioDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
