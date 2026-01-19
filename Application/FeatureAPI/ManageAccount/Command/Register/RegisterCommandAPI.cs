using Application.FeatureAPI.ManageAccount.Models;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

public class RegisterCommandAPI : IRequest<LoginResultDTO>
{
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
public class RegisterCommandHandler
    : IRequestHandler<RegisterCommandAPI, LoginResultDTO>
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public RegisterCommandHandler(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    public async Task<LoginResultDTO> Handle(
        RegisterCommandAPI request,
        CancellationToken cancellationToken)
    {
        var existingUser = await _userManager.FindByEmailAsync(request.Email);
        if (existingUser != null)
            throw new InvalidOperationException("المستخدم موجود بالفعل");

        var user = new ApplicationUser
        {
            UserName = request.Email,
            Email = request.Email,
            PhoneNumber = request.Phone,
            Active = true,
            Locked = false,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
            throw new InvalidOperationException(string.Join(", ", result.Errors.Select(e => e.Description)));

        var token = "JWT_TOKEN_HERE";

        return new LoginResultDTO
        {
            UserName = user.Email,
            Token = token,
            Expiration = DateTime.UtcNow.AddHours(2)
        };
    }
}