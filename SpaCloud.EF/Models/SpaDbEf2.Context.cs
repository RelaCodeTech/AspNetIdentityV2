﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SpaCloud.EF.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DevTestEntities1 : DbContext
    {
        public DevTestEntities1()
            : base("name=DevTestEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AppointmentDiary> AppointmentDiaries { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<BranchTreatmentCost> BranchTreatmentCosts { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerMembership> CustomerMemberships { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeType> EmployeeTypes { get; set; }
        public virtual DbSet<GiftCert> GiftCerts { get; set; }
        public virtual DbSet<InventoryRqdForService> InventoryRqdForServices { get; set; }
        public virtual DbSet<InventoryRqdForTreatment> InventoryRqdForTreatments { get; set; }
        public virtual DbSet<LookupBranchRegion> LookupBranchRegions { get; set; }
        public virtual DbSet<LookupCountry> LookupCountries { get; set; }
        public virtual DbSet<LookupCustomerType> LookupCustomerTypes { get; set; }
        public virtual DbSet<LookUpProductUoM> LookUpProductUoMs { get; set; }
        public virtual DbSet<LookupState> LookupStates { get; set; }
        public virtual DbSet<Membership> Memberships { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Tax> Taxes { get; set; }
        public virtual DbSet<Treatment> Treatments { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }
        public virtual DbSet<XrefServiceTreatment> XrefServiceTreatments { get; set; }
    }
}