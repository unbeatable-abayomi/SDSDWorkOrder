using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SDSDWorkOrder.Models;

namespace SDSDWorkOrder.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Client { get; set; }
        //public DbSet<Comment> Comment  { get; set; }
        //public DbSet<Product> Product { get; set; }
        //public DbSet<UserRole> UserRole { get; set; }
    }
}
