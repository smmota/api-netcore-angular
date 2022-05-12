using NTec.Application.Dtos;
using System.Collections.Generic;

namespace NTec.Application.Interfaces
{
    public interface ISetorApplicationService
    {
        bool Add(SetorDto setorDto);

        bool Update(SetorDto setorDto);

        bool Remove(int id);

        IEnumerable<SetorDto> GetAll();

        SetorDto GetById(int id);

        IEnumerable<SetorDto> GetAllAtivos();
    }
}