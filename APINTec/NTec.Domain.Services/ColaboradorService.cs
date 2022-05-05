using NTec.Domain.Core.Interfaces.Repositories;
using NTec.Domain.Core.Interfaces.Services;
using NTec.Domain.Entities;
using System.Collections.Generic;

namespace NTec.Domain.Services
{
    public class ColaboradorService : BaseService<Colaborador>, IColaboradorService
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorService(IColaboradorRepository colaboradorRepository) : base(colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        public IEnumerable<Colaborador> ObterSubordinados(int idColaborador)
        {
            return _colaboradorRepository.ObterSubordinados(idColaborador);
        }

        public bool VerificaSePossuiSubordinados(int idColaborador)
        {
            return _colaboradorRepository.VerificaSePossuiSubordinados(idColaborador);
        }
    }
}