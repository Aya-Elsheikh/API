using Application.Comman.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

public class SendOtpCommandAPI : IRequest<bool>
{
    public string Email { get; set; } = string.Empty;
}
public class SendOtpCommandAPIHandler : IRequestHandler<SendOtpCommandAPI, bool>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IEmailService _emailService;
    private readonly IPasswordHasher<ApplicationUser> _passwordHasher;

    public SendOtpCommandAPIHandler(
        UserManager<ApplicationUser> userManager,
        IEmailService emailService,
        IPasswordHasher<ApplicationUser> passwordHasher)
    {
        _userManager = userManager;
        _emailService = emailService;
        _passwordHasher = passwordHasher;
    }

    public async Task<bool> Handle(SendOtpCommandAPI request, CancellationToken cancellationToken)
    {
        var email = request.Email.Trim().ToLower();
        var otp = new Random().Next(100000, 999999).ToString(); 

        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            user = new ApplicationUser
            {
                Email = email,
                UserName = email,
                Active = false,
                EmailConfirmed = false
            };
            var createResult = await _userManager.CreateAsync(user);
            if (!createResult.Succeeded)
                throw new InvalidOperationException(string.Join(", ", createResult.Errors.Select(e => e.Description)));
        }

        user.Otp = _passwordHasher.HashPassword(user, otp);
        user.OtpExpiry = DateTime.UtcNow.AddMinutes(5);
        await _userManager.UpdateAsync(user);

        await _emailService.SendAsync(
            user.Email!,
            "كود التفعيل الخاص بك",
            $"كود التفعيل الخاص بك هو: {otp} (صالح لمدة 5 دقائق)"
        );

        return true;
    }
}

