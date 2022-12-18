using DemoNeEkersen.API.Application.Activities.Commands.Requests;
using DemoNeEkersen.API.Application.Activities.Commands.Response;
using DemoNeEkersen.Data;
using MediatR;

namespace DemoNeEkersen.API.Application.Activities.Handlers.CommandHandlers
{
    public class DeleteActivityCommandHandler : IRequestHandler<DeleteActivityCommandRequest, DeleteActivityCommandResponse>
    {
        private PostgreSqlDemoDbContext _db;

        public DeleteActivityCommandHandler(PostgreSqlDemoDbContext db) => _db = db;

        public async Task<DeleteActivityCommandResponse> Handle(DeleteActivityCommandRequest request, CancellationToken cancellationToken)
        {
            var activity = _db.Activities.FirstOrDefault(p => p.Id == request.Id);
            this._db.Activities.Remove(activity);

            await _db.SaveChangesAsync();

            return new DeleteActivityCommandResponse
            {
                IsSuccess = true,
                ActivityId = activity.Id
            };
        }
    }
}
