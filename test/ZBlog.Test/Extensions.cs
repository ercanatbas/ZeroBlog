using System.Collections.Generic;

namespace ZBlog.Test
{
    public static class Extensions
    {
        public static List<T> ToList<T>(this T obj)
        {
            return new List<T> { obj };
        }
    }
}
