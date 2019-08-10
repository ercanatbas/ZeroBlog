using System;
using System.Runtime.Serialization;
using FluentValidation.Results;

namespace ZBlog.Core.Exceptions
{
    [Serializable]
    public class NotValidatedException : ZBLogException
    {
        public ValidationResult ValidationResult { get; }

        public NotValidatedException(ValidationResult validationResult) : base(400, null)
        {
            ValidationResult = validationResult;
        }

        protected NotValidatedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
    [Serializable]
    public class ParameterValueCannotBeZeroException : ZBLogException
    {
        public ParameterValueCannotBeZeroException(string parameterName) : base(400, "'{@parameterName}' can not be zero") { Parameters.Add("@parameterName", parameterName); }

        protected ParameterValueCannotBeZeroException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
    [Serializable]
    public class ParameterCannotBeNullOrEmptyException : ZBLogException
    {
        public ParameterCannotBeNullOrEmptyException(string parameterName) : base(400, "{@parameterName} can not be null or empty!") { Parameters.Add("@parameterName", parameterName); }

        protected ParameterCannotBeNullOrEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
    [Serializable]
    public class ParameterValueGreaterThanZeroException : ZBLogException
    {
        public ParameterValueGreaterThanZeroException(string parameterName) : base(400, "{@parameterName} should be greater than zero!") { Parameters.Add("@parameterName", parameterName); }

        protected ParameterValueGreaterThanZeroException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
    [Serializable]
    public class ParameterValueGreaterThanContractDateException : ZBLogException
    {
        public ParameterValueGreaterThanContractDateException(string parameterName) : base(400, "{@parameterName} should be greater than contract date!") { Parameters.Add("@parameterName", parameterName); }

        protected ParameterValueGreaterThanContractDateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
