using Application.FeatureAPI.ManageAnalyze.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;

[ApiController]
[Route("api")]
public class AnalyzeController : BaseControllerAPI
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

    [HttpGet("CalculateCost")]
    public Task<IActionResult> CalculateCost([FromQuery] GetCalculateCostQueryAPI query)
    {
        return HandleRequest<GetCalculateCostQueryAPI, double>(query);
    }
}
