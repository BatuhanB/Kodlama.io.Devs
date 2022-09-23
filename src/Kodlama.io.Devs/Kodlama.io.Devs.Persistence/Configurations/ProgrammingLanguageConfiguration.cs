using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.Configurations;

public class ProgrammingLanguageConfiguration:IEntityTypeConfiguration<ProgrammingLanguage>
{
    public void Configure(EntityTypeBuilder<ProgrammingLanguage> builder)
    {
        builder.HasKey(x=>x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.ToTable("ProgrammingLanguages");
    }
}