using System;

namespace BlogSystem.Models.Common
{
    public class BlogSystemException : Exception
    {
        public BlogSystemException()
        {
        }

        public BlogSystemException(string message)
            : base(message)
        {
        }

        public BlogSystemException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}