using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Features.Commands.About.UpdateAbout
{
    public class UpdateAboutCommandRequest:IRequest<UpdateAboutCommandResponse>
    {
        public string Id { get; set; }
        public string Details { get; set; }
        public string MapLocation { get; set; }
    }
}
