using Microsoft.EntityFrameworkCore;
using NTec.Domain.Core.Interfaces.Repositories;
using NTec.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace NTec.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly SqlContext _sqlContext;

        public UsuarioRepository(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public Usuario GetUsuarioByUserAndPassword(string login, string senha)
        {
           return _sqlContext.Usuario.Where(u => u.LoginUser == login && u.Senha == senha).FirstOrDefault();
        }
    }
}