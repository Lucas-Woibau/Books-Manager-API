using GerenciamentoBiblioteca.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoBiblioteca.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Lending> Lendings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Book>(e =>
            {
                e.HasKey(l => l.Id);

                e.Property(l => l.Status)
                .HasConversion<string>();
            });

            builder
                .Entity<User>(e =>
            {
                e.HasKey(u => u.Id);
            });

            builder
                .Entity<Lending>(e =>
                {
                    e.HasKey(e => e.Id);

                    e.HasOne(e => e.User)
                        .WithMany()
                        .HasForeignKey(e => e.IdUser)
                        .OnDelete(DeleteBehavior.Restrict);

                    e.HasOne(e => e.Book)
                        .WithMany()
                        .HasForeignKey(e => e.IdBook)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            base.OnModelCreating(builder);
        }
    }
}
