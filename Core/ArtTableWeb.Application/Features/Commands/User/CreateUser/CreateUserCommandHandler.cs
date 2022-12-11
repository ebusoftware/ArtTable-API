using ArtTableWeb.Application.Dtos.User;
using ArtTableWeb.Application.Rules.User;
using ArtTableWeb.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Features.Commands.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly UserBusinessRules _userBusinessRules;
        readonly IUserService _userService;
        public CreateUserCommandHandler(IUserService userService, UserBusinessRules userBusinessRules)
        {
            _userService = userService;
            _userBusinessRules = userBusinessRules;
        }
        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.UserEmailCanNotBeDuplicatedWhenInserted(request.Email);
            CreateUserResponse response = await _userService.CreateAsync(new()
            {
                Email = request.Email,
                NameSurname = request.NameSurname,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm,
                Username = request.Username,
            });

            return new()
            {
                Message = response.Message,
                Succeeded = response.Succeeded,
            };
        }
    }
}
