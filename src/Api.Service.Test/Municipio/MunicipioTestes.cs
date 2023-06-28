using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Uf;
using System;
using System.Collections.Generic;

namespace Api.Service.Test.Municipio
{
    public class MunicipioTestes
    {
        public static Guid Id { get; set; }
        public static string Nome { get; set; }
        public static string NomeAlterado { get; set; }
        public static int CodIBGE { get; set; }
        public static int CodIBGEAlterado { get; set; }
        public static Guid UfId { get; set; }

        public List<MunicipioDto> listaDto = new List<MunicipioDto>();
        public MunicipioDto municipioDto;
        public MunicipioDtoCompleto municipioDtoCompleto;
        public MunicipioDtoCreate municipioDtoCreate;
        public MunicipioDtoCreateResult municipioDtoCreateResult;
        public MunicipioDtoUpdate municipioDtoUpdate;
        public MunicipioDtoUpdateResult municipioDtoUpdateResult;

        public MunicipioTestes()
        {
            Id = Guid.NewGuid();
            Nome = Faker.Address.City();
            NomeAlterado = Faker.Address.City();
            CodIBGE = Faker.RandomNumber.Next(1, 10000);
            CodIBGEAlterado = Faker.RandomNumber.Next(1, 10000);
            UfId = Guid.NewGuid();

            for (int i = 0; i < 10; i++)
            {
                var dto = new MunicipioDto
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1, 10000),
                    UfId = Guid.NewGuid()
                };
                listaDto.Add(dto);
            }

            municipioDto = new MunicipioDto
            {
                Id = Id,
                Nome = Nome,
                CodIBGE = CodIBGE,
                UfId = UfId
            };

            municipioDtoCompleto = new MunicipioDtoCompleto
            {
                Id = Id,
                Nome = Nome,
                CodIBGE = CodIBGE,
                UfId = UfId,
                Uf = new UfDto
                {
                    Id = Guid.NewGuid(),
                    Sigla = Faker.Address.UsState().Substring(1, 3),
                    Nome = Faker.Address.UsState()
                }
            };

            municipioDtoCreate = new MunicipioDtoCreate
            {
                Nome = Nome,
                CodIBGE = CodIBGE,
                UfId = UfId
            };

            municipioDtoCreateResult = new MunicipioDtoCreateResult
            {
                Id = Id,
                Nome = Nome,
                CodIBGE = CodIBGE,
                UfId = UfId
            };

            municipioDtoUpdate = new MunicipioDtoUpdate
            {
                Id = Id,
                Nome = NomeAlterado,
                CodIBGE = CodIBGEAlterado,
                UfId = UfId
            };

            municipioDtoUpdateResult = new MunicipioDtoUpdateResult
            {
                Id = Id,
                Nome = NomeAlterado,
                CodIBGE = CodIBGEAlterado,
                UfId = UfId,
                UpdateAt = DateTime.Now
            };
        }
    }
}
