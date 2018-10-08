using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UniSystemHelpDesk.Models;

namespace UniSystemHelpDesk.Controllers
{
    public class ContaController : Controller
    {
        UniSystemBD db = new UniSystemBD ();

        public ActionResult Login()
        {
            return View();
            ViewBag.Message = "";
        }

        [HttpPost]
        public ActionResult Login(US_USUARIOS log)
        {
            var resultado = db.US_USUARIOS.Where(a => a.EMAIL_USUARIO==log.EMAIL_USUARIO && a.SENHA_USUARIO==log.SENHA_USUARIO).ToList();
            if (resultado.Count()>0)
            {
                Session["ID_USUARIOS"] = resultado[0].ID_USUARIOS;
                FormsAuthentication.SetAuthCookie(resultado[0].EMAIL_USUARIO, false);
                //Usuario
                if (resultado[0].ID_TIPO_USUARIO==2)
                {
                    return RedirectToAction("../Admin/Index");   
                }
                //Admin
                if (resultado[0].ID_TIPO_USUARIO == 1)
                {
                    return RedirectToAction("../Usuario/Index");
                }
            }
            else
            {
                ViewBag.Message = "Usuário incorreto";
            }
            return View(log);
        }
        public ActionResult Logout()
        {
            Session["ID_USUARIOS"] = 0;
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}