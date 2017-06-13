﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JobCards.Models.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DigiFusionEntities : DbContext
    {
        public DigiFusionEntities()
            : base("name=DigiFusionEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Designer> Designers { get; set; }
        public virtual DbSet<JobCard> JobCards { get; set; }
        public virtual DbSet<JobType> JobTypes { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SYSUser> SYSUsers { get; set; }
        public virtual DbSet<SYSUserProfile> SYSUserProfiles { get; set; }
        public virtual DbSet<SYSUserRole> SYSUserRoles { get; set; }

        public System.Data.Entity.DbSet<JobCards.Models.ViewModel.CustomerView> CustomerViews { get; set; }

        public System.Data.Entity.DbSet<JobCards.Models.ViewModel.DesignerView> DesignerViews { get; set; }

        public System.Data.Entity.DbSet<JobCards.Models.ViewModel.JobTypeView> JobTypeViews { get; set; }

        public System.Data.Entity.DbSet<JobCards.Models.ViewModel.MaterialView> MaterialViews { get; set; }
    }
}
