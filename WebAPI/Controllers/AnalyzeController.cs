using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api")]
public class AnalyzeController : ControllerBase
{
    private readonly IMediator _mediator;

    public AnalyzeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Analyze")]
    public async Task<IActionResult> Analyze(AnalyzeLocationCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
