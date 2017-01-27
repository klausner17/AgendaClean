using AgendaClean.Models;
using AgendaClean.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AgendaClean.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserRepository _rep = new UserRepository();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        //POST: Register
        public void Register(string login, string password)
        {
            password = Crypto.HashPassword(password);
            UserModel user = new UserModel()
            {
                Login = login,
                Password = password
            };
            _rep.Add(user);
            
        }
    }
}