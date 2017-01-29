using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Security.Claims;
using AgendaClean.Models;
using AgendaClean.Repository;
using System.Web.Helpers;

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
            
            if (!string.IsNullOrEmpty(context.UserName) && !string.IsNullOrEmpty(context.Password))
            {
                UserModel user = new UserModel()
                {
                    Login = context.UserName,
                    Password = context.Password
                };
                var userRegistred = new UserRepository().FindAll().Where(m => m.Login == context.UserName);
                if (userRegistred.Any() && Crypto.VerifyHashedPassword(userRegistred.FirstOrDefault().Password, context.Password))
                {
                    Claim claim1 = new Claim(ClaimTypes.Name, userRegistred.FirstOrDefault().Id);
                    Claim[] claims = new Claim[] { claim1 };
                    ClaimsIdentity claimsIdentity =
                        new ClaimsIdentity(
                           claims, OAuthDefaults.AuthenticationType);
                    context.Validated(claimsIdentity);
                }
            }
            return Task.FromResult<object>(null);
        }
    }
}