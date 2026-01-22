using Application.FeatureAPI.ManageAccount.Models;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

public class LoginCommandAPI : IRequest<LoginResultDTO>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class LoginCommandHandler : IRequestHandler<LoginCommandAPI, LoginResultDTO>
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public LoginCommandHandler(
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<LoginResultDTO> Handle(
        LoginCommandAPI request,
        CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
            throw new KeyNotFoundException("البريد الإلكتروني أو كلمة المرور غير صحيحة");

        if (!user.Active)
            throw new UnauthorizedAccessException("الحساب غير مفعل");
        if (user.Locked)
            throw new UnauthorizedAccessException("الحساب مقفل");
        if (!user.EmailConfirmed)
            throw new UnauthorizedAccessException("البريد الإلكتروني لم يتم تأكيده");

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: false);
        if (!result.Succeeded)
            throw new UnauthorizedAccessException("البريد الإلكتروني أو كلمة المرور غير صحيحة");

        var token = "JWT_TOKEN_HERE";

        return new LoginResultDTO
        {
            Name = user.Name,
            UserName = user.UserName,
            Token = token,
            Expiration = DateTime.UtcNow.AddHours(2)
        };
    }
}
