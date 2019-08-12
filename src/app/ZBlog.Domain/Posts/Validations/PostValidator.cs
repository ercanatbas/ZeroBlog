using FluentValidation;

namespace ZBlog.Domain.Posts.Validations
{
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(x => x.Title).MinimumLength(2).NotNull().NotEmpty();
            RuleFor(x => x.Content).MinimumLength(2).NotNull().NotEmpty();
        }
    }
}
