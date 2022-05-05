using NTec.Domain.Core.Interfaces.Repositories;
using NTec.Domain.Entities;

namespace NTec.Infrastructure.Data.Repositories
{
    public class CargoRepository : BaseRepository<Cargo>, ICargoRepository
    {
        private readonly SqlContext _sqlContext;

        public CargoRepository(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }
    }
}