using NTec.Application.Dtos;
using NTec.Domain.Entities;
using System.Collections.Generic;

namespace NTec.Application.Mappers.Interfaces
{
    public interface ICargoMapper
    {
        Cargo DtoToEntityMapper(CargoDto cargoDto);

        IEnumerable<CargoDto> ListCargosDtoMapper(IEnumerable<Cargo> cargo);

        CargoDto EntityToDtoMapper(Cargo cargo);
    }
}