using NTec.Application.Dtos;
using NTec.Application.Interfaces;
using NTec.Application.Mappers.Interfaces;
using NTec.Domain.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace NTec.Application
{
    public class ColaboradorApplicationService : IColaboradorApplicationService
    {
        private readonly IColaboradorService _colaboradorService;
        private readonly IColaboradorMapper _colaboradorMapper;

        public ColaboradorApplicationService(IColaboradorService colaboradorService, IColaboradorMapper colaboradorMapper)
        {
            _colaboradorService = colaboradorService;
            _colaboradorMapper = colaboradorMapper;
        }

        public void Add(ColaboradorDto colaboradorDto)
        {
            var setor = _colaboradorMapper.DtoToEntityMapper(colaboradorDto);
            _colaboradorService.Add(setor);
        }

        public IEnumerable<ColaboradorDto> GetAll()
        {
            var colaboradores = _colaboradorService.GetAll();
            return _colaboradorMapper.ListColaboradoresDtoMapper(colaboradores);
        }

        public IEnumerable<ColaboradorDto> GetAllAtivos()
        {
            var setores = _colaboradorService.GetAll().Where(x => x.Ativo == true);
            return _colaboradorMapper.ListColaboradoresDtoMapper(setores);
        }

        public ColaboradorDto GetById(int id)
        {
            var setor = _colaboradorService.GetById(id);
            return _colaboradorMapper.EntityToDtoMapper(setor);
        }

        public IEnumerable<ColaboradorDto> ObterSubordinados(int idColaborador)
        {
            var colaboradores = _colaboradorService.ObterSubordinados(idColaborador);
            return _colaboradorMapper.ListColaboradoresDtoMapper(colaboradores);
        }

        public void Remove(int id)
        {
            _colaboradorService.Remove(id);
        }

        public void Update(ColaboradorDto colaboradorDto)
        {
            var colaborador = _colaboradorMapper.DtoToEntityMapper(colaboradorDto);
            _colaboradorService.Update(colaborador);
        }

        public bool VerificaSePossuiSubordinados(int idColaborador)
        {
            return _colaboradorService.VerificaSePossuiSubordinados(idColaborador);
        }
    }
}