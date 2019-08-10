using System;

namespace ZBlog.Core.Services
{
    public class ServiceError : IServiceError
    {
        public string Code { get; private set; }
        public string Description { get; private set; }
        public string Message { get; private set; }
        public Exception Exception { get; private set; }

        public ServiceError(string code, string description, Exception exception = null, string message = null)
        {
            Code = code;
            Description = description;
            Exception = exception;
            Message = message;
        }
    }
}
