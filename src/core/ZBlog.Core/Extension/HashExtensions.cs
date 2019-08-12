using System;
using System.Security.Cryptography;
using System.Text;

namespace ZBlog.Core.Extension
{
    public static class HashExtensions
    {
        public static string ToSha256(this string text)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}
