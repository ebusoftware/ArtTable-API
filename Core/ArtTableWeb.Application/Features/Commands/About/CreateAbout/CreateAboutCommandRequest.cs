using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Features.Commands.About.CreateAbout
{
    public class CreateAboutCommandRequest:IRequest<CreateAboutCommandResponse>
    {

        public string Details { get; set; }
        public string MapLocation { get; set; }
    }
}
