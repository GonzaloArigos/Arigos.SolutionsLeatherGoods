﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASF.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LeatherGoodsEntities : DbContext
    {
        public LeatherGoodsEntities()
            : base("name=LeatherGoodsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<CartItem> CartItem { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Dealer> Dealer { get; set; }
        public virtual DbSet<Error> Error { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<LocaleResourceKey> LocaleResourceKey { get; set; }
        public virtual DbSet<LocaleStringResource> LocaleStringResource { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<OrderNumber> OrderNumber { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<Setting> Setting { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
    }
}
