using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api")]
public class ConceptController : ControllerBase
{
    private readonly IMediator _mediator;

    public ConceptController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("Concepts")]
    public async Task<IActionResult> GetConcepts()
    {
        return Ok(await _mediator.Send(new GetConceptsQuery()));
    }
}
