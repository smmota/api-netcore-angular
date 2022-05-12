using NTec.Domain.Entities;
using System.Threading.Tasks;

namespace NTec.Domain.Core.Interfaces.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario GetUsuarioByUserAndPassword(string login, string senha);
    }
}