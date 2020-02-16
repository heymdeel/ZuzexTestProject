using System;
using System.Collections.Generic;
using System.Text;

namespace ZuzexTestProject.Infrastructure.Exceptions
{
    public class BadInputException : AppException
    {
        public BadInputException(ErrorCode errorCode, string message) : base(errorCode, message) { }
    }
}
