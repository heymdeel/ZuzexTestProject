using System;
using System.Collections.Generic;
using System.Text;

namespace ZuzexTestProject.Infrastructure.Exceptions
{
    public class NotFoundException : AppException
    {
        public NotFoundException(ErrorCode errorCode, string message) : base(errorCode, message) { }
    }
}
