using Crud.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Common.Helpers
{
    public static class ProblemReporter
    {
        public static void ReportAuthenticationFail(string message = null)
        {
            throw (message == null ? (new HttpException(401, "Unauthorized: Access is denied due to invalid credentials")) : (new HttpException(401, message)));
        }

        public static void ReportUnauthorizedAccess(string message = null)
        {
            throw (message == null ? (new HttpException(403, "Attempted to perform an unauthorized operation")) : (new HttpException(403, message)));
        }

        public static void ReportResourseNotfound(string message = null)
        {
            throw (message == null ? (new HttpException(404, "Resource not found")) : (new HttpException(404, message)));
        }

        public static void ReportBadRequest(string message = null)
        {
            throw (message == null ? (new HttpException(400, "Invalid data")) : (new HttpException(400, message)));
        }

        public static void ReportServiceUnavelable(string message = null)
        {
            throw (message == null ? (new HttpException(503, "Problem occured: Internal Server Error")) : (new HttpException(503, message)));
        }

        public static void ReportInternalServerError(string message = null)
        {
            throw (message == null ? (new HttpException(500, "Problem occured: Internal Server Error")) : (new HttpException(500, message)));
        }
    }
}
