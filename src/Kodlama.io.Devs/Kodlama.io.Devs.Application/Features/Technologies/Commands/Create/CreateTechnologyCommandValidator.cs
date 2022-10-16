using FluentValidation;

namespace Kodlama.io.Devs.Application.Features.Technologies.Commands.Create
{
    public class CreateTechnologyCommandValidator:AbstractValidator<CreateTechnologyCommand>
    {
        public CreateTechnologyCommandValidator()
        {
            RuleFor(x=>x.Name).NotEmpty();
            RuleFor(x=>x.Name).MinimumLength(1);
            RuleFor(x=>x.Name).MaximumLength(15);
        }
    }
}
