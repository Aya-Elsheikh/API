using Application.Comman.Interfaces;
using Application.FeatureAPI.ManageAccount.Models;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

public class VerifyOtpCommandAPI : IRequest<LoginResultDTO>
{
    public string Email { get; set; } = string.Empty;
    public string Otp { get; set; } = string.Empty;
}
public class VerifyOtpCommandAPIHandler : IRequestHandler<VerifyOtpCommandAPI, LoginResultDTO>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IJwtService _jwtService;
    private readonly IPasswordHasher<ApplicationUser> _passwordHasher;

    public VerifyOtpCommandAPIHandler(
        UserManager<ApplicationUser> userManager,
        IJwtService jwtService,
        IPasswordHasher<ApplicationUser> passwordHasher)
    {
        _userManager = userManager;
        _jwtService = jwtService;
        _passwordHasher = passwordHasher;
    }

    public async Task<LoginResultDTO> Handle(VerifyOtpCommandAPI request, CancellationToken cancellationToken)
    {
        var email = request.Email.Trim().ToLower();
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            throw new InvalidOperationException("المستخدم غير موجود");

        if (user.OtpExpiry < DateTime.UtcNow)
            throw new InvalidOperationException("OTP منتهي");

        var verify = _passwordHasher.VerifyHashedPassword(user, user.Otp!, request.Otp);
        if (verify != PasswordVerificationResult.Success)
            throw new InvalidOperationException("OTP غير صحيح");

        user.Active = true;
        user.EmailConfirmed = true;
        user.Otp = null;
        user.OtpExpiry = null;
        await _userManager.UpdateAsync(user);

        var token = _jwtService.GenerateToken(user.Id,user.Email ?? "","","Otp");

        return new LoginResultDTO
        {
            UserId = user.Id,
            Email = user.Email ?? "",
            Token = token,
            Expiration = DateTime.UtcNow.AddHours(2)
        };
    }
}
