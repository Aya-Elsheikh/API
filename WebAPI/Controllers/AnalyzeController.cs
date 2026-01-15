using Application.FeatureAPI.ManageAnalyze.Queries.GetAll;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;

[ApiController]
public class AnalyzeController : BaseControllerAPI
{
    //[HttpPost("Analyze")]
    //public async Task<IActionResult> Analyze(AnalyzeLocationCommand command)
    //{
    //    var result = await _mediator.Send(command);
    //    return Ok(result);
    //}

    [HttpGet("Analyze")]
    public Task<IActionResult> Analyze([FromQuery] GetCalculateCostQueryAPI query)
    {
        return HandleRequest<GetCalculateCostQueryAPI, AnalyzeResultDTO>(query);
    }
}
