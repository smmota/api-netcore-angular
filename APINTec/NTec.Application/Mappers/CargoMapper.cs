using NTec.Application.Dtos;
using NTec.Application.Mappers.Interfaces;
using NTec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NTec.Application.Mappers
{
    public class CargoMapper : ICargoMapper
    {
        public Cargo DtoToEntityMapper(CargoDto cargoDto)
        {
            return
                new Cargo()
                {
                    Id = cargoDto.Id,
                    Descricao = cargoDto.Descricao,
                    Atividade = cargoDto.Atividade,
                    Ativo = cargoDto.Ativo,
                };
        }

        public CargoDto EntityToDtoMapper(Cargo cargo)
        {
            return
                new CargoDto()
                {
                    Id = cargo.Id,
                    Descricao = cargo.Descricao,
                    Atividade = cargo.Atividade,
                    Ativo = cargo.Ativo,
                };
        }

        public IEnumerable<CargoDto> ListCargosDtoMapper(IEnumerable<Cargo> cargos)
        {
            return
                cargos.Select(x => new CargoDto
                {
                    Id = x.Id,
                    Descricao = x.Descricao,
                    Atividade = x.Atividade,
                    Ativo = x.Ativo,
                });
        }
    }
}