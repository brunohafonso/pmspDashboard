using System.Linq;
using Microsoft.EntityFrameworkCore;
using bruno.pmsp.domain.Entities;

namespace bruno.pmsp.repository.Context
{
    public class PmspContext : DbContext 
    {
        public PmspContext(DbContextOptions<PmspContext> options) : base(options) { }

        public DbSet<Login> Logins { get; set; }
        public DbSet<Servidor> Servidores { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Vinculo> Vinculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>().ToTable("Logins");
            modelBuilder.Entity<Servidor>().ToTable("Servidores");
            modelBuilder.Entity<Telefone>().ToTable("Telefones");
            modelBuilder.Entity<Endereco>().ToTable("Enderecos");
            modelBuilder.Entity<Vinculo>().ToTable("Vinculos");

            modelBuilder
                .Entity<Servidor>()
                .HasIndex(u => u.RF)
                .IsUnique();

            modelBuilder
                .Entity<Login>()
                .HasIndex(u => u.CredenciaisAcesso)
                .IsUnique();

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating (modelBuilder);
        }
    }
}