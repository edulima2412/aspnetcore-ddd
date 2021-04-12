using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Uf;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Service.Test.Cep
{
    public class CepTestes
    {
        public static Guid Id { get; set; }
        public static string Cep { get; set; }
        public static string CepAlterado { get; set; }
        public static string Logradouro { get; set; }
        public static string LogradouroAlterado { get; set; }
        public static string Numero { get; set; }
        public static string NumeroAlterado { get; set; }
        public static Guid MunicipioId { get; set; }

        public List<CepDto> listaDto = new List<CepDto>();
        public CepDto cepDto;
        public CepDtoCreate cepDtoCreate;
        public CepDtoCreateResult cepDtoCreateResult;
        public CepDtoUpdate cepDtoUpdate;
        public CepDtoUpdateResult cepDtoUpdateResult;

        public CepTestes()
        {
            Id = Guid.NewGuid();
            Cep = Faker.RandomNumber.Next(10000, 99999).ToString();
            CepAlterado = Faker.RandomNumber.Next(10000, 99999).ToString();
            Logradouro = Faker.Address.StreetName();
            LogradouroAlterado = Faker.Address.StreetName();
            Numero = Faker.RandomNumber.Next(1, 1000).ToString();
            NumeroAlterado = Faker.RandomNumber.Next(1, 1000).ToString();
            MunicipioId = Guid.NewGuid();

            for (int i = 0; i < 10; i++)
            {
                var dto = new CepDto()
                {
                    Id = Guid.NewGuid(),
                    Cep = Faker.RandomNumber.Next(10000, 99999).ToString(),
                    Logradouro = Faker.Address.StreetName(),
                    Numero = Faker.RandomNumber.Next(1, 1000).ToString(),
                    MunicipioId = Guid.NewGuid(),
                    Municipio = new MunicipioDtoCompleto
                    {
                        Id = MunicipioId,
                        Nome = Faker.Address.City(),
                        CodIBGE = Faker.RandomNumber.Next(1, 10000),
                        UfId = Guid.NewGuid(),
                        Uf = new UfDto
                        {
                            Id = Guid.NewGuid(),
                            Sigla = Faker.Address.UsState().Substring(1, 3),
                            Nome = Faker.Address.UsState()
                        }
                    }
                };
                listaDto.Add(dto);
            }

            cepDto = new CepDto
            {
                Id = Id,
                Cep = Cep,
                Logradouro = Logradouro,
                Numero = Numero,
                MunicipioId = MunicipioId,
                Municipio = new MunicipioDtoCompleto
                {
                    Id = MunicipioId,
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1, 10000),
                    UfId = Guid.NewGuid(),
                    Uf = new UfDto
                    {
                        Id = Guid.NewGuid(),
                        Sigla = Faker.Address.UsState().Substring(1, 3),
                        Nome = Faker.Address.UsState()
                    }
                }
            };

            cepDtoCreate = new CepDtoCreate
            {
                Cep = Cep,
                Logradouro = Logradouro,
                Numero = Numero,
                MunicipioId = MunicipioId
            };

            cepDtoCreateResult = new CepDtoCreateResult
            {
                Id = Id,
                Cep = Cep,
                Logradouro = Logradouro,
                Numero = Numero,
                MunicipioId = MunicipioId,
                CreateAt = DateTime.Now
            };

            cepDtoUpdate = new CepDtoUpdate
            {
                Id = Id,
                Cep = CepAlterado,
                Logradouro = LogradouroAlterado,
                Numero = NumeroAlterado,
                MunicipioId = MunicipioId
            };

            cepDtoUpdateResult = new CepDtoUpdateResult
            {
                Id = Id,
                Cep = CepAlterado,
                Logradouro = LogradouroAlterado,
                Numero = NumeroAlterado,
                MunicipioId = MunicipioId,
                UpdateAt = DateTime.Now
            };
        }
    }
}
