using NTec.Application.Dtos;
using NTec.Application.Mappers.Interfaces;
using NTec.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NTec.Application.Mappers
{
    public class ColaboradorMapper : IColaboradorMapper
    {
        public Colaborador DtoToEntityMapper(ColaboradorDto colaboradorDto)
        {
            return
                new Colaborador()
                {
                    Id = colaboradorDto.Id,
                    Nome = colaboradorDto.Nome,
                    DataNascimento = colaboradorDto.DataNascimento,
                    CPF = colaboradorDto.CPF,
                    Endereco = colaboradorDto.Endereco,
                    IdSetor = colaboradorDto.IdSetor,
                    IdCargo = colaboradorDto.IdCargo,
                    Ativo = colaboradorDto.Ativo,
                    IdSuperiorImediato = colaboradorDto.IdSuperiorImediato
                };
        }

        public ColaboradorDto EntityToDtoMapper(Colaborador colaborador)
        {
            return
                new ColaboradorDto()
                {
                    Id = colaborador.Id,
                    Nome = colaborador.Nome,
                    DataNascimento = colaborador.DataNascimento,
                    CPF = colaborador.CPF,
                    Endereco = colaborador.Endereco,
                    IdSetor = colaborador.IdSetor,
                    IdCargo = colaborador.IdCargo,
                    Ativo = colaborador.Ativo,
                    IdSuperiorImediato = colaborador.IdSuperiorImediato
                };
        }

        public IEnumerable<ColaboradorDto> ListColaboradoresDtoMapper(IEnumerable<Colaborador> colaboradores)
        {
            return
                colaboradores.Select(x => new ColaboradorDto
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    DataNascimento = x.DataNascimento,
                    CPF = x.CPF,
                    Endereco = x.Endereco,
                    IdSetor = x.IdSetor,
                    IdCargo = x.IdCargo,
                    Ativo = x.Ativo,
                    IdSuperiorImediato = x.IdSuperiorImediato
                });
        }
    }
}