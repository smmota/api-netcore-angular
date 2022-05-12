using Microsoft.EntityFrameworkCore;
using NTec.Domain.Core.Interfaces.Repositories;
using NTec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTec.Infrastructure.Data.Repositories
{
    public class ColaboradorRepository : BaseRepository<Colaborador>, IColaboradorRepository
    {
        private readonly SqlContext _sqlContext;

        public ColaboradorRepository(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public IEnumerable<Colaborador> ObterSubordinados(int idColaborador)
        {
            try
            {
                IQueryable<Colaborador> resultado = _sqlContext.Colaborador.Where(c => c.IdSuperiorImediato == idColaborador);

               return resultado.ToList();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public bool VerificaSePossuiSubordinados(int idColaborador)
        {
            try
            {
                bool resultado = _sqlContext.Colaborador.Where(c => c.IdSuperiorImediato == idColaborador).Count() > 0;
                return resultado;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public Colaborador ObterOrganograma()
        {
            try
            {
                Colaborador resultado = _sqlContext.Colaborador
                    .Where(x => x.IdSuperiorImediato == null)
                    .Include(i => i.Subordinados)
                        .ThenInclude(it => it.Subordinados)
                        .ThenInclude(it => it.Subordinados)
                        .ThenInclude(it => it.Subordinados)
                        .ThenInclude(it => it.Subordinados)
                        .ThenInclude(it => it.Subordinados).FirstOrDefault();

                return resultado;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}