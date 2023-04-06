using teste_react_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace teste_react_api.Persistence
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(e =>
            {
                e.HasKey(u => u.Id);

                e.Property(u => u.Name).IsRequired(true);
                e.Property(u => u.Email).IsRequired(true);
                e.Property(u => u.Password).IsRequired(true);
                e.HasMany(u => u.Adress);
                e.Property(u => u.Phone).IsRequired(true);
            });
        }
    }
}
