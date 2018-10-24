using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniSystemHelpDesk.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            return View();
        }
    }
}