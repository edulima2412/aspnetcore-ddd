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
    public class QuandoRequisitarUpdate
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possivel realizar o update com sucesso")]
        public async Task E_Possivel_Invocar_Updated_Sucesso()
        {
            var serviceMock = new Mock<ICepService>();

            serviceMock.Setup(m => m.Put(It.IsAny<CepDtoUpdate>())).ReturnsAsync(
                new CepDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Logradouro = Faker.Address.StreetName(),
                    Cep = "111111",
                    Numero = "1",
                    UpdateAt = DateTime.Now,
                    MunicipioId = Guid.NewGuid()
                }
            );

            _controller = new CepsController(serviceMock.Object);

            var cepDtoUpdate = new CepDtoUpdate
            {
                Id = Guid.NewGuid(),
                Logradouro = Faker.Address.StreetName(),
                Cep = "111111",
                Numero = "1",
                MunicipioId = Guid.NewGuid()
            };

            var result = await _controller.Put(cepDtoUpdate);
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as CepDtoUpdateResult;
            Assert.NotNull(resultValue);
        }

        [Fact(DisplayName = "É possivel realizar o update com falha")]
        public async Task E_Possivel_Invocar_Updated_Error()
        {
            var serviceMock = new Mock<ICepService>();

            serviceMock.Setup(m => m.Put(It.IsAny<CepDtoUpdate>())).ReturnsAsync(
                new CepDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Logradouro = Faker.Address.StreetName(),
                    Cep = "111111",
                    Numero = "1",
                    UpdateAt = DateTime.Now,
                    MunicipioId = Guid.NewGuid()
                }
            );

            _controller = new CepsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Logradouro", "É um campo obrigatório");

            var cepDtoUpdate = new CepDtoUpdate
            {
                Id = Guid.NewGuid(),
                Logradouro = Faker.Address.StreetName(),
                Cep = "111111",
                Numero = "1",
                MunicipioId = Guid.NewGuid()
            };

            var result = await _controller.Put(cepDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
