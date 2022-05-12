using NTec.Application.Dtos;
using System.Collections.Generic;

namespace NTec.Application.Interfaces
{
    public interface IColaboradorApplicationService
    {
        bool Add(ColaboradorDto colaboradorDto);

        bool Update(ColaboradorDto colaboradorDto);

        bool Remove(int id);

        IEnumerable<ColaboradorDto> GetAll();

        ColaboradorDto GetById(int id);

        IEnumerable<ColaboradorDto> GetAllAtivos();

        IEnumerable<ColaboradorDto> ObterSubordinados(int idColaborador);

        bool VerificaSePossuiSubordinados(int idColaborador);
    }
}