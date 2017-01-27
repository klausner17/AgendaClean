using Agenda.Controllers;
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
            if (Session["userLogged"] != null)
            {
                return RedirectToAction(nameof(ContactController.Index), "Contact");
            }
            return View();
        }

        //POST: Register
        public ActionResult Register(string login, string password, string confirmPassword)
        {
            if (_rep.FindAll().Any(m => m.Login.Equals(login)))
            {
                return RedirectToAction(nameof(Login), new { @error = "Este login já está cadastrado. Por favor, tente outro login." });
            }
            if (!password.Equals(confirmPassword))
            {
                return RedirectToAction(nameof(Login), new { @error = "A confirmação da senha não corresponde com a senha digitada." });
            }
            var user = new UserModel()
            {
                Login = login,
                Password = Crypto.HashPassword(password)
            };
            _rep.Add(user);
            Session["userLogged"] = user;
            return RedirectToAction(nameof(ContactController.Index), nameof(ContactController));
            
        }

        //POST: ConfirmLogin
        public ActionResult ConfirmLogin(string login, string password)
        {
            var userReqLogin = new UserModel()
            {
                Login = login,
                Password = password
            };
            var userMatched = _rep.FindAll().Where(m => m.Login == login);
            if (userMatched.Any())
            {
                var userFound = userMatched.FirstOrDefault();
                if (Crypto.VerifyHashedPassword(userFound.Password, password))
                {
                    Session["userLogged"] = userFound;
                    return RedirectToAction(nameof(ContactController.Index), "Contact");

                }
                else
                {
                    return RedirectToAction(nameof(Login), new { @error = "Senha inválida." });
                }
            }
            else
            {
                return RedirectToAction(nameof(Login), new { @error = "Usuário não encontrado." });
            }
        }

    }
}