using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Features.Commands.About.DeleteAbout
{
    public class DeleteAboutCommandRequest:IRequest<DeleteAboutCommandResponse>
    {
        public string Id { get; set; }
    }
}
