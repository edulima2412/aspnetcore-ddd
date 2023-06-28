using System;
using Api.CrossCutting.Mappings;
using AutoMapper;
using Xunit;

namespace Api.Service.Test
{
    public class BaseTesteService
    {
        public IMapper Mapper { get; set; }
        public BaseTesteService()
        {
            Mapper = new AutoMapperFixture().GetMapper();
        }

        public class AutoMapperFixture : IDisposable
        {
            public IMapper GetMapper()
            {
                var config = new MapperConfiguration(c =>
                {
                    c.AddProfile(new ModelToEntityProfile());
                    c.AddProfile(new EntityToDtoProfile());
                    c.AddProfile(new DtoToModelProfile());
                });

                return config.CreateMapper();
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
    }
}
