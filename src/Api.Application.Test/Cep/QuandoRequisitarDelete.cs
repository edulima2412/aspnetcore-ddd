using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Cep
{
    public class QuandoRequisitarDelete
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possivel realizar o delete com sucesso")]
        public async Task E_Possivel_Invocar_Deleted_Sucesso()
        {
            var serviceMock = new Mock<ICepService>();

            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

            _controller = new CepsController(serviceMock.Object);

            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is OkObjectResult);
        }

        [Fact(DisplayName = "É possivel realizar o delete com falha")]
        public async Task E_Possivel_Invocar_Deleted_Error()
        {
            var serviceMock = new Mock<ICepService>();

            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);

            _controller = new CepsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato inválido");

            var result = await _controller.Delete(default(Guid));
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
