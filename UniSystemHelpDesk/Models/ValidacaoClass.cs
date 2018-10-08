using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UniSystemHelpDesk.Models
{
    [MetadataType(typeof(US_USUARIOSMETA))]

    public partial class US_USUARIOS
    {

    }
    [MetadataType(typeof(US_CHAMADOMETA))]
    public partial class US_CHAMADOS 
    {

    }
    public partial class US_USUARIOSMETA
    {
        [Required(ErrorMessage = "Preecha o campo", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage="E-mail invalido")]
        
        public string EMAIL_USUARIO { get; set; }
        [Required(ErrorMessage = "Preecha o campo", AllowEmptyStrings=false)]
        [DataType(DataType.Password)]
        public string SENHA_USUARIO { get; set; }
    }
    public partial class US_CHAMADOMETA
    {
        [Required(ErrorMessage = "Preecha o campo", AllowEmptyStrings = false)]
        public string CHAMADO { get; set; }

        [Required(ErrorMessage = "Preecha o campo", AllowEmptyStrings = false)]
        public int ID_EQUIPAMENTO { get; set; }
    }
}