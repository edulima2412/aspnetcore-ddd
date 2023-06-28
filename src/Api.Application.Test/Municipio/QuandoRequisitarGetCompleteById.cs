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
    public class QuandoRequisitarGetCompleteById
    {
        private MunicipiosController _controller;

        [Fact(DisplayName = "É possivel realizar o getById completo com sucesso")]
        public async Task E_Possivel_Invocar_GetById_Sucesso()
        {
            var serviceMock = new Mock<IMunicipioService>();

            serviceMock.Setup(m => m.GetCompletoById(It.IsAny<Guid>())).ReturnsAsync(
                new MunicipioDtoCompleto
                {
                    Id = Guid.NewGuid(),
                    Nome = "São Paulo",
                    CodIBGE = 1,
                    UfId = Guid.NewGuid()
                }
            );

            _controller = new MunicipiosController(serviceMock.Object);

            var result = await _controller.GetCompletoById(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as MunicipioDtoCompleto;
            Assert.NotNull(resultValue);
        }

        [Fact(DisplayName = "É possivel realizar o getById completo com falha")]
        public async Task E_Possivel_Invocar_GetById_Error()
        {
            var serviceMock = new Mock<IMunicipioService>();

            serviceMock.Setup(m => m.GetCompletoById(It.IsAny<Guid>())).ReturnsAsync(
                new MunicipioDtoCompleto
                {
                    Id = Guid.NewGuid(),
                    Nome = "São Paulo",
                    CodIBGE = 1,
                    UfId = Guid.NewGuid()
                }
            );

            _controller = new MunicipiosController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato inválido");

            var result = await _controller.GetCompletoById(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }

        [Fact(DisplayName = "É possivel realizar o getById completo not found")]
        public async Task E_Possivel_Invocar_GetById_NotFound()
        {
            var serviceMock = new Mock<IMunicipioService>();

            serviceMock.Setup(m => m.GetCompletoById(It.IsAny<Guid>())).Returns(Task.FromResult((MunicipioDtoCompleto) null));

            _controller = new MunicipiosController(serviceMock.Object);

            var result = await _controller.GetCompletoById(Guid.NewGuid());
            Assert.True(result is NotFoundResult);
        }
    }
}
