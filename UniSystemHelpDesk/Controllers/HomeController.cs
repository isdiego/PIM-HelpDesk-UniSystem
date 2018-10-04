using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniSystemHelpDesk.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace UniSystemHelpDesk.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(US_USUARIOS lc)
        {
            string mainconexao = ConfigurationManager.ConnectionStrings["ConexaoBD"].ConnectionString;
            SqlConnection sqlconexao = new SqlConnection(mainconexao);
            string sqlquery = "select EMAIL_USUARIO, SENHA_USUARIO from [dbo].[US_USUARIOS] where EMAIL_USUARIO=@EMAIL_USUARIO and SENHA_USUARIO=@SENHA_USUARIO";
            sqlconexao.Open();
            SqlCommand sqlcomando = new SqlCommand(sqlquery, sqlconexao);
            sqlcomando.Parameters.AddWithValue("@EMAIL_USUARIO", lc.EMAIL_USUARIO);
            sqlcomando.Parameters.AddWithValue("@SENHA_USUARIO", lc.SENHA_USUARIO);
            SqlDataReader sdr = sqlcomando.ExecuteReader();
            if (sdr.Read())
            {
                Session["username"] = lc.EMAIL_USUARIO.ToString();
                return RedirectToAction("BemVindo");
            }
            else
            {
                ViewData["Mensagem"] = "Erro: Usuário ou Senha invalida !";
            }
            sqlconexao.Close();
            return View();
        }

        public ActionResult BemVindo()
        {
            return View();
        }
    }
}