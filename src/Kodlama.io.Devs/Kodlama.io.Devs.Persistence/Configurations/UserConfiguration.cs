using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).HasMaxLength(30).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
            builder.Property(x => x.AuthenticatorType).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.PasswordHash).IsRequired();
            builder.Property(x => x.PasswordSalt).IsRequired();
            builder.HasMany(x => x.UserOperationClaims);
            builder.HasMany(x => x.RefreshTokens);
            builder.ToTable("Users");
        }
    }
}
