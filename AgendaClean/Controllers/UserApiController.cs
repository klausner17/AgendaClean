using AgendaClean.Models;
using AgendaClean.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Agenda.Controllers
{
    public class UserApiController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage VerifyUser(string login)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(login))
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Campo login está em branco.");
                var repUser = new UserRepository();
                var users = repUser.FindAll().Where(m => m.Login == login);
                if (users.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, true);
                else
                    return Request.CreateResponse(HttpStatusCode.OK, false);
            }
            catch (NullReferenceException)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Ocorreu algum erro" );
            }
        }

        [HttpPut]
        public HttpResponseMessage CreateUser([FromBody]UserModel user)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(user.Login) || string.IsNullOrWhiteSpace(user.Password))
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Campos login ou senha é inválido.");
                var rep = new UserRepository();
                var users = rep.FindAll();
                if (users.Where(m => m.Login == user.Login).Any())
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Já existe um usuário cadastrado com esse login.");
                rep.Add(user);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Ocorreu algum erro.");
            }
        }
    }
}
