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
    public class QuandoRequisitarCreate
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possivel realizar o created com sucesso")]
        public async Task E_Possivel_Invocar_Created_Sucesso()
        {
            var serviceMock = new Mock<ICepService>();

            serviceMock.Setup(m => m.Post(It.IsAny<CepDtoCreate>())).ReturnsAsync(
                new CepDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Logradouro = Faker.Address.StreetName(),
                    Cep = "111111",
                    Numero = "1",
                    CreateAt = DateTime.Now,
                    MunicipioId = Guid.NewGuid()
                }
            );

            _controller = new CepsController(serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var cepDtoCreate = new CepDtoCreate
            {
                Logradouro = Faker.Address.StreetName(),
                Cep = "111111",
                Numero = "1"
            };

            var result = await _controller.Post(cepDtoCreate);
            Assert.True(result is CreatedResult);

            var resultValue = ((CreatedResult)result).Value as CepDtoCreateResult;
            Assert.NotNull(resultValue);
        }

        [Fact(DisplayName = "É possivel realizar o created com falha")]
        public async Task E_Possivel_Invocar_Created_Error()
        {
            var serviceMock = new Mock<ICepService>();

            serviceMock.Setup(m => m.Post(It.IsAny<CepDtoCreate>())).ReturnsAsync(
                new CepDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Logradouro = Faker.Address.StreetName(),
                    Cep = "111111",
                    Numero = "1",
                    CreateAt = DateTime.Now,
                    MunicipioId = Guid.NewGuid()
                }
            );

            _controller = new CepsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Logradouro", "É um campo obrigatório");

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var cepDtoCreate = new CepDtoCreate
            {
                Logradouro = Faker.Address.StreetName(),
                Cep = "111111",
                Numero = "1"
            };

            var result = await _controller.Post(cepDtoCreate);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
