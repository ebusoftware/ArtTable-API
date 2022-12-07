using ArtTableWeb.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Features.Commands.About.DeleteAbout
{
    public class DeleteAboutCommandHandler : IRequestHandler<DeleteAboutCommandRequest, DeleteAboutCommandResponse>
    {
        readonly IAboutWriteRepository _aboutWriteRepository;

        public DeleteAboutCommandHandler(IAboutWriteRepository aboutWriteRepository)
        {
            _aboutWriteRepository = aboutWriteRepository;
        }

        public async Task<DeleteAboutCommandResponse> Handle(DeleteAboutCommandRequest request, CancellationToken cancellationToken)
        {
            await _aboutWriteRepository.RemoveAsync(request.Id);
            await _aboutWriteRepository.SaveAsync();
            return new();
        }
    }
}
