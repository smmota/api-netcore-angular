using NTec.Domain.Core.Interfaces.Repositories;
using NTec.Domain.Core.Interfaces.Services;
using NTec.Domain.Entities;
using System.Threading.Tasks;

namespace NTec.Domain.Services
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario GetUsuarioByUserAndPassword(string login, string senha)
        {
            return _usuarioRepository.GetUsuarioByUserAndPassword(login, senha);
        }
    }
}