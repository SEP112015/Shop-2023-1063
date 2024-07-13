﻿using Microsoft.EntityFrameworkCore;
using Shop.Modules.Domain.Entities;

namespace Shop.CUser.Persistence.Context
{
    public class ShopContext : DbContext
    {
        #region "Constructor"
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }
        #endregion
        #region "Db Sets"
        public DbSet<Modules.Domain.Entities.Users> Users { get; set; }
        public DbSet<Modules.Domain.Entities.Customers> Customers { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Modules.Domain.Entities.Customers>()
                .ToTable("Customers", "Sales");
            modelBuilder.Entity<Modules.Domain.Entities.Users>()
                .ToTable("Users", "Security");

        }

    }
}
