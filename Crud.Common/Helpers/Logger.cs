using Crud.Models.GlobalModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Crud.Common.Helpers
{
    public class Logger
    {
        private IHostingEnvironment _hostingEnvironment;
        private IHttpContextAccessor _httpContextAccessor;

        public Logger(IHostingEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        public void Log(LogType logType, string message = "", Exception exception = null)
        {
            try
            {
                string logFolderName = logType.ToString().ToUpper();
                string logFileName = string.Join("_", logType.ToString(), DateTime.Now.ToLongDateString(), DateTime.Now.Ticks, ".txt");
                string fullFolderName = Path.Combine(_hostingEnvironment.WebRootPath, logFolderName).Replace("\\", "/");
                string fullFileName = Path.Combine(fullFolderName, logFileName).Replace("\\", "/");

                switch (logType)
                {
                    case LogType.Error:

                        if (exception != null)
                        {
                            Exception ex = exception;
                            message += ex.Message + "\n\nSatck Trace" + ex.StackTrace + "\n\nSource" + ex.Source;
                            message += "\nError occured on Page: " + _httpContextAccessor.HttpContext.Request.Path;

                            message += "\n\nHost: " + _httpContextAccessor.HttpContext.Request.Host.Host;
                            message += "\n\nRemote IP:" + _httpContextAccessor.HttpContext.Connection.RemoteIpAddress;

                            if (ex.InnerException != null)
                            {
                                message += "\n\nSatck Trace :" + ex.InnerException.StackTrace + ex.Source;
                            }
                        }

                        break;
                    case LogType.Warning:
                        break;
                    case LogType.Text:
                        break;
                    default:
                        break;
                }

                if (!Directory.Exists(fullFolderName))
                {
                    Directory.CreateDirectory(fullFolderName);
                }

                File.WriteAllText(fullFileName, message);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
