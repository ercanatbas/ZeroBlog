using FluentValidation;
using Newtonsoft.Json;
using ZBlog.Domain.Posts.Base;

namespace ZBlog.Application.Posts.Request
{
    public class PostRequest : UpdateRequest
    {
        [JsonIgnore]
        public override int Id { get; set; }
    }
    public class PostRequestValidator : AbstractValidator<PostRequest>
    {
        public PostRequestValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.Title).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(x => x.Content).NotNull().NotEmpty().MinimumLength(2);
        }
    }


    public class UpdateRequest : PostBase
    {
        [JsonIgnore]
        public override int UserId { get; set; }
    }
    public class UpdateRequestValidator : AbstractValidator<UpdateRequest>
    {
        public UpdateRequestValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
            RuleFor(x => x.Title).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(x => x.Content).NotNull().NotEmpty().MinimumLength(2);
        }
    }

    public class PostSearchRequest
    {
        public string Search { get; set; }
    }

    public class PostSearchRequestValidator : AbstractValidator<PostSearchRequest>
    {
        public PostSearchRequestValidator()
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.Search).NotNull().NotEmpty().MinimumLength(2);
        }
    }
}
