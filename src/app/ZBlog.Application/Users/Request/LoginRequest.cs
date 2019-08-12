using FluentValidation;

namespace ZBlog.Application.Users.Request
{
    public class LoginRequest
    {
        public string MailAddress { get; set; }
        public string Password { get; set; }
    }
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.MailAddress).EmailAddress().NotNull().WithMessage("Mail address is required").NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty().MinimumLength(6);
        }
    }
}
