using Microsoft.EntityFrameworkCore;
using NTec.Domain.Core.Interfaces.Repositories;
using NTec.Domain.Entities;
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

        public async Task<Usuario> GetUsuarioByUserAndPassword(string login, string senha)
        {
            return await _sqlContext.Usuario.AsNoTracking().SingleOrDefaultAsync(u => u.LoginUser == login && u.Senha == senha);
        }
    }
}