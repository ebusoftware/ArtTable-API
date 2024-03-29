﻿using ArtTableWeb.Application.Features.Commands.User.CreateUser;
using ArtTableWeb.Application.Features.Commands.User.DeleteUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArtTableWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(DeleteUserCommandRequest deleteUserCommandRequest)
        {
            DeleteUserCommandResponse response = await _mediator.Send(deleteUserCommandRequest);
            return Ok(response);
        }

    }
}
