using System;
using System.Collections.Generic;
using System.Text;

namespace ZBlog.Core.Authentication
{
    public class TokenUser : ITokenUser
    {
        public int Id { get; private set; }
        public string Subject { get; private set; }
        public string Audience { get; private set; }
        public string UniqueName { get; private set; }
        public TokenUser(int id, string subject, string audience, string uniqueName)
        {
            Id = id;
            Subject = subject;
            Audience = audience;
            UniqueName = uniqueName;
        }
    }
}
