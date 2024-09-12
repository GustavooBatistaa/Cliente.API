using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Ocorrencia> Ocorrencias { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração de chaves primárias
            modelBuilder.Entity<Cliente>().HasKey(c => c.Id);
            modelBuilder.Entity<Ocorrencia>().HasKey(o => o.Id);

            // Configuração das chaves estrangeiras e comportamento de deleção
            modelBuilder.Entity<Ocorrencia>()
                .HasOne(o => o.ResponsavelAbertura)
                .WithMany()
                .HasForeignKey(o => o.ResponsavelAberturaId)
                .OnDelete(DeleteBehavior.Restrict); // Impede a deleção em cascata

            modelBuilder.Entity<Ocorrencia>()
                .HasOne(o => o.ResponsavelOcorrencia)
                .WithMany()
                .HasForeignKey(o => o.ResponsavelOcorrenciaId)
                .OnDelete(DeleteBehavior.Restrict); // Impede a deleção em cascata

            base.OnModelCreating(modelBuilder);
        }


    }
}
