using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Features.Technologies.Constants;
using Kodlama.io.Devs.Application.Services.Repositories;

namespace Kodlama.io.Devs.Application.Features.Technologies.Rules
{
    public class TechnologyBusinessRules
    {
        private readonly ITechnologyRepository _technologyRepository;

        public TechnologyBusinessRules(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        public async Task TechnologyCanNotBeDuplicatedWhenInserted(string name)
        {
            var result = await _technologyRepository.GetListAsync(x => x.Name == name);
            if (result.Items.Any()) throw new BusinessException(TechnologyMessages.DuplicateNameError);
        }

        public async Task TechnologyShouldExistWhenRequested(int id)
        {
            var result = await _technologyRepository.GetAsync(x => x.Id == id);
            if (result == null) throw new BusinessException(TechnologyMessages.RequestedIdShouldExistError);
        }
    }
}
