using FluentValidation;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.Create;

public class CreateProgrammingLanguageCommandValidator:AbstractValidator<ProgrammingLanguage>
{
    public CreateProgrammingLanguageCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Name).MinimumLength(2);
        RuleFor(x => x.Name).MaximumLength(30);
    }
}

//internal static class CustomValidator
//{
//    private static IRuleBuilderOptions<T, string> IsDuplicate<T>(this IRuleBuilder<T, string> ruleBuilder)
//    {
//        return ruleBuilder.Must(x=>x !=null);
//    }
//}