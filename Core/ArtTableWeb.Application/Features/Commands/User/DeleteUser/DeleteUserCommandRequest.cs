using ArtTableWeb.Domain.Entities.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Features.Commands.User.DeleteUser
{
    public class DeleteUserCommandRequest:IRequest<DeleteUserCommandResponse>
    {
        public string Id { get; set; }
    }
}
