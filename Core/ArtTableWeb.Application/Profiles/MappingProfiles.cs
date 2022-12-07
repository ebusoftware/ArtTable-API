using ArtTableWeb.Application.Features.Queries.About.GetAbout;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.About, GetAboutQueryResponse>().ReverseMap();
            CreateMap<Domain.Entities.About, GetAboutQueryRequest>().ReverseMap();
        }
    }
}
