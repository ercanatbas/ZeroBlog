using FluentValidation;
using FluentValidation.Results;
using System;
using ZBlog.Core.Exceptions;

namespace ZBlog.Core.Entity
{
    public static class EntityExtensions
    {
        public static ValidationResult Validate<TValidator, TModel>(this TModel model, bool throwError = true) where TValidator : IValidator
        {
            var result = Activator.CreateInstance<TValidator>().Validate(model);
            if (!result.IsValid && throwError)
                throw new NotValidatedException(result);
            return result;
        }
    }
}
