using NTec.Application.Dtos;
using NTec.Application.Interfaces;
using NTec.Application.Mappers.Interfaces;
using NTec.Domain.Core.Interfaces.Services;
using NTec.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NTec.Application
{
    public class ColaboradorApplicationService : IColaboradorApplicationService
    {
        private readonly IColaboradorService _colaboradorService;
        private readonly IColaboradorMapper _colaboradorMapper;
        private readonly ICargoApplicationService _cargoApplicationService;
        private readonly ISetorApplicationService _setorApplicationService;

        public ColaboradorApplicationService(
            IColaboradorService colaboradorService,
            ICargoApplicationService cargoApplicationService,
            ISetorApplicationService setorApplicationService,
            IColaboradorMapper colaboradorMapper)
        {
            _colaboradorService = colaboradorService;
            _colaboradorMapper = colaboradorMapper;
            _cargoApplicationService = cargoApplicationService;
            _setorApplicationService = setorApplicationService;
        }

        public bool Add(ColaboradorDto colaboradorDto)
        {
            bool retorno = false;

            try
            {
                if (colaboradorDto.Id != 0)
                    throw new System.Exception("Colaborador não cadastrado! O Id deve ser 0");

                var colaborador = _colaboradorMapper.DtoToEntityMapper(colaboradorDto);
                _colaboradorService.Add(colaborador);

                retorno = true;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Erro ao cadastrar o colaborador. " + ex.Message);
            }

            return retorno;
        }

        public IEnumerable<ColaboradorDto> GetAll()
        {
            //Ajustar esse método para retornar direto do mapeamento.
            var colaboradores = _colaboradorService.GetAll();
            var colaboradoresDto = _colaboradorMapper.ListColaboradoresDtoMapper(colaboradores);
            List<ColaboradorDto> lista = new List<ColaboradorDto>();

            foreach (var colaborador in colaboradoresDto)
            {
                colaborador.Cargo = _cargoApplicationService.GetById(colaborador.IdCargo);
                colaborador.Setor = _setorApplicationService.GetById(colaborador.IdSetor);

                lista.Add(colaborador);
            }

            return lista;
        }

        public IEnumerable<ColaboradorDto> GetAllAtivos()
        {
            var colaboradores = _colaboradorService.GetAll().Where(x => x.Ativo == true);
            return _colaboradorMapper.ListColaboradoresDtoMapper(colaboradores);
        }

        public ColaboradorDto GetById(int id)
        {
            try
            {
                if (id == 0)
                    throw new System.Exception("O Id informado é inválido!");

                var colaborador = _colaboradorService.GetById(id);

                if (colaborador != null)
                    return _colaboradorMapper.EntityToDtoMapper(colaborador);
                else
                    return null;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Erro ao obter o colaborador. " + ex.Message);
            }
        }

        public Colaborador ObterOrganograma()
        {
            return _colaboradorService.ObterOrganograma();
        }

        public IEnumerable<ColaboradorDto> ObterSubordinados(int idColaborador)
        {
            var colaboradores = _colaboradorService.ObterSubordinados(idColaborador);
            return _colaboradorMapper.ListColaboradoresDtoMapper(colaboradores);
        }

        public bool Remove(int id)
        {
            bool retorno = false;

            try
            {
                if (id == 0)
                    throw new System.Exception("O Id informado é inválido!");

                _colaboradorService.Remove(id);
                retorno = true;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Erro ao remover o colaborador informado! " + ex.Message);
            }

            return retorno;
        }

        public bool Update(ColaboradorDto colaboradorDto)
        {
            bool retorno = false;

            try
            {
                if (colaboradorDto.Id == 0)
                    throw new System.Exception("O Id informado é inválido!");

                var colaborador = _colaboradorMapper.DtoToEntityMapper(colaboradorDto);
                _colaboradorService.Update(colaborador);

                retorno = true;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Erro ao atualizar o colaborador! " + ex.Message);
            }

            return retorno;
        }

        public bool VerificaSePossuiSubordinados(int idColaborador)
        {
            return _colaboradorService.VerificaSePossuiSubordinados(idColaborador);
        }
    }
}