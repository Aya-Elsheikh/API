using Application.FeatureAPI.ManageAccount.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;

[ApiController]
public class AccountController : BaseControllerAPI
{
    #region Authentication

    [HttpPost("Login")]
    public Task<IActionResult> Login([FromBody] LoginCommandAPI command)
    {
        return HandleRequest<LoginCommandAPI, LoginResultDTO>(command);
    }

    [HttpPost("Register")]
    public Task<IActionResult> Register([FromBody] RegisterCommandAPI command)
    {
        return HandleRequest<RegisterCommandAPI, LoginResultDTO>(command);
    }

    #endregion
}
