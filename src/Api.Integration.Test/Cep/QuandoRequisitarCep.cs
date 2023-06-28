using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.Municipio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Test.Cep
{
    public class QuandoRequisitarCep : BaseIntegration
    {

        [Fact]
        public async Task E_Possivel_Realizar_CRUD_Municipios()
        {
            await AdicionarToken();

            var cepDto = new CepDtoCreate()
            {
                Cep = "5254124",
                Logradouro = "Rua x",
                Numero = "1",
                MunicipioId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
            };

            // Post
            var response = await PostJsonAsync(cepDto, $"{hostApi}/ceps", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var registroPost = JsonConvert.DeserializeObject<CepDtoCreateResult>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            // Put
            var updateCepDto = new CepDtoUpdate()
            {
                Id = registroPost.Id,
                Cep = "5254124",
                Logradouro = "Rua y",
                Numero = "2",
                MunicipioId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
            };

            //var stringContent = new StringContent(JsonConvert.SerializeObject(updateCepDto), Encoding.UTF8, "application/json");
            //response = await client.PutAsync($"{hostApi}/ceps", stringContent);
            //jsonResult = await response.Content.ReadAsStringAsync();
            //var registroAtualizado = JsonConvert.DeserializeObject<MunicipioDtoUpdateResult>(jsonResult);

            //Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            //Assert.NotEqual(1, registroAtualizado.CodIBGE);

            // Get ID
            //response = await client.GetAsync($"{hostApi}/municipios/{registroAtualizado.Id}");
            //Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //jsonResult = await response.Content.ReadAsStringAsync();
            //var registroSelecionado = JsonConvert.DeserializeObject<MunicipioDto>(jsonResult);
            //Assert.NotNull(registroSelecionado);

            // Get Complete/ID
            //response = await client.GetAsync($"{hostApi}/municipios/Complete/{registroAtualizado.Id}");
            //Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //jsonResult = await response.Content.ReadAsStringAsync();
            //var registroSelecionadoCompleto = JsonConvert.DeserializeObject<MunicipioDtoCompleto>(jsonResult);
            //Assert.NotNull(registroSelecionadoCompleto);
            //Assert.NotNull(registroSelecionadoCompleto.Uf);

            // Get Complete/IBGE
            //response = await client.GetAsync($"{hostApi}/municipios/byIBGE/{registroAtualizado.CodIBGE}");
            //Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //jsonResult = await response.Content.ReadAsStringAsync();
            //registroSelecionadoCompleto = JsonConvert.DeserializeObject<MunicipioDtoCompleto>(jsonResult);
            //Assert.NotNull(registroSelecionadoCompleto);
            //Assert.NotNull(registroSelecionadoCompleto.Uf);

            // Delete
            //response = await client.DeleteAsync($"{hostApi}/municipios/{registroAtualizado.Id}");
            //Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}