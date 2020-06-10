using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DirectoryTree.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult OpenTree()
        {
            return View();
        }

        public ActionResult JsTree()
        {
            return View();
        }
    }
}