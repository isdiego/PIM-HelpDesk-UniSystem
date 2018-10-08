using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniSystemHelpDesk.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult segundaPagina()
        {
            return View();
        }
    }
}