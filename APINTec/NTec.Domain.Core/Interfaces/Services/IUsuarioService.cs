using NTec.Domain.Entities;
using System.Threading.Tasks;

namespace NTec.Domain.Core.Interfaces.Services
{
    public interface IUsuarioService : IBaseService<Usuario>
    {
        Usuario GetUsuarioByUserAndPassword(string login, string senha);
    }
}