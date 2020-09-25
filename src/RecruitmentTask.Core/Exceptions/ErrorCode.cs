using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace RecruitmentTask.Core.Exceptions
{
    public class ErrorCode
    {
        public string Message { get; protected set; }
        public HttpStatusCode StatusCode { get; protected set; }
        public ErrorCode(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            Message = message;
            StatusCode = statusCode;
        }

        public static ErrorCode DatabaseSavingException => new ErrorCode(nameof(DatabaseSavingException), HttpStatusCode.InternalServerError);
        public static ErrorCode CompanyNotExist => new ErrorCode(nameof(CompanyNotExist), HttpStatusCode.NotFound);
        public static ErrorCode Unauthorized => new ErrorCode(nameof(Unauthorized), HttpStatusCode.Unauthorized);
    }
}
