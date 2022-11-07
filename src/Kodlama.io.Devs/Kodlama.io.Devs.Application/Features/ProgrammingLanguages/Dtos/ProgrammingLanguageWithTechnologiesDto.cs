using Kodlama.io.Devs.Application.Features.Technologies.Dtos;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos
{
    public class ProgrammingLanguageWithTechnologiesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TechnologyForProgrammingLanguageDto> Technologies { get; set; }
    }
}
