﻿using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Technologies.Dtos;

namespace Kodlama.io.Devs.Application.Features.Technologies.Models
{
    public class TechnologyListModel:BasePageableModel
    {
        public IList<TechnologyListDto>? Items {get; set; }
    }
}
