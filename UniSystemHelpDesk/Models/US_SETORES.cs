//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UniSystemHelpDesk.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class US_SETORES
    {
        public US_SETORES()
        {
            this.US_USUARIOS = new HashSet<US_USUARIOS>();
        }
    
        public int ID_SETOR { get; set; }
        public string SETOR { get; set; }
    
        public virtual ICollection<US_USUARIOS> US_USUARIOS { get; set; }
    }
}
