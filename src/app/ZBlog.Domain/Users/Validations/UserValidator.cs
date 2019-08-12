using FluentValidation;

namespace ZBlog.Domain.Users.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName).MinimumLength(2).NotNull().NotEmpty();
            RuleFor(x => x.LastName).MinimumLength(2).NotNull().NotEmpty();
            RuleFor(x => x.MailAddress).EmailAddress().NotNull().WithMessage("Mail address is required").NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty().MinimumLength(6);
        }
    }
}
