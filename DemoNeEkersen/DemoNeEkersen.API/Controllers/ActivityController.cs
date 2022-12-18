using DemoNeEkersen.API.Application.Activities.Commands.Requests;
using DemoNeEkersen.API.Application.Activities.Commands.Response;
using DemoNeEkersen.API.Application.Activities.Queries;
using DemoNeEkersen.API.Application.Activities.Queries.Requests;
using DemoNeEkersen.API.Application.Activities.Queries.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoNeEkersen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private IMediator _mediator;

        public ActivityController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllActivityQueryRequest requestModel)
        {
            List<GetAllActivityQueryResponse> allProducts = await _mediator.Send(requestModel);
            return Ok(allProducts);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> Get([FromQuery] GetByIdActivityQueryRequest requestModel)
        {
            GetByIdActivityQueryResponse product = await _mediator.Send(requestModel);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateActivityCommandRequest requestModel)
        {
            CreateActivityCommandResponse response = await _mediator.Send(requestModel);
            return Ok(response);
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateActivityCommandRequest requestModel)
        {
            UpdateActivityCommandResponse response = await _mediator.Send(requestModel);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteActivityCommandRequest requestModel)
        {
            DeleteActivityCommandResponse response = await _mediator.Send(requestModel);
            return Ok(response);
        }

    }
}
