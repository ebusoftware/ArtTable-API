using ArtTableWeb.Application.Rules.User;
using ArtTableWeb.Domain.Entities.Identity;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Features.Commands.User.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, DeleteUserCommandResponse>
    {
        UserManager<AppUser> _userManager;
        UserBusinessRules _userBusinessRules;

        public DeleteUserCommandHandler(UserManager<AppUser> userManager, UserBusinessRules userBusinessRules)
        {
            _userManager = userManager;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.UserShouldExistWhenRequested(request.Id);
            AppUser user = await _userManager.FindByIdAsync(request.Id);
            await _userManager.DeleteAsync(user);
            return new();
        }
    }
}
