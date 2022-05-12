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
            //bool hasChildren = true;

            //ColaboradorDto colaboradorDto = new ColaboradorDto();
            //colaboradorDto.Id = colaborador.Id;
            //colaboradorDto.Nome = colaborador.Nome;
            //colaboradorDto.DataNascimento = colaborador.DataNascimento;
            //colaboradorDto.CPF = colaborador.CPF;
            //colaboradorDto.Endereco = colaborador.Endereco;
            //colaboradorDto.IdSetor = colaborador.IdSetor;
            //colaboradorDto.IdCargo = colaborador.IdCargo;
            //colaboradorDto.Ativo = colaborador.Ativo;
            //colaboradorDto.IdSuperiorImediato = colaborador.IdSuperiorImediato;

            //if (colaborador.Subordinados != null)
            //{

            //}
            //while (hasChildren)
            //{

            //}



            //ColaboradorDto colaboradorDto = new ColaboradorDto();

            //colaboradorDto.Id = colaborador.Id;
            //colaboradorDto.Nome = colaborador.Nome;
            //colaboradorDto.DataNascimento = colaborador.DataNascimento;
            //colaboradorDto.CPF = colaborador.CPF;
            //colaboradorDto.Endereco = colaborador.Endereco;
            //colaboradorDto.IdSetor = colaborador.IdSetor;
            //colaboradorDto.IdCargo = colaborador.IdCargo;
            //colaboradorDto.Ativo = colaborador.Ativo;
            //colaboradorDto.IdSuperiorImediato = colaborador.IdSuperiorImediato;

            //colaboradorDto.Subordinados = new List<ColaboradorDto>();

            //foreach (var subordinado in colaborador.Subordinados)
            //{
            //    colaboradorDto.Subordinados.Add(
            //        new ColaboradorDto()
            //        {
            //            Id = subordinado.Id,
            //            Nome = subordinado.Nome,
            //            DataNascimento = subordinado.DataNascimento,
            //            CPF = subordinado.CPF,
            //            Endereco = subordinado.Endereco,
            //            IdSetor = subordinado.IdSetor,
            //            IdCargo = subordinado.IdCargo,
            //            Ativo = subordinado.Ativo,
            //            IdSuperiorImediato = subordinado.IdSuperiorImediato
            //        });
            //}

            //return colaboradorDto;

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