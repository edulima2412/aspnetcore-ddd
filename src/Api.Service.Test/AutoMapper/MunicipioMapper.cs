using Api.Domain.Dtos.Municipio;
using Api.Domain.Entities;
using Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class MunicipioMapper : BaseTesteService
    {
        [Fact(DisplayName = "É possivel mapear os modelos de Municipio")]
        public void E_Possivel_Mapear_Modelos_Municipio()
        {
            var model = new MunicipioModel
            {
                Id = Guid.NewGuid(),
                Nome = Faker.Address.City(),
                CodIBGE = Faker.RandomNumber.Next(1, 10000),
                UfId = Guid.NewGuid(),
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };

            var listaEntity = new List<MunicipioEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new MunicipioEntity
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
                };
                listaEntity.Add(item);
            }

            // Model => Entity
            var entity = Mapper.Map<MunicipioEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Nome, model.Nome);
            Assert.Equal(entity.CodIBGE, model.CodIBGE);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            // Entity => Dto
            var municipioDto = Mapper.Map<MunicipioDto>(entity);
            Assert.Equal(municipioDto.Id, entity.Id);
            Assert.Equal(municipioDto.Nome, entity.Nome);
            Assert.Equal(municipioDto.CodIBGE, entity.CodIBGE);
            Assert.Equal(municipioDto.UfId, entity.UfId);

            var municipioDtoCompleto = Mapper.Map<MunicipioDtoCompleto>(listaEntity.FirstOrDefault());
            Assert.Equal(municipioDtoCompleto.Id, listaEntity.FirstOrDefault().Id);
            Assert.Equal(municipioDtoCompleto.Nome, listaEntity.FirstOrDefault().Nome);
            Assert.Equal(municipioDtoCompleto.CodIBGE, listaEntity.FirstOrDefault().CodIBGE);
            Assert.Equal(municipioDtoCompleto.UfId, listaEntity.FirstOrDefault().UfId);
            Assert.NotNull(municipioDtoCompleto.Uf);

            var listaDto = Mapper.Map<List<MunicipioDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());
            for (int i = 0; i < listaDto.Count(); i++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDto[i].Nome, listaEntity[i].Nome);
                Assert.Equal(listaDto[i].CodIBGE, listaEntity[i].CodIBGE);
            }

            var municipioDtoCreateResult = Mapper.Map<MunicipioDtoCreateResult>(entity);
            Assert.Equal(municipioDtoCreateResult.Id, entity.Id);
            Assert.Equal(municipioDtoCreateResult.Nome, entity.Nome);
            Assert.Equal(municipioDtoCreateResult.CodIBGE, entity.CodIBGE);
            Assert.Equal(municipioDtoCreateResult.UfId, entity.UfId);
            Assert.Equal(municipioDtoCreateResult.CreateAt, entity.CreateAt);

            var municipioDtoUpdateResult = Mapper.Map<MunicipioDtoUpdateResult>(entity);
            Assert.Equal(municipioDtoUpdateResult.Id, entity.Id);
            Assert.Equal(municipioDtoUpdateResult.Nome, entity.Nome);
            Assert.Equal(municipioDtoUpdateResult.CodIBGE, entity.CodIBGE);
            Assert.Equal(municipioDtoUpdateResult.UfId, entity.UfId);
            Assert.Equal(municipioDtoUpdateResult.UpdateAt, entity.UpdateAt);

            // Dto => Model
            var municipioModel = Mapper.Map<MunicipioModel>(municipioDto);
            Assert.Equal(municipioModel.Id, municipioDto.Id);
            Assert.Equal(municipioModel.Nome, municipioDto.Nome);
            Assert.Equal(municipioModel.CodIBGE, municipioDto.CodIBGE);
            Assert.Equal(municipioModel.UfId, municipioDto.UfId);

            var municipioDtoCreate = Mapper.Map<MunicipioDtoCreate>(municipioModel);
            Assert.Equal(municipioDtoCreate.Nome, municipioDto.Nome);
            Assert.Equal(municipioDtoCreate.CodIBGE, municipioDto.CodIBGE);
            Assert.Equal(municipioDtoCreate.UfId, municipioDto.UfId);

            var municipioDtoUpdate = Mapper.Map<MunicipioDtoUpdate>(municipioModel);
            Assert.Equal(municipioDtoUpdate.Id, municipioDto.Id);
            Assert.Equal(municipioDtoUpdate.Nome, municipioDto.Nome);
            Assert.Equal(municipioDtoUpdate.CodIBGE, municipioDto.CodIBGE);
            Assert.Equal(municipioDtoUpdate.UfId, municipioDto.UfId);
        }
    }
}
