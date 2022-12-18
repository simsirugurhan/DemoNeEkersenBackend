namespace DemoNeEkersen.API.Application.Activities.Commands.Response
{
    public class DeleteActivityCommandResponse
    {
        public bool IsSuccess { get; set; }
        public Guid ActivityId { get; set; }
    }
}
