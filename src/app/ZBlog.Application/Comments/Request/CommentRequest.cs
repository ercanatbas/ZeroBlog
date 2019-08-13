using FluentValidation;
using Newtonsoft.Json;
using ZBlog.Domain.Comments.Base;

namespace ZBlog.Application.Comments.Request
{
    public class CommentRequest : CommentBase
    {
        [JsonIgnore]
        public override int Id { get; set; }
    }

    public class CommentRequestValidator : AbstractValidator<CommentRequest>
    {
        public CommentRequestValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(x => x.LastName).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(x => x.Message).NotNull().NotEmpty().MinimumLength(2);
        }
    }

    public class UpdateCommentRequest : CommentBase
    {
    }

    public class UpdateCommentRequestValidator : AbstractValidator<UpdateCommentRequest>
    {
        public UpdateCommentRequestValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(x => x.LastName).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(x => x.Message).NotNull().NotEmpty().MinimumLength(2);
        }
    }
}
