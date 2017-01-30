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
    public class ContactApiController : ApiController
    {
        // GET api/<controller>/<action>/5
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            try
            {
                var repContact = new ContactRepository();
                var contact = repContact.Find(id);
                return Request.CreateResponse(HttpStatusCode.OK, contact);
            }
            catch(NullReferenceException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        //GET api/<controller>/<action>/ec5b8058-e848-46a9-b60e-3bff26c8e90d
        [HttpGet]
        public HttpResponseMessage GetByUserId(string id)
        {
            try
            {
                var repUser = new UserRepository();
                var contacts = repUser.Find(id).Contacts;
                return Request.CreateResponse(HttpStatusCode.OK, contacts);
            }
            catch (NullReferenceException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
        
        //PUT api/<controller>/<action>/produto
        [HttpPut]
        public HttpResponseMessage Add([FromBody]ContactModel contact)
        {
            try
            {
                var repContact = new ContactRepository();
                repContact.Add(contact);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (NullReferenceException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        //PUT api/<controller>/<action>/produto
        [HttpPut]
        public HttpResponseMessage Edit([FromBody]ContactModel contact)
        {
            try
            {
                var repContact = new ContactRepository();
                repContact.Update(contact);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (NullReferenceException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/<controller>/<action>/5
        [HttpPut]
        public HttpResponseMessage Delete([FromBody]ContactModel contact)
        {
            try
            {
                var repContact = new ContactRepository();
                repContact.Remove(repContact.Find(contact.Id));
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (NullReferenceException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}