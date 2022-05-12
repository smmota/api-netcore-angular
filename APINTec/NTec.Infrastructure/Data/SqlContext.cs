﻿using Microsoft.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Colaborador>(x =>
            {
                x.ToTable("Colaborador");

                x.HasKey(k => k.Id);
                x.Property(p => p.Id)
                    .UseIdentityColumn();

                x.Property(p => p.Nome).HasMaxLength(200);
                x.Property(p => p.DataNascimento);
                x.Property(p => p.CPF).HasMaxLength(11);
                x.Property(p => p.Endereco).HasMaxLength(200);

                x.HasOne<Cargo>(col => col.Cargo)
                 .WithMany(car => car.Colaboradores)
                 .HasForeignKey(col => col.IdCargo);

                x.HasOne<Setor>(col => col.Setor)
                 .WithMany(set => set.Colaboradores)
                 .HasForeignKey(col => col.IdSetor);

                x.HasMany(x => x.Subordinados)
                 .WithOne()
                 .HasForeignKey(x => x.IdSuperiorImediato)
                 .HasPrincipalKey(x => x.Id);
            });

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}