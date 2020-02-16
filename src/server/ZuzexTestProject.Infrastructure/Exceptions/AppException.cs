using System;
using System.Collections.Generic;
using System.Text;

namespace ZuzexTestProject.Infrastructure.Exceptions
{
    public class AppException : Exception
    {
        public ErrorCode ErrorCode { get; set; }

        public AppException(ErrorCode errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
