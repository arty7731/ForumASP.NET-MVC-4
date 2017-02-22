using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using ForumMVC4ForGeeksForLess.Models;
using ForumMVC4ForGeeksForLess.Domain.Abstract;
using ForumMVC4ForGeeksForLess.Domain.Entities;
using ForumMVC4ForGeeksForLess.Domain.Concreate;
using ForumMVC4ForGeeksForLess.Domain;

namespace ForumMVC4ForGeeksForLess.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private IForumRepository repository;
        public AccountController(IForumRepository repo)
        {
            repository = repo;
        }

        // Authorization
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModelView model)
        {
            if (ModelState.IsValid)
            {
                if (ValidateUser(model.Login, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Login, model.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("ValidationError", "Incorect login or password");
                }
            }
            return View(model);
        }


        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //Registration
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(RegistrationModelView model)
        {
            if (ModelState.IsValid)
            {
                byte[] uploadedFile = new byte[model.Avatar.InputStream.Length];
                model.Avatar.InputStream.Read(uploadedFile, 0, uploadedFile.Length);

                if (Registration(model.Login, model.Nickname, model.Password, uploadedFile))
                {
                    FormsAuthentication.SetAuthCookie(model.Login, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("loginBusy", "Login busy!");
                    return View(model);
                }
            }
            ModelState.AddModelError("loginBusy", "Login busy!");
            return View(model);
        }

        private bool Registration(string login, string nickname, string password, byte[] avatar)
        {
            bool isRegistration = false;

            if(repository.Users.Any(u => u.Login == login))
            {

            }
            else
            {
                try
                {
                    User user = new User()
                    {
                        Login = login,
                        Nickname = nickname,
                        Password = password,
                        Avatar = avatar
                    };
                    repository.CreateUser(user);
                    isRegistration = true;
                }
                catch
                {
                    return false;   
                }
            }

            
            return isRegistration;
        }
        private bool ValidateUser(string login, string password)
        {
            bool isValid = false;

            try
            {
                User user = repository.Users.First(u => u.Login == login && u.Password == password);
                if (user != null)
                {
                    isValid = true;
                }
            }
            catch (Exception)
            {
                isValid = false;
            }
            return isValid;
        }
    }
}
