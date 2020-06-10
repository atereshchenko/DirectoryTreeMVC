using DirectoryTree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DirectoryTree.Controllers
{
    public class HomeController : Controller
    {
        WorkerContext db = new WorkerContext();
        [Authorize]
        public ActionResult Index()
        {
            Log.Info(User.Identity.Name, "Home/Index");
            return View();
        }        

        [Authorize]
        public ActionResult Menu()
        {            
            return PartialView();
        }        
    }
}