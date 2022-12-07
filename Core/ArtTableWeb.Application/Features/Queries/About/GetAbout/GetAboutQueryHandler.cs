using ArtTableWeb.Application.Repositories;
using ArtTableWeb.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Features.Queries.About.GetAbout
{
    public class GetAboutQueryHandler : IRequestHandler<GetAboutQueryRequest,List<GetAboutQueryResponse>>
    {
        IAboutReadRepository _AboutReadRepository;
        IMapper _mapper;

        public GetAboutQueryHandler(IAboutReadRepository aboutReadRepository, IMapper mapper)
        {
            _AboutReadRepository = aboutReadRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAboutQueryResponse>> Handle(GetAboutQueryRequest request, CancellationToken cancellationToken)
        {
            var abouts = _AboutReadRepository.GetAll();
            return abouts.Select(ab=> new GetAboutQueryResponse
            {
               AboutId=ab.Id.ToString(),
               Details= ab.Details,
               MapLocation=ab.MapLocation,
               Status=ab.Status,

            }).ToList();
           
            
        }
    }
}
