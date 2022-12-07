using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Features.Queries.About.GetAbout
{
    public class GetAboutQueryRequest:IRequest<List<GetAboutQueryResponse>>
    {
        
    }
}
