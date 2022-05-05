using NTec.Application.Dtos;
using NTec.Application.Interfaces;
using NTec.Application.Mappers.Interfaces;
using NTec.Domain.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace NTec.Application
{
    public class SetorApplicationService : ISetorApplicationService
    {
        private readonly ISetorService _setorService;
        private readonly ISetorMapper _setorMapper;

        public SetorApplicationService(ISetorService setorService, ISetorMapper setorMapper)
        {
            _setorService = setorService;
            _setorMapper = setorMapper;
        }

        public void Add(SetorDto setorDto)
        {
            var setor = _setorMapper.DtoToEntityMapper(setorDto);
            _setorService.Add(setor);
        }

        public IEnumerable<SetorDto> GetAll()
        {
            var setores = _setorService.GetAll();
            return _setorMapper.ListSetoresDtoMapper(setores);
        }

        public IEnumerable<SetorDto> GetAllAtivos()
        {
            var setores = _setorService.GetAll().Where(x => x.Ativo == true);
            return _setorMapper.ListSetoresDtoMapper(setores);
        }

        public SetorDto GetById(int id)
        {
            var setor = _setorService.GetById(id);
            return _setorMapper.EntityToDtoMapper(setor);
        }

        public void Remove(int id)
        {
            _setorService.Remove(id);
        }

        public void Update(SetorDto setorDto)
        {
            var setor = _setorMapper.DtoToEntityMapper(setorDto);
            _setorService.Update(setor);
        }
    }
}