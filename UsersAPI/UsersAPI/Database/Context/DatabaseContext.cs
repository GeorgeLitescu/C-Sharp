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

            //modelBuilder.Entity<User>()
            //    .HasKey(x => x.Id);

            //modelBuilder.Entity<User>()
            //    .Property(x => x.Id).IsRequired()
            //    .ValueGeneratedOnAdd();

            //modelBuilder.Entity<User>()
            //    .Property(x => x.Name)
            //    .IsRequired();

            ///modelBuilder.Entity<User>()
            //    .Property(x => x.isActive)
            //    .IsRequired()
            //    .ValueGeneratedOnAdd()
            //    .HasDefaultValue(true);

        }

        public DbSet<User> Users { get; set; }
    }
}
