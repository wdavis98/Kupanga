﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kupanga.Models.Repository
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KupangaEntities : DbContext
    {
        public KupangaEntities()
            : base("name=KupangaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Component> Components { get; set; }
        public virtual DbSet<HomeImage> HomeImages { get; set; }
        public virtual DbSet<Home> Homes { get; set; }
        public virtual DbSet<ImageType> ImageTypes { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<QuoteComponent> QuoteComponents { get; set; }
        public virtual DbSet<SubmittedQuote> SubmittedQuotes { get; set; }
    }
}