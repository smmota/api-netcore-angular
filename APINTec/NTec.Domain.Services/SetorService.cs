using NTec.Domain.Core.Interfaces.Repositories;
using NTec.Domain.Core.Interfaces.Services;
using NTec.Domain.Entities;

namespace NTec.Domain.Services
{
    public class SetorService : BaseService<Setor>, ISetorService
    {
        private readonly ISetorRepository _setorRepository;

        public SetorService(ISetorRepository setorRepository) : base(setorRepository)
        {
            _setorRepository = setorRepository;
        }
    }
}