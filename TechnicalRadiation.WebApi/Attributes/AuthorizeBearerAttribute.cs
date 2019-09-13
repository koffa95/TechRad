using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace TechnicalRadiation.WebApi.Attributes
{
    public class AuthorizeBearerAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string AuthToken = "Bearer 2fc8813c-be65-4dba-8b91-6e73d928ed56";

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            StringValues token;
            context.HttpContext.Request.Headers.TryGetValue("Authorization", out token);
            if(token != AuthToken) { context.Result = new StatusCodeResult(401); }
        }
    }
}