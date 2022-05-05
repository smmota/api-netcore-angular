using NTec.Application.Dtos;
using NTec.Application.Interfaces;
using NTec.Application.Mappers.Interfaces;
using NTec.Domain.Core.Interfaces.Services;
using System.Collections.Generic;

namespace NTec.Application
{
    public class CargoApplicationService : ICargoApplicationService
    {
        private readonly ICargoService _cargoService;
        private readonly ICargoMapper _cargoMapper;

        public CargoApplicationService(ICargoService cargoService, ICargoMapper cargoMapper)
        {
            _cargoService = cargoService;
            _cargoMapper = cargoMapper;
        }

        public void Add(CargoDto cargoDto)
        {
            var cargo = _cargoMapper.DtoToEntityMapper(cargoDto);
            _cargoService.Add(cargo);
        }

        public IEnumerable<CargoDto> GetAll()
        {
            var cargos = _cargoService.GetAll();
            return _cargoMapper.ListCargosDtoMapper(cargos);
        }

        public CargoDto GetById(int id)
        {
            var cargo = _cargoService.GetById(id);

            if (cargo != null)
                return _cargoMapper.EntityToDtoMapper(cargo);
            else
                return null;
        }

        public void Remove(int id)
        {
            //var cargo = _cargoMapper.DtoToEntityMapper(cargoDto);
            _cargoService.Remove(id);
        }

        public void Update(CargoDto cargoDto)
        {
            var cargo = _cargoMapper.DtoToEntityMapper(cargoDto);
            _cargoService.Update(cargo);
        }
    }
}