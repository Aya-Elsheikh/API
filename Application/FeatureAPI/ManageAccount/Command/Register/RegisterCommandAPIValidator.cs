using FluentValidation;

namespace Application.FeatureAPI.ManageAccount.Command.Register
{
    internal class RegisterCommandAPIValidator : AbstractValidator<RegisterCommandAPI>
    {
        public RegisterCommandAPIValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("البريد الإلكتروني مطلوب")
                .EmailAddress().WithMessage("البريد الإلكتروني غير صالح");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("رقم الهاتف مطلوب")
                .Matches(@"^\+?\d{9,15}$").WithMessage("رقم الهاتف غير صالح");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("كلمة المرور مطلوبة")
                .MinimumLength(6).WithMessage("كلمة المرور يجب أن تكون 6 أحرف على الأقل");
        }
    }
}
