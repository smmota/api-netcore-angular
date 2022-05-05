using NTec.Application.Dtos;
using System.Collections.Generic;

namespace NTec.Application.Interfaces
{
    public interface ISetorApplicationService
    {
        void Add(SetorDto setorDto);

        void Update(SetorDto setorDto);

        void Remove(int id);

        IEnumerable<SetorDto> GetAll();

        SetorDto GetById(int id);

        IEnumerable<SetorDto> GetAllAtivos();
    }
}