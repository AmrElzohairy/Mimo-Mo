using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mimo_Mo.Core.Entities;

namespace Mimo_Mo.Infrastructure.Data.Configrations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Username).IsRequired().HasMaxLength(500);
        builder.Property(p => p.Email).IsRequired().HasMaxLength(500);
        builder.Property(p => p.PasswordHash).IsRequired().HasMaxLength(500);
    }
}