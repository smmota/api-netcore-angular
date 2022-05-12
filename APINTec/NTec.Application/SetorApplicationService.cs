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

        public bool Add(SetorDto setorDto)
        {
            bool retorno = false;

            try
            {
                if (setorDto.Id != 0)
                    throw new System.Exception("Setor não cadastrado! O Id deve ser 0");

                var setor = _setorMapper.DtoToEntityMapper(setorDto);
                _setorService.Add(setor);

                retorno = true;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Erro ao cadastrar o setor. " + ex.Message);
            }

            return retorno;
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
            try
            {
                if (id == 0)
                    throw new System.Exception("O Id informado é inválido!");

                var setor = _setorService.GetById(id);

                if (setor != null)
                    return _setorMapper.EntityToDtoMapper(setor);
                else
                    return null;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Erro ao obter o setor. " + ex.Message);
            }
        }

        public bool Remove(int id)
        {
            bool retorno = false;

            try
            {
                if (id == 0)
                    throw new System.Exception("O Id informado é inválido!");

                _setorService.Remove(id);
                retorno = true;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Erro ao remover o setor informado! " + ex.Message);
            }

            return retorno;
        }

        public bool Update(SetorDto setorDto)
        {
            bool retorno = false;

            try
            {
                if (setorDto.Id == 0)
                    throw new System.Exception("O Id informado é inválido!");

                var setor = _setorMapper.DtoToEntityMapper(setorDto);
                _setorService.Update(setor);

                retorno = true;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Erro ao atualizar o setor! " + ex.Message);
            }

            return retorno;
        }
    }
}