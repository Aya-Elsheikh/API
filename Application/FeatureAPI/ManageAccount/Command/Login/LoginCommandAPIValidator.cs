using FluentValidation;

public class LoginCommandAPIValidator : AbstractValidator<LoginCommandAPI>
{
    public LoginCommandAPIValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("البريد الإلكتروني مطلوب");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("كلمة المرور مطلوبة")
            .MinimumLength(6)
            .WithMessage("كلمة المرور يجب أن تكون 6 أحرف على الأقل");
    }
}
