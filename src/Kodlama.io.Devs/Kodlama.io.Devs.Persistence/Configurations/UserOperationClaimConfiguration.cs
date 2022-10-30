using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.Configurations
{
    public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.UserId).IsRequired();
            builder.Property(x=>x.OperationClaimId).IsRequired();
            builder.HasOne(x=>x.OperationClaim);
            builder.HasOne(x=>x.User);
            builder.ToTable("UserOperationClaims");
        }
    }
}
