using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DirectoryTree.Models;
using System.Security.Cryptography;
using System.Text;

namespace DirectoryTree.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            Log.Info(User.Identity.Name, "Account/Login");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Worker worker = null;
                using (WorkerContext db = new WorkerContext())
                {
                    string sha1pass = HashSHA1Decryption(model.Password).ToLower();                    
                    worker = db.Workers.FirstOrDefault(u => u.Login == model.Login && u.PassHash == sha1pass);
                }
                if (worker != null)
                {
                    //FormsAuthentication.SetAuthCookie(model.Login, true);
                    FormsAuthentication.SetAuthCookie(worker.Name, true);
                    Log.Info(User.Identity.Name, "Account/Login|[HttpPost]");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Log.Error(model.Login + "|failed login attempt");                 
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }                
            }
            return View(model);
        }        

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            Log.Info(User.Identity.Name, "Home/Register");
            if (ModelState.IsValid)
            {
                Worker worker = null;
                using (WorkerContext db = new WorkerContext())
                {
                    worker = db.Workers.FirstOrDefault(u => u.Login == model.Login);
                }
                if (worker == null)
                {
                    string sha1pass = HashSHA1Decryption(model.Password).ToLower();
                    using (WorkerContext db = new WorkerContext())
                    {
                        db.Workers.Add(new Worker { Login = model.Login, PassHash = sha1pass });
                        db.SaveChanges();
                        Log.Info("Create worker: " + worker.Login); 
                        worker = db.Workers.Where(u => u.Login == model.Login && u.PassHash == sha1pass).FirstOrDefault();
                    }
                    if (worker != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Login, true);                        
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    Log.Info(worker.Login + " Пользователь с таким логином уже существует "); 
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }                
            }
            return View(model);
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        public static string HashSHA1Decryption(string value)
        {
            var shaSHA1 = System.Security.Cryptography.SHA1.Create();
            var inputEncodingBytes = Encoding.ASCII.GetBytes(value);
            var hashString = shaSHA1.ComputeHash(inputEncodingBytes);

            var stringBuilder = new StringBuilder();
            for (var x = 0; x < hashString.Length; x++)
            {
                stringBuilder.Append(hashString[x].ToString("X2"));
            }
            return stringBuilder.ToString();
        }
    }
}