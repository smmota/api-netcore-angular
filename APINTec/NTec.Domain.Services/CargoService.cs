using NTec.Domain.Core.Interfaces.Repositories;
using NTec.Domain.Core.Interfaces.Services;
using NTec.Domain.Entities;

namespace NTec.Domain.Services
{
    public class CargoService : BaseService<Cargo>, ICargoService
    {
        private readonly ICargoRepository _cargoRepository;

        public CargoService(ICargoRepository cargoRepository) : base(cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }
    }
}