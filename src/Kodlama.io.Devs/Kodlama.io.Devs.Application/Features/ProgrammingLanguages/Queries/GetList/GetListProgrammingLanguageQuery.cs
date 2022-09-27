using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetList
{
    public class GetListProgrammingLanguageQuery:IRequest<ProgrammingLanguageListModel>
    {
        public PageRequest PageRequest { get; set; }
    }
}
