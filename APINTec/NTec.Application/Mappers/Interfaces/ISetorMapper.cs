using NTec.Application.Dtos;
using NTec.Domain.Entities;
using System.Collections.Generic;

namespace NTec.Application.Mappers.Interfaces
{
    public interface ISetorMapper
    {
        Setor DtoToEntityMapper(SetorDto setorDto);

        IEnumerable<SetorDto> ListSetoresDtoMapper(IEnumerable<Setor> setores);

        SetorDto EntityToDtoMapper(Setor setor);
    }
}