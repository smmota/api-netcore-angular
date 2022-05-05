using NTec.Application.Dtos;
using NTec.Domain.Entities;
using System.Collections.Generic;

namespace NTec.Application.Mappers.Interfaces
{
    public interface IUsuarioMapper
    {
        Usuario DtoToEntityMapper(UsuarioDto usuarioDto);

        IEnumerable<UsuarioDto> ListUsuariosDtoMapper(IEnumerable<Usuario> usuarios);

        UsuarioDto EntityToDtoMapper(Usuario usuario);
    }
}