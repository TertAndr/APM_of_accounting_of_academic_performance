﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APM_of_accounting_of_academic_performance.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AUTOMATED_ACTIVEntities : DbContext
    {
        public AUTOMATED_ACTIVEntities()
            : base("name=AUTOMATED_ACTIVEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Attachment> Attachment { get; set; }
        public virtual DbSet<Curriculum_in_the_specialtys> Curriculum_in_the_specialtys { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Loads> Loads { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Specialtys> Specialtys { get; set; }
        public virtual DbSet<Sudjects> Sudjects { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
        public virtual DbSet<Type_of_clocks> Type_of_clocks { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
