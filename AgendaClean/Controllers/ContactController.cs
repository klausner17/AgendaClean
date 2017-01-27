using AgendaClean.Models;
using AgendaClean.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agenda.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactRepository _rep = new ContactRepository();

        // GET: Contact
        public ActionResult Index()
        {
            var user = Session["userLogged"] as UserModel;
            return View(user.Contacts.ToList());
        }
    }
}