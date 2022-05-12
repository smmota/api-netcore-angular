using NTec.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NTec.Application.Interfaces
{
    public interface IUsuarioApplicationService
    {
        bool Add(UsuarioDto usuarioDto);

        bool Update(UsuarioDto usuarioDto);

        bool Remove(int id);

        IEnumerable<UsuarioDto> GetAll();

        UsuarioDto GetById(int id);

        IEnumerable<UsuarioDto> GetAllAtivos();

        UsuarioDto GetUsuarioByUserAndPassword(string login, string senha);
    }
}