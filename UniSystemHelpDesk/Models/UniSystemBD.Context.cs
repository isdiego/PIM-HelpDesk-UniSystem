﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UniSystemBD : DbContext
    {
        public UniSystemBD()
            : base("name=UniSystemBD")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<US_CHAMADOS> US_CHAMADOS { get; set; }
        public virtual DbSet<US_EQUIPAMENTO> US_EQUIPAMENTO { get; set; }
        public virtual DbSet<US_SETORES> US_SETORES { get; set; }
        public virtual DbSet<US_STATUS> US_STATUS { get; set; }
        public virtual DbSet<US_TIPO_EQUIPAMENTO> US_TIPO_EQUIPAMENTO { get; set; }
        public virtual DbSet<US_TIPO_USUARIO> US_TIPO_USUARIO { get; set; }
        public virtual DbSet<US_USUARIOS> US_USUARIOS { get; set; }
    }
}