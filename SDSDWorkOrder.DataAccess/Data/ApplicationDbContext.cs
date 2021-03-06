﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SDSDWorkOrder.Models;
namespace SDSDWorkOrder.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<WorkOrders> WorkOrders { get; set; }
        public DbSet<Comment> Comment  { get; set; }
        public DbSet<NumberSequenceModel> NumberSequences { get; set; }


        public DbSet<AccountOfficer> AccountOfficers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         

            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }


    }
}
