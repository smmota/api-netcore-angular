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

        public bool Add(CargoDto cargoDto)
        {
            bool retorno = false;

            try
            {
                if (cargoDto.Id != 0)
                    throw new System.Exception("Cargo não cadastrado! O Id deve ser 0");

                var cargo = _cargoMapper.DtoToEntityMapper(cargoDto);
                _cargoService.Add(cargo);

                retorno = true;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Erro ao cadastrar o cargo. " + ex.Message);
            }

            return retorno;
        }

        public IEnumerable<CargoDto> GetAll()
        {
            var cargos = _cargoService.GetAll();
            return _cargoMapper.ListCargosDtoMapper(cargos);
        }

        public CargoDto GetById(int id)
        {
            try
            {
                if (id == 0)
                    throw new System.Exception("O Id informado é inválido!");

                var cargo = _cargoService.GetById(id);

                if (cargo != null)
                    return _cargoMapper.EntityToDtoMapper(cargo);
                else
                    return null;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Erro ao obter o cargo. " + ex.Message);
            }
            
        }

        public bool Remove(int id)
        {
            bool retorno = false;
            try
            {
                if (id == 0)
                    throw new System.Exception("O Id informado é inválido!");

                _cargoService.Remove(id);
                retorno = true;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Erro ao remover o cargo informado! " + ex.Message);
            }

            return retorno;
        }

        public bool Update(CargoDto cargoDto)
        {
            bool retorno = false;

            try
            {
                if (cargoDto.Id == 0)
                    throw new System.Exception("O Id informado é inválido!");

                var cargo = _cargoMapper.DtoToEntityMapper(cargoDto);
                _cargoService.Update(cargo);

                retorno = true;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Erro ao atualizar o cargo! " + ex.Message);
            }

            return retorno;
        }
    }
}