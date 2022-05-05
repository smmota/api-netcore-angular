using NTec.Application.Dtos;
using NTec.Application.Interfaces;
using NTec.Application.Mappers.Interfaces;
using NTec.Domain.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTec.Application
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IUsuarioMapper _usuarioMapper;

        public UsuarioApplicationService(IUsuarioService usuarioService, IUsuarioMapper usuarioMapper)
        {
            _usuarioService = usuarioService;
            _usuarioMapper = usuarioMapper;
        }

        public void Add(UsuarioDto usuarioDto)
        {
            var setor = _usuarioMapper.DtoToEntityMapper(usuarioDto);
            _usuarioService.Add(setor);
        }

        public IEnumerable<UsuarioDto> GetAll()
        {
            var usuarios = _usuarioService.GetAll();
            return _usuarioMapper.ListUsuariosDtoMapper(usuarios);
        }

        public IEnumerable<UsuarioDto> GetAllAtivos()
        {
            var usuarios = _usuarioService.GetAll().Where(x => x.Ativo == true);
            return _usuarioMapper.ListUsuariosDtoMapper(usuarios);
        }

        public UsuarioDto GetById(int id)
        {
            var usuario = _usuarioService.GetById(id);
            return _usuarioMapper.EntityToDtoMapper(usuario);
        }

        public async Task<UsuarioDto> GetUsuarioByUserAndPassword(string login, string senha)
        {
            var usuario = await _usuarioService.GetUsuarioByUserAndPassword(login, senha);
            return _usuarioMapper.EntityToDtoMapper(usuario);
        }

        public void Remove(int id)
        {
            _usuarioService.Remove(id);
        }

        public void Update(UsuarioDto usuarioDto)
        {
            var usuario = _usuarioMapper.DtoToEntityMapper(usuarioDto);
            _usuarioService.Update(usuario);
        }
    }
}