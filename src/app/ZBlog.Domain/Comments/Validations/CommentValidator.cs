using FluentValidation;

namespace ZBlog.Domain.Comments.Validations
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.FirstName).MinimumLength(2).NotNull().NotEmpty();
            RuleFor(x => x.LastName).MinimumLength(2).NotNull().NotEmpty();
            RuleFor(x => x.Message).MinimumLength(2).NotNull().NotEmpty();
        }
    }
}
