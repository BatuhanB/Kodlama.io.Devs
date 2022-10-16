using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.Create;

public class CreateProgrammingLanguageCommandValidator:AbstractValidator<CreateProgrammingLanguageCommand>
{
    public CreateProgrammingLanguageCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Name).MinimumLength(2);
        RuleFor(x => x.Name).MaximumLength(30);
    }
}
