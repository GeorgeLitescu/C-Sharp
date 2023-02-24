using Microsoft.EntityFrameworkCore;
using UsersAPI.Database.Context.Configs;
using UsersAPI.Database.Entities;

namespace UsersAPI.Database.Context
{
    public class DatabaseContext: DbContext
    {

        public DatabaseContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
        }

        public DbSet<User> Users { get; set; }
    }
}
