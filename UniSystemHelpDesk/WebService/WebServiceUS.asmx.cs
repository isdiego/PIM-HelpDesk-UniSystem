using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using UniSystemHelpDesk.DAL;
using UniSystemHelpDesk.Models;

namespace UniSystemHelpDesk.WebService
{
    /// <summary>
    /// Summary description for WebServiceUS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceUS : System.Web.Services.WebService
    {
        [WebMethod]
        public List<ConsultaU> ConsultarChamado()
        {
            ChamadoDAO chamadodao = new ChamadoDAO();
            return chamadodao.Consultar();
        }
    }
}
