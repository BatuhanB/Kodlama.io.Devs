using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Constants;
using Kodlama.io.Devs.Application.Services.Repositories;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;

public class ProgrammingLanguageBusinessRules
{
    private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

    public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
    {
        _programmingLanguageRepository = programmingLanguageRepository;
    }

    public async Task ProgrammingLanguageCanNotBeDuplicatedWhenInserted(string name)
    {
        var result = await _programmingLanguageRepository.GetListAsync(x => x.Name == name);
        if (result.Items.Any()) throw new BusinessException(Messages.DuplicateNameError);
    }
}