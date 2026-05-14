using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mimo_Mo.Core.Entities;

namespace Mimo_Mo.Infrastructure.Data.Configrations;

public class ProductConfigrations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(255);
        builder.Property(p => p.Description).IsRequired().HasMaxLength(500);
        builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(p => p.Image).IsRequired(false).HasMaxLength(2048);
        builder.Property(p => p.Discount).IsRequired(false).HasColumnType("decimal(18,2)");
        builder.Property(p => p.Quantity).IsRequired();
        builder.Property(p => p.IsAvailable)
            .HasComputedColumnSql(
                "CASE WHEN [Quantity] > 0 THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END",
                stored: false);
    }
}