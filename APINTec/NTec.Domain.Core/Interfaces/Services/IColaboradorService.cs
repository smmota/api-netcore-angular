using NTec.Domain.Entities;
using System.Collections.Generic;

namespace NTec.Domain.Core.Interfaces.Services
{
    public interface IColaboradorService : IBaseService<Colaborador>
    {
        IEnumerable<Colaborador> ObterSubordinados(int idColaborador);
        bool VerificaSePossuiSubordinados(int idColaborador);
        Colaborador ObterOrganograma();
    }
}