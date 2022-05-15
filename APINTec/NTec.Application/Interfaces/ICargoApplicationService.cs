using NTec.Application.Dtos;
using System.Collections.Generic;

namespace NTec.Application.Interfaces
{
    public interface ICargoApplicationService
    {
        bool Add(CargoDto cargoDto);

        bool Update(CargoDto cargoDto);

        bool Remove(int id);

        IEnumerable<CargoDto> GetAll();

        CargoDto GetById(int id);

        IEnumerable<CargoDto> GetAllAtivos();
    }
}