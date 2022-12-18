using DemoNeEkersen.API.Application.Activities.Queries.Response;
using MediatR;

namespace DemoNeEkersen.API.Application.Activities.Queries.Requests
{
    public class GetByIdActivityQueryRequest : IRequest<GetByIdActivityQueryResponse>
    {
        public Guid Id { get; set; }
    }

}
