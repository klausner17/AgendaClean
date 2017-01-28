using AgendaClean.Models;
using AgendaClean.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Web.Http.Results;

namespace Agenda.Controllers
{
    public class ContactController : ApiController
    {
        // GET api/<controller>/<action>/5
        public object Get(string id)
        {
            try
            {
                var repContact = new ContactRepository();
                var contact = repContact.Find(id);
                return contact;
            }
            catch(NullReferenceException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        //GET api/<controller>/<action>/ec5b8058-e848-46a9-b60e-3bff26c8e90d
        public object GetByUserId(string id)
        {
            try
            {
                var repUser = new UserRepository();
                var contacts = repUser.Find(id).Contacts;
                return contacts;
            }
            catch (NullReferenceException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}