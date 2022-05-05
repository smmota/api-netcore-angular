using NTec.Application.Dtos;
using System.Collections.Generic;

namespace NTec.Application.Interfaces
{
    public interface ICargoApplicationService
    {
        void Add(CargoDto cargoDto);

        void Update(CargoDto cargoDto);

        void Remove(int id);

        IEnumerable<CargoDto> GetAll();

        CargoDto GetById(int id);
    }
}