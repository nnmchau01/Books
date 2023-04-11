using Books.BackendServer.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Books.BackendServer.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Book>();
            builder.Entity<Author>();
            builder.Entity<User>().Property(x => x.Id).HasMaxLength(50).IsUnicode(true);
            
        }

        public DbSet<Book> Books { get; set; } 

        public DbSet<Author> Authors { get; set; }

    }
}
