using NTec.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NTec.Domain.Core.Interfaces.Repositories
{
    public interface IColaboradorRepository : IBaseRepository<Colaborador>
    {
        IEnumerable<Colaborador> ObterSubordinados(int idColaborador);
        bool VerificaSePossuiSubordinados(int idColaborador);
        Colaborador ObterOrganograma();
    }
}