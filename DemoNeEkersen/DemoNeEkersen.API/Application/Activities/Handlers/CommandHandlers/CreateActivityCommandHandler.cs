using DemoNeEkersen.API.Application.Activities.Commands.Requests;
using DemoNeEkersen.API.Application.Activities.Commands.Response;
using DemoNeEkersen.Data;
using DemoNeEkersen.Data.Entities;
using MediatR;

namespace DemoNeEkersen.API.Application.Activities.Handlers.CommandHandlers
{
    public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommandRequest, CreateActivityCommandResponse>
    {
        private PostgreSqlDemoDbContext _db;

        public CreateActivityCommandHandler(PostgreSqlDemoDbContext db) => _db = db;

        public async Task<CreateActivityCommandResponse> Handle(CreateActivityCommandRequest request, CancellationToken cancellationToken)
        {
            var activity = new Activity()
            {
                Category = request.Category,
                City = request.City,
                Date = request.Date,
                Description = request.Description,
                Title = request.Title,
                Venue = request.Venue
            };
            _db.Activities.Add(activity);

            await _db.SaveChangesAsync();

            return new CreateActivityCommandResponse
            {
                IsSuccess = true,
                ActivityId = activity.Id
            };

        }
    }
}
