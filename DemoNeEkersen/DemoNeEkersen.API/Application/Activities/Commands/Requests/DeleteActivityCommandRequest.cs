using DemoNeEkersen.API.Application.Activities.Commands.Response;
using MediatR;

namespace DemoNeEkersen.API.Application.Activities.Commands.Requests
{
    public class DeleteActivityCommandRequest : IRequest<DeleteActivityCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
