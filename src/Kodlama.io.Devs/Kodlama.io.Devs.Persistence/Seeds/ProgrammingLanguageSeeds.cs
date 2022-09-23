using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.Seeds;

public class ProgrammingLanguageSeeds : IEntityTypeConfiguration<ProgrammingLanguage>
{
    public void Configure(EntityTypeBuilder<ProgrammingLanguage> builder)
    {
        ProgrammingLanguage[] languages =
        {
            new(1,"C#"),
            new(2,"Java"),
            new(3,"JavaScript"),
            new(4,"Go")
        };
        builder.HasData(languages);
    }
}