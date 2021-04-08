using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class UfImplementation : BaseRepository<UfEntity>, IUfRepository
    {
        private DbSet<UfEntity> _dataSet;
        public UfImplementation(MyContext context) : base(context)
        {
            _dataSet = context.Set<UfEntity>();
        }
    }
}
