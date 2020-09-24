using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitmentTask.Core.Exceptions
{
    public class RecruitmentTaskException : Exception
    {
        public ErrorCode ErrorCode {get; set;}
        public RecruitmentTaskException(ErrorCode errorCode)
            : this(errorCode, string.Empty) { }
        public RecruitmentTaskException(ErrorCode errorCode, string message) : base(message, null)
        {
            ErrorCode = errorCode;
        }

    }
}
