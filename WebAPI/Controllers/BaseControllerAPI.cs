using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class BaseControllerAPI : ControllerBase
{
    private ISender _mediator = null!;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest<TResponse>
    {
        try
        {
            var result = await Mediator.Send(request);
            return Ok(new { Status = 200, Message = "Request processed successfully.", Result = result });
        }
        catch (Application.Common.Exceptions.ValidationException ex)
        {
            return BadRequest(new
            {
                Status = 400,
                Message = "Validation failed.",
                Errors = ex.Errors
            });
        }

        catch (FluentValidation.ValidationException ex)
        {
            var errors = ex.Errors.Select(e => e.ErrorMessage).ToList();
            return BadRequest(new { Status = 400, Message = "Validation failed.", Errors = errors });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { Status = 404, Message = $"Not Found: {ex.Message}" });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Status = 400, Message = $"Validation failed: {ex.Message}" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Status = 500, Message = $"Internal server error: {ex.Message}" });
        }
    }
}
