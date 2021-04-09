using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Entities;
using Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class CepMapper : BaseTesteService
    {
        [Fact(DisplayName = "É possivel mapear os modelos de CEP")]
        public void E_Possivel_Mapear_Modelos_Cep()
        {
            var model = new CepModel
            {
                Id = Guid.NewGuid(),
                Cep = Faker.RandomNumber.Next(1, 10000).ToString(),
                Logradouro = Faker.Address.StreetName(),
                Numero = "",
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                MunicipioId = Guid.NewGuid()
            };

            var listaEntity = new List<CepEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new CepEntity
                {
                    Id = Guid.NewGuid(),
                    Cep = Faker.RandomNumber.Next(1, 10000).ToString(),
                    Logradouro = Faker.Address.StreetName(),
                    Numero = "",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    MunicipioId = Guid.NewGuid(),
                    Municipio = new MunicipioEntity
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Address.City(),
                        CodIBGE = Faker.RandomNumber.Next(1, 10000),
                        UfId = Guid.NewGuid(),
                        CreateAt = DateTime.Now,
                        UpdateAt = DateTime.Now,
                        Uf = new UfEntity
                        {
                            Id = Guid.NewGuid(),
                            Nome = Faker.Address.UsState(),
                            Sigla = Faker.Address.UsState().Substring(1, 3)
                        }
                    }
                };
                listaEntity.Add(item);
            }

            // Model => Entity
            var entity = Mapper.Map<CepEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Cep, model.Cep);
            Assert.Equal(entity.Numero, model.Numero);
            Assert.Equal(entity.Logradouro, model.Logradouro);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            // Entity => Dto
            var cepDto = Mapper.Map<CepDto>(entity);
            Assert.Equal(cepDto.Id, entity.Id);
            Assert.Equal(cepDto.Cep, entity.Cep);
            Assert.Equal(cepDto.Numero, entity.Numero);
            Assert.Equal(cepDto.Logradouro, entity.Logradouro);
            Assert.Equal(cepDto.MunicipioId, entity.MunicipioId);

            var cepDtoCompleto = Mapper.Map<CepDto>(listaEntity.FirstOrDefault());
            Assert.Equal(cepDtoCompleto.Id, listaEntity.FirstOrDefault().Id);
            Assert.Equal(cepDtoCompleto.Cep, listaEntity.FirstOrDefault().Cep);
            Assert.Equal(cepDtoCompleto.Numero, listaEntity.FirstOrDefault().Numero);
            Assert.Equal(cepDtoCompleto.Logradouro, listaEntity.FirstOrDefault().Logradouro);
            Assert.Equal(cepDtoCompleto.MunicipioId, listaEntity.FirstOrDefault().MunicipioId);
            Assert.NotNull(cepDtoCompleto.Municipio);
            Assert.NotNull(cepDtoCompleto.Municipio.Uf);

            var listaDto = Mapper.Map<List<CepDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());
            for (int i = 0; i < listaDto.Count(); i++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDto[i].Cep, listaEntity[i].Cep);
                Assert.Equal(listaDto[i].Numero, listaEntity[i].Numero);
                Assert.Equal(listaDto[i].Logradouro, listaEntity[i].Logradouro);
                Assert.Equal(listaDto[i].MunicipioId, listaEntity[i].MunicipioId);
            }

            var cepDtoCreateResult = Mapper.Map<CepDtoCreateResult>(entity);
            Assert.Equal(cepDtoCreateResult.Id, entity.Id);
            Assert.Equal(cepDtoCreateResult.Cep, entity.Cep);
            Assert.Equal(cepDtoCreateResult.Logradouro, entity.Logradouro);
            Assert.Equal(cepDtoCreateResult.Numero, entity.Numero);
            Assert.Equal(cepDtoCreateResult.CreateAt, entity.CreateAt);

            var cepDtoUpdateResult = Mapper.Map<CepDtoUpdateResult>(entity);
            Assert.Equal(cepDtoUpdateResult.Id, entity.Id);
            Assert.Equal(cepDtoUpdateResult.Cep, entity.Cep);
            Assert.Equal(cepDtoUpdateResult.Logradouro, entity.Logradouro);
            Assert.Equal(cepDtoUpdateResult.Numero, entity.Numero);
            Assert.Equal(cepDtoUpdateResult.UpdateAt, entity.UpdateAt);

            // Dto => Model
            //cepDto.Numero = "";
            var cepModel = Mapper.Map<CepModel>(cepDto);
            Assert.Equal(cepDtoUpdateResult.Id, cepDto.Id);
            Assert.Equal(cepDtoUpdateResult.Cep, cepDto.Cep);
            Assert.Equal(cepDtoUpdateResult.Logradouro, cepDto.Logradouro);
            Assert.Equal("S/N", cepDto.Numero);

            var cepDtoCreate = Mapper.Map<CepDtoCreate>(cepModel);
            Assert.Equal(cepDtoCreate.Cep, cepDto.Cep);
            Assert.Equal(cepDtoCreate.Logradouro, cepDto.Logradouro);
            Assert.Equal(cepDtoCreate.Numero, cepDto.Numero);

            var cepDtoUpdate = Mapper.Map<CepDtoUpdate>(cepModel);
            Assert.Equal(cepDtoUpdate.Id, cepDto.Id);
            Assert.Equal(cepDtoUpdate.Cep, cepDto.Cep);
            Assert.Equal(cepDtoUpdate.Logradouro, cepDto.Logradouro);
            Assert.Equal(cepDtoUpdate.Numero, cepDto.Numero);
            Assert.Equal(cepDtoUpdate.MunicipioId, cepDto.MunicipioId);
        }
    }
}
