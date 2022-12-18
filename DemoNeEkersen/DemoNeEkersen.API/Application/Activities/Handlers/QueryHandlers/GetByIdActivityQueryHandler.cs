using DemoNeEkersen.API.Application.Activities.Queries.Requests;
using DemoNeEkersen.API.Application.Activities.Queries.Response;
using DemoNeEkersen.Data;
using DemoNeEkersen.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DemoNeEkersen.API.Application.Activities.Handlers.QueryHandlers
{
    public class GetByIdActivityQueryHandler : IRequestHandler<GetByIdActivityQueryRequest, GetByIdActivityQueryResponse>
    {
        private PostgreSqlDemoDbContext _db;

        public GetByIdActivityQueryHandler(PostgreSqlDemoDbContext db) => _db = db;

        public async Task<GetByIdActivityQueryResponse> Handle(GetByIdActivityQueryRequest request, CancellationToken cancellationToken)
        {
            Activity activity = _db.Activities.FirstOrDefault(p => p.Id == request.Id);

            return new GetByIdActivityQueryResponse
            {
                Title = activity.Title,
                Category = activity.Category,
                City = activity.City,
                Date = activity.Date,
                Description = activity.Description,
                Venue = activity.Venue,
                Id = activity.Id
            };

        }
    }
}
