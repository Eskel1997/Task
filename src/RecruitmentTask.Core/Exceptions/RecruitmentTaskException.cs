using System;

namespace RecruitmentTask.Core.Exceptions
{
    public class RecruitmentTaskException : Exception
    {
        public ErrorCode ErrorCode {get;}
        public RecruitmentTaskException(ErrorCode errorCode)
            : this(errorCode, string.Empty) { }
        public RecruitmentTaskException(ErrorCode errorCode, string message) : base(message, null)
        {
            ErrorCode = errorCode;
        }
        public RecruitmentTaskException(ErrorCode errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }

    }
}
