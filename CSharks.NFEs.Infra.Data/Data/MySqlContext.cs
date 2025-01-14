﻿using Microsoft.EntityFrameworkCore;
using CSharks.NFEs.Domain.Models;
using CSharks.NFEs.Domain.Models.NF;
using CSharks.NFEs.Domain.Enums;

namespace CSharks.NFEs.Infra.Data.Data
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var enterprise = new Enterprise
            {
                Id = Guid.NewGuid(),
                Name = "Mock Enterprise",
                CpfCnpj = "12345678901234",
                City = "Mock City"
            };


            modelBuilder.Entity<Enterprise>()
                .HasData(enterprise);

            modelBuilder.Entity<User>()
                .HasData(
                new { Id = Guid.NewGuid(), Name = "Desenvolvedor", Login = "dev", Password = "MTIz", Profile = TypeProfile.Admin,
                EnterpriseId = enterprise.Id
                }
            );

            modelBuilder.Entity<Service>()
                .HasData(
                new
                {
                    Id = Guid.NewGuid(),
                    tributa_municipio_prestador = "S",
                    codigo_local_prestacao_servico = "8357",
                    codigo_item_lista_servico = "702",
                    descritivo = "Teste",
                    aliquota_item_lista_servico = "5",
                    situacao_tributaria = "0",
                    valor_tributavel = "0"
                }
            );


            base.OnModelCreating(modelBuilder);
        }

        #region DbSets

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Enterprise> Enterprises { get; set; }




        #endregion
    }
}
