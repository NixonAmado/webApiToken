using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace API.Helpers
{
    public class GlobalVerbRoleHandler : AuthorizationHandler<GlobalVerbRoleRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GlobalVerbRoleHandler(IHttpContextAccessor httpContextAccessor)
        {
           this._httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, GlobalVerbRoleRequirement requirement)
        {
            var rols = context.User.FindAll(c => string.Equals(c.Type,ClaimTypes.Role)).Select(c => c.Value);
            var verb = _httpContextAccessor.HttpContext.Request.Method;
            if (string.IsNullOrEmpty(verb)) { throw new Exception("Request can't be null");}
            foreach (var rol in rols)
            {
                if (requirement.IsAllowed(rol, verb))
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }
            context.Fail();
            return Task.CompletedTask;

        }
    }
}