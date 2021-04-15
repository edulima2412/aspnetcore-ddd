using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Cep;
using Api.Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Cep
{
    public class QuandoRequisitarGetByCep
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possivel realizar o get com sucesso")]
        public async Task E_Possivel_Invocar_Get_Sucesso()
        {
            var serviceMock = new Mock<ICepService>();

            serviceMock.Setup(m => m.Get(It.IsAny<string>())).ReturnsAsync(
                new CepDto
                {
                    Id = Guid.NewGuid(),
                    Logradouro = Faker.Address.StreetName(),
                    Cep = "111111",
                    Numero = "1",
                    MunicipioId = Guid.NewGuid()
                }
            );

            _controller = new CepsController(serviceMock.Object);

            var result = await _controller.Get("111111");
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as CepDto;
            Assert.NotNull(resultValue);
        }

        [Fact(DisplayName = "É possivel realizar o get com falha")]
        public async Task E_Possivel_Invocar_Get_Error()
        {
            var serviceMock = new Mock<ICepService>();

            serviceMock.Setup(m => m.Get(It.IsAny<string>())).ReturnsAsync(
                new CepDto
                {
                    Id = Guid.NewGuid(),
                    Logradouro = Faker.Address.StreetName(),
                    Cep = "111111",
                    Numero = "1",
                    MunicipioId = Guid.NewGuid()
                }
            );

            _controller = new CepsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato inválido");

            var result = await _controller.Get("111111");
            Assert.True(result is BadRequestObjectResult);
        }

        [Fact(DisplayName = "É possivel realizar o get not found")]
        public async Task E_Possivel_Invocar_Get_NotFound()
        {
            var serviceMock = new Mock<ICepService>();

            serviceMock.Setup(m => m.Get(It.IsAny<string>())).Returns(Task.FromResult((CepDto) null));

            _controller = new CepsController(serviceMock.Object);

            var result = await _controller.Get("111111");
            Assert.True(result is NotFoundResult);
        }
    }
}
