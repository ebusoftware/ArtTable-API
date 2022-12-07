using ArtTableWeb.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Features.Commands.About.CreateAbout
{
    public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommandRequest, CreateAboutCommandResponse>
    {
        readonly IAboutWriteRepository _aboutWriteRepository;

        public CreateAboutCommandHandler(IAboutWriteRepository aboutWriteRepository)
        {
            _aboutWriteRepository = aboutWriteRepository;
        }

        public async Task<CreateAboutCommandResponse> Handle(CreateAboutCommandRequest request, CancellationToken cancellationToken)
        {
            
            await  _aboutWriteRepository.AddAsync(new() 
            {
                Details= request.Details,
                MapLocation= request.MapLocation,
            });
            await _aboutWriteRepository.SaveAsync();
            return new();
        }
    }
}
