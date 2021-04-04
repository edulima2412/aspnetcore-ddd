using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoPost : UsuarioTestes
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possivel executar o metodo POST.")]
        public async Task E_Possivel_Executar_Post()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
            _service = _serviceMock.Object;

            var _result = await _service.Post(userDtoCreate);
            Assert.NotNull(_result);
            Assert.Equal(NomeUsuario, _result.Name);
            Assert.Equal(EmailUsuario, _result.Email);
        }
    }
}
