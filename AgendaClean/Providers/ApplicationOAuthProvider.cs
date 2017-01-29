using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Agenda.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            if (context.UserName == "klausner" && context.Password == "123456")
            {
                Claim claim1 = new Claim(ClaimTypes.Name, context.UserName);
                Claim[] claims = new Claim[] { claim1 };
                ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(
                       claims, OAuthDefaults.AuthenticationType);
                context.Validated(claimsIdentity);
            }
            return Task.FromResult<object>(null);
        }
    }
}