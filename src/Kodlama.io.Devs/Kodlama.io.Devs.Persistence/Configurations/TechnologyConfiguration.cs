using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.Configurations
{
    public class TechnologyConfiguration : IEntityTypeConfiguration<Technology>
    {
        public void Configure(EntityTypeBuilder<Technology> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn();
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(15);
            builder.HasOne(x=>x.ProgrammingLanguage).WithMany(x=>x.Technologies).HasForeignKey(x=>x.ProgrammingLanguageId);
            builder.ToTable("Technologies");
        }
    }
}
