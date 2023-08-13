using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

// code taken from: https://blog.elmah.io/error-logging-middleware-in-aspnetcore/

namespace YourCellarSyncServer.Helper
{
    public class ErrorLoggingMiddleware {

        private readonly RequestDelegate _next;

        public ErrorLoggingMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task Invoke(HttpContext context) {
            try {
                await _next(context);
            } catch (Exception e) {
                Logger.Exception(e, "Error found by middleware.");
                throw;
            }
        }
    }
}
