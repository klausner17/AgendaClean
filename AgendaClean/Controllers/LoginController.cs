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
        public ActionResult Register(string login, string password, string confirmPassword)
        {
            password = Crypto.HashPassword(password);
            if (_rep.FindAll().Any(m => m.Login.Equals(login)))
            {
                return RedirectToAction("Login", "Login", new { @error = "Este login já está cadastrado. Por favor, tente outro login." });
            }
            if (!password.Equals(confirmPassword))
            {
                return RedirectToAction("Login", "Login", new { @error = "A confirmação da senha não corresponde com a senha digitada." });
            }
            UserModel user = new UserModel()
            {
                Login = login,
                Password = password
            };
            _rep.Add(user);
            return View();
            
        }
    }
}