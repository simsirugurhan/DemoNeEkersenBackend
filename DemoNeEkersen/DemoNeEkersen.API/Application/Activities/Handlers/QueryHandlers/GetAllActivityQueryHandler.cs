using DemoNeEkersen.API.Application.Activities.Queries.Requests;
using DemoNeEkersen.API.Application.Activities.Queries.Response;
using DemoNeEkersen.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DemoNeEkersen.API.Application.Activities.Handlers.QueryHandlers
{
    public class GetAllActivityQueryHandler : IRequestHandler<GetAllActivityQueryRequest, List<GetAllActivityQueryResponse>>
    {
        private PostgreSqlDemoDbContext _db;

        public GetAllActivityQueryHandler(PostgreSqlDemoDbContext db) => _db = db;

        public Task<List<GetAllActivityQueryResponse>> Handle(GetAllActivityQueryRequest request, CancellationToken cancellationToken)
        {
            return _db.Activities.Select(activity => new GetAllActivityQueryResponse
            {
                Id = activity.Id,
                Category = activity.Category,
                City = activity.City,
                Venue = activity.Venue,
                Date = activity.Date,
                Description = activity.Description,
                Title = activity.Title
            }).ToListAsync();
        }
    }
}
