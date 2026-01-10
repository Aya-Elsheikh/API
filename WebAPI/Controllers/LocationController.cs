using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api")]
public class LocationController : ControllerBase
{
    private readonly IMediator _mediator;

    public LocationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("Locations")]
    public async Task<IActionResult> GetEmirates()
    {
        return Ok(await _mediator.Send(new GetEmiratesQuery()));
    }
}
