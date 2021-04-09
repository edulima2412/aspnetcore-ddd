using Api.Domain.Dtos.Uf;
using Api.Domain.Entities;
using Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class UfMapper : BaseTesteService
    {
        [Fact(DisplayName = "É possivel mapear os modelos de UF")]
        public void E_Possivel_Mapear_Modelos_UF()
        {
            var model = new UfModel
            {
                Id = Guid.NewGuid(),
                Nome = Faker.Address.UsState(),
                Sigla = Faker.Address.UsState().Substring(1, 3),
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now
            };

            var listaEntity = new List<UfEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.UsState(),
                    Sigla = Faker.Address.UsState().Substring(1, 3),
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now
                };
                listaEntity.Add(item);
            }

            // Model => Entity
            var entity = Mapper.Map<UfEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Nome, model.Nome);
            Assert.Equal(entity.Sigla, model.Sigla);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            // Entity => Dto
            var ufDto = Mapper.Map<UfDto>(entity);
            Assert.Equal(ufDto.Id, entity.Id);
            Assert.Equal(ufDto.Nome, entity.Nome);
            Assert.Equal(ufDto.Sigla, entity.Sigla);

            var listaDto = Mapper.Map<List<UfDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());
            for (int i = 0; i < listaDto.Count(); i++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDto[i].Nome, listaEntity[i].Nome);
                Assert.Equal(listaDto[i].Sigla, listaEntity[i].Sigla);
            }

            // Dto => Model
            var ufModel = Mapper.Map<UfModel>(ufDto);
            Assert.Equal(ufModel.Id, ufDto.Id);
            Assert.Equal(ufModel.Nome, ufDto.Nome);
            Assert.Equal(ufModel.Sigla, ufDto.Sigla);
        }
    }
}
