using System;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RecipeApplication
{
    /// <summary>
    /// NOTE: This attribute is for demonstration purposes only - you should use the 
    /// ASP.NET Core authorization framework and policies instead, as described in chapters
    /// 14 and 15 of ASP.NET Core in Action
    /// </summary>
    public class RequireIpAddressAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IPAddress[] _allowedAddress =
        {
            IPAddress.Parse("127.0.0.1"),
            IPAddress.Parse("::1"),
        };

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var ipAddress = context.HttpContext.Connection.RemoteIpAddress;
            if(!_allowedAddress.Contains(ipAddress))
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
