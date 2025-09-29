using GerenciamentoBiblioteca.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoBiblioteca.Infrasctruct.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Livro>(e =>
            {
                e.HasKey(l => l.Id);
            });

            builder
                .Entity<Usuario>(e =>
            {
                e.HasKey(u => u.Id);
            });

            builder
                .Entity<Emprestimo>(e =>
                {
                    e.HasKey(e => e.Id);

                    e.HasOne(e => e.Livro)
                        .WithMany()
                        .HasForeignKey(e => e.IdLivro)
                        .OnDelete(DeleteBehavior.Restrict);

                    e.HasOne(e => e.Usuario)
                        .WithMany()
                        .HasForeignKey(e => e.IdUsuario)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            base.OnModelCreating(builder);
        }
    }
}
