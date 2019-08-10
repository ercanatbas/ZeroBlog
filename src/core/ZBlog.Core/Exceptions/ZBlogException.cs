using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZBlog.Core.Exceptions
{
    [Serializable]
    public class ZBLogException : Exception
    {
        public int StatusCode { get; }
        public Dictionary<string, string> Parameters { get; } = new Dictionary<string, string>();

        public ZBLogException(int statusCode, string message, Exception innerException = null) : base(message, innerException)
        {
            StatusCode = statusCode;
        }
        protected ZBLogException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            StatusCode = info.GetInt32("StatusCode");
            //Parameters
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));
            info.AddValue("StatusCode", StatusCode);
            info.AddValue("Parameters", Parameters);
            base.GetObjectData(info, context);
        }
    }
}
