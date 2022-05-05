using Microsoft.EntityFrameworkCore;
using NTec.Domain.Entities;
using System;
using System.Linq;

namespace NTec.Infrastructure.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        { }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public DbSet<Setor> Setor { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Colaborador> Colaborador { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}