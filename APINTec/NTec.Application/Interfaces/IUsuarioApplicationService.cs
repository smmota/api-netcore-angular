using NTec.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NTec.Application.Interfaces
{
    public interface IUsuarioApplicationService
    {
        void Add(UsuarioDto usuarioDto);

        void Update(UsuarioDto usuarioDto);

        void Remove(int id);

        IEnumerable<UsuarioDto> GetAll();

        UsuarioDto GetById(int id);

        IEnumerable<UsuarioDto> GetAllAtivos();

        Task<UsuarioDto> GetUsuarioByUserAndPassword(string login, string senha);
    }
}