using NTec.Application.Dtos;
using System.Collections.Generic;

namespace NTec.Application.Interfaces
{
    public interface IColaboradorApplicationService
    {
        void Add(ColaboradorDto colaboradorDto);

        void Update(ColaboradorDto colaboradorDto);

        void Remove(int id);

        IEnumerable<ColaboradorDto> GetAll();

        ColaboradorDto GetById(int id);

        IEnumerable<ColaboradorDto> GetAllAtivos();

        IEnumerable<ColaboradorDto> ObterSubordinados(int idColaborador);

        bool VerificaSePossuiSubordinados(int idColaborador);
    }
}