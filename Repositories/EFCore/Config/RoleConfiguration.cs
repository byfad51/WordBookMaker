using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
       new IdentityRole {
            Name = "Admin",
            NormalizedName = "ADMIN"
        },
        new IdentityRole {
            Name = "BronzeUser",
            NormalizedName = "BRONZE_USER"
        },
        new IdentityRole {
            Name = "SilverUser",
            NormalizedName = "SILVER_USER"
        },
        new IdentityRole {
            Name = "GoldUser",
            NormalizedName = "GOLD_USER"
        });
    }
}