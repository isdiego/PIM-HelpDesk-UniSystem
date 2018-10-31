using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniSystemHelpDesk.Models;

namespace UniSystemHelpDesk.DAL
{
    public class ChamadoDAO
    {
        BDUniSystemHelpDesk bd = new BDUniSystemHelpDesk();

        public List<ConsultaU> Consultar()
        {
            BDUniSystemHelpDesk bd = new BDUniSystemHelpDesk();
            var novo = bd.ConsultaUS.ToList();
            return novo;
        }
    }
}