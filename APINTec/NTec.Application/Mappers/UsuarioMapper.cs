using NTec.Application.Dtos;
using NTec.Application.Mappers.Interfaces;
using NTec.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NTec.Application.Mappers
{
    public class UsuarioMapper : IUsuarioMapper
    {
        public Usuario DtoToEntityMapper(UsuarioDto usuarioDto)
        {
            return
                new Usuario()
                {
                    Id = usuarioDto.Id,
                    Nome = usuarioDto.Nome,
                    LoginUser = usuarioDto.LoginUser,
                    Senha = usuarioDto.Senha,
                    Ativo = usuarioDto.Ativo,
                };
        }

        public UsuarioDto EntityToDtoMapper(Usuario usuario)
        {
            return
                new UsuarioDto()
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    LoginUser = usuario.LoginUser,
                    Senha = usuario.Senha,
                    Ativo = usuario.Ativo,
                };
        }

        public IEnumerable<UsuarioDto> ListUsuariosDtoMapper(IEnumerable<Usuario> usuarios)
        {
            return
                usuarios.Select(x => new UsuarioDto
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    LoginUser = x.LoginUser,
                    Senha = x.Senha,
                    Ativo = x.Ativo,
                });
        }
    }
}