using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsersAPI.Database.Entities;

namespace UsersAPI.Database.Context.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(20);

            builder.Property(x => x.Age).IsRequired();

            builder.Property(x => x.isActive).IsRequired().ValueGeneratedOnAdd().HasDefaultValue(true);
        }
    }
}