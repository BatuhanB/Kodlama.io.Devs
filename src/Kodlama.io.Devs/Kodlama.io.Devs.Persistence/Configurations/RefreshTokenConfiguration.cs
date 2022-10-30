using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.Configurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.UserId).IsRequired();
            builder.Property(x=>x.ReplacedByToken).IsRequired();
            builder.Property(x=>x.RevokedByIp).IsRequired();
            builder.Property(x=>x.Created).IsRequired();
            builder.Property(x=>x.CreatedByIp).IsRequired();
            builder.Property(x=>x.Expires).IsRequired();
            builder.Property(x=>x.ReasonRevoked).IsRequired();
            builder.Property(x=>x.Revoked).IsRequired();
            builder.Property(x=>x.Token).IsRequired();
            builder.HasOne(x=>x.User);
        }
    }
}
