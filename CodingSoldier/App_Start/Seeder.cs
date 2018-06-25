using CodingSoldier.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CodingSoldier.App_Start
{
    public class Seeder
    {
        public static void Seed()
        {
            CodingSoldierDbContext context = null;
            try
            {
                context = new CodingSoldierDbContext();
                if (!context.Roles.Any())
                {
                    foreach (var role in GetIdentityRoles())
                        context.Roles.Add(role);
                }
                if(!context.Categories.Any())
                {
                    foreach (var category in GetCategories())
                        context.Categories.Add(category);
                }
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                Debug.Write(ex.ToString());
            }
            finally
            {
                if (context != null)
                    context.Dispose();
            }
        }

        private static IEnumerable<IdentityRole> GetIdentityRoles()
        {
            var roleAdmin = new IdentityRole();
            roleAdmin.Id = Guid.NewGuid().ToString();
            roleAdmin.Name = "Admin";
            roleAdmin.NormalizedName = roleAdmin.Name.ToUpper();
            yield return roleAdmin;

            var roleReadOnly = new IdentityRole();
            roleReadOnly.Id = Guid.NewGuid().ToString();
            roleReadOnly.Name = "ReadOnly";
            roleReadOnly.NormalizedName = roleReadOnly.Name.ToUpper();
            yield return roleReadOnly;
        }

        private static IEnumerable<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category{ Id = 1, CategoryName = "ASP.NET" },
                new Category{ Id = 2, CategoryName = "C#.NET" },
                new Category{ Id = 3, CategoryName = "JavaScript" },
                new Category{ Id = 4, CategoryName = "MVC" },
                new Category{ Id = 5, CategoryName = "SQL" },
                new Category{ Id = 6, CategoryName = "Others" }
            };
        }
    }
}
