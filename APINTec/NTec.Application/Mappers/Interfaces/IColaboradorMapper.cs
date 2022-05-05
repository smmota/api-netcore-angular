using NTec.Application.Dtos;
using NTec.Domain.Entities;
using System.Collections.Generic;

namespace NTec.Application.Mappers.Interfaces
{
    public interface IColaboradorMapper
    {
        Colaborador DtoToEntityMapper(ColaboradorDto colaboradorDto);

        IEnumerable<ColaboradorDto> ListColaboradoresDtoMapper(IEnumerable<Colaborador> colaboradores);

        ColaboradorDto EntityToDtoMapper(Colaborador colaborador);
    }
}