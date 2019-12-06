using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Application.Errors
{
    public class APIException : Exception
    {
        public HttpStatusCode Code { get; }
        public object Errors { get; }

        public APIException(HttpStatusCode code, object errors = null)
        {
            Code = code;
            Errors = errors;
        }
    }
}
