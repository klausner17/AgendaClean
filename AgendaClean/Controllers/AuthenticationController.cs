﻿using Microsoft.Owin.Security;
using System.Web;
using System.Web.Http;

namespace Agenda.Controllers
{
    public class AuthenticationController : ApiController
    {
        private IAuthenticationManager Authentication
        {
            get { return HttpContext.Current.GetOwinContext().Authentication; }
        }

        // GET api/me
        // A tag Authorize obriga estar autenticado para acessar o mesmo
        [Authorize]
        public string Get()
        {
            return this.Authentication.User.Identity.Name;
        }
    }
}