using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDSDWorkOrder.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder )
        {
            modelBuilder.Entity<Client>().HasData(

                 new Client() { Id = 1, Name = "Seaways International DMCC", Location = "Africa", CustomerId = "C451.002" },
               new Client() { Id = 2, Name = "AKRON TRADE and TRANSPORT", Location = "Europe", CustomerId = "C452.003" },
               new Client() { Id = 3, Name = "Seaport Shipping PVT LTD", Location = "Asia", CustomerId = "C453.003" }
               );

            modelBuilder.Entity<AccountOfficer>().HasData(

         new AccountOfficer() { Id = 1, Name = "Morgens" },
       new AccountOfficer() { Id = 2, Name = "Micheal" }
             );

             modelBuilder.Entity<Product>().HasData(

            new Product() { Id = 1, Name = "MAMS" },
            new Product() { Id = 2, Name = "V-Platfrom" },
            new Product() { Id = 3, Name = "IHM" }
             );
                    }



      

            //public static async Task InitializeAsync(ApplicationDbContext context, IServiceProvider serviceProvider)
            //    {
            //        context.Database.EnsureCreated();
            //        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            //        string[] rolesNames = { "Admin", "Member" };
            //        Microsoft.AspNet.Identity.IdentityResult roleResult;

            //        foreach(var roleName in rolesNames)
            //        {
            //            var roleExist = await RoleManager.RoleExistsAsync(rolesNames);
            //        }
            //    }
        }
}
