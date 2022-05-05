using NTec.Domain.Core.Interfaces.Repositories;
using NTec.Domain.Entities;

namespace NTec.Infrastructure.Data.Repositories
{
    public class SetorRepository : BaseRepository<Setor>, ISetorRepository
    {
        private readonly SqlContext _sqlContext;

        public SetorRepository(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }
    }
}