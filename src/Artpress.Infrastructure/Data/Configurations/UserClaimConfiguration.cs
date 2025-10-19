using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Artpress.Domain.Entities;

namespace Artpress.Infrastructure.Data.Configurations
{
    public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder.ToTable("UserClaims");

            builder.HasKey(uc => uc.Id);

            builder.Property(uc => uc.Id)
                .IsRequired();

            builder.Property(uc => uc.UserId)
                .IsRequired();

            builder.Property(uc => uc.ClaimType)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(uc => uc.ClaimValue)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(uc => uc.CreatedAt)
                .IsRequired();

            builder.Property(uc => uc.UpdatedAt);
        }
    }
}
