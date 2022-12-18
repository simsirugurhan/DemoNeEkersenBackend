using DemoNeEkersen.API.Application.Activities.Queries.Response;
using DemoNeEkersen.Data.Entities;
using MediatR;

namespace DemoNeEkersen.API.Application.Activities.Queries.Requests
{
    public class GetAllActivityQueryRequest : IRequest<List<GetAllActivityQueryResponse>>
    {
    }
}
