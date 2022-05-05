using NTec.Application.Dtos;
using NTec.Application.Mappers.Interfaces;
using NTec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NTec.Application.Mappers
{
    public class SetorMapper : ISetorMapper
    {
        public Setor DtoToEntityMapper(SetorDto setorDto)
        {
            return
                new Setor()
                {
                    Id = setorDto.Id,
                    Descricao = setorDto.Descricao,
                    Atividade = setorDto.Atividade,
                    Ativo = setorDto.Ativo,
                };
        }

        public SetorDto EntityToDtoMapper(Setor setor)
        {
            return
                new SetorDto()
                {
                    Id = setor.Id,
                    Descricao = setor.Descricao,
                    Atividade = setor.Atividade,
                    Ativo = setor.Ativo,
                };
        }

        public IEnumerable<SetorDto> ListSetoresDtoMapper(IEnumerable<Setor> setores)
        {
            return
                setores.Select(x => new SetorDto
                {
                    Id = x.Id,
                    Descricao = x.Descricao,
                    Atividade = x.Atividade,
                    Ativo = x.Ativo,
                });
        }
    }
}