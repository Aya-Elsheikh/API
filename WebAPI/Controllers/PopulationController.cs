using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api")]
public class PopulationController : ControllerBase
{
    //private readonly IMediator _mediator;

    //public PopulationController(IMediator mediator)
    //{
    //    _mediator = mediator;
    //}

    //[HttpGet("Populations")]
    //public async Task<IActionResult> GetPopulations()
    //{
    //    return Ok(await _mediator.Send(new GetPopulationsQuery()));
    //}
}
