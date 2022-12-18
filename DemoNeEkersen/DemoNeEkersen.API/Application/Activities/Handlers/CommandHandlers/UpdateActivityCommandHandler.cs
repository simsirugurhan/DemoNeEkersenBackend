using DemoNeEkersen.API.Application.Activities.Commands.Requests;
using DemoNeEkersen.API.Application.Activities.Commands.Response;
using DemoNeEkersen.Data;
using MediatR;

namespace DemoNeEkersen.API.Application.Activities.Handlers.CommandHandlers
{
    public class UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommandRequest, UpdateActivityCommandResponse>
    {
        private PostgreSqlDemoDbContext _db;

        public UpdateActivityCommandHandler(PostgreSqlDemoDbContext db) => _db = db;

        public async Task<UpdateActivityCommandResponse> Handle(UpdateActivityCommandRequest request, CancellationToken cancellationToken)
        {
            var updateActivity = this._db.Activities.FirstOrDefault(p => p.Id == request.Id);
            updateActivity.Title = request.Title;
            updateActivity.Description = request.Description;
            updateActivity.City = request.City;
            updateActivity.Venue = request.Venue;
            updateActivity.Category = request.Category;
            updateActivity.Date = request.Date;

            await this._db.SaveChangesAsync();

            return new UpdateActivityCommandResponse
            {
                IsSuccess = true,
                ActivityId = updateActivity.Id
            };
        }
    }
}
