using System.Collections.Generic;

namespace ZBlog.Core.Services.Result
{
    public class ServiceResult : ServiceResult<int>
    {
        public ServiceResult(IServiceError serviceError, int code) : base(new List<IServiceError> { serviceError }, code)
        {
        }

        public ServiceResult(List<IServiceError> serviceErrors, int code) : base(serviceErrors, code)
        {
        }
    }

    public class ServiceResult<TResult> : ServiceResultBase<TResult>
    {
        public ServiceResult(List<IServiceError> serviceError, int code)
        {
            Errors.AddRange(serviceError);
            Code = code;
        }
    }
}
