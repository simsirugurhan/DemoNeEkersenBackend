﻿using DemoNeEkersen.API.Application.Activities.Commands.Response;
using MediatR;

namespace DemoNeEkersen.API.Application.Activities.Commands.Requests
{
    public class CreateActivityCommandRequest : IRequest<CreateActivityCommandResponse>
    {
        public string? Title { get; set; }

        public DateTime Date { get; set; }

        public string? Description { get; set; }

        public string? Category { get; set; }

        public string? City { get; set; }

        public string? Venue { get; set; }
    }
}
