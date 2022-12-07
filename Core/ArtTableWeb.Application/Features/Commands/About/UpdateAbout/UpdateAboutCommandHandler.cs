using ArtTableWeb.Application.Repositories;
using ArtTableWeb.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Features.Commands.About.UpdateAbout
{
    public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommandRequest, UpdateAboutCommandResponse>
    {
        readonly IAboutReadRepository _aboutReadRepository;
        readonly IAboutWriteRepository _aboutWriteRepository;

        public UpdateAboutCommandHandler(IAboutReadRepository aboutReadRepository, IAboutWriteRepository aboutWriteRepository)
        {
            _aboutReadRepository = aboutReadRepository;
            _aboutWriteRepository = aboutWriteRepository;
        }

        public async Task<UpdateAboutCommandResponse> Handle(UpdateAboutCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.About about = await _aboutReadRepository.GetByIdAsync(request.Id);

                about.Details = request.Details;
                about.MapLocation= request.MapLocation;
                await _aboutWriteRepository.SaveAsync();
                return new();

        }
    }
}
