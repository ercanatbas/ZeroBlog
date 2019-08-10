using System;
using System.Collections.Generic;

namespace ZBlog.Core.Extension
{
    public static class ListExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> body)
        {
            List<Exception> exceptions = null;
            foreach (var item in source)
            {
                try
                {
                    body(item);
                }
                catch (Exception exc)
                {
                    if (exceptions == null) exceptions = new List<Exception>();
                    exceptions.Add(exc);
                }
            }
            if (exceptions != null)
                throw new AggregateException(exceptions);
        }
    }
}
