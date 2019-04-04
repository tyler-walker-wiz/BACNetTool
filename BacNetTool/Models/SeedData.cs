using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BacNetTool.Models;
using BACNetToolWeb.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BACNetToolWeb.Models
{
    public static class SeedData
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {

                using (var context = new BACNet_dbContext(
                    scope.ServiceProvider.GetRequiredService<DbContextOptions<BACNet_dbContext>>()))
                {

                    try
                    {
                        SeedDB(context);
                    }
                    catch (Exception e) { }
                }
            }
        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
            string testUserPw, string userName)
        {
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            var user = await userManager.FindByNameAsync(userName);
            if (user == null)
            {
                user = new IdentityUser { UserName = userName };
                await userManager.CreateAsync(user, testUserPw);
            }

            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
            string uid, string role)
        {
            IdentityResult IR = null;
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            var user = await userManager.FindByIdAsync(uid);

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }

        private static void SeedDB(BACNet_dbContext context)
        {
            //Look for any movies.
            if (context.Device.Any())
            {
                return;   // DB has been seeded
            }

            //var items = new List<Device>
            //    {
            //        new Device{Id = 1}
            //    };
            var children1 = new List<Device>
            {
                new Device {ObjectName = "DEV7", Id = 7},
                new Device {ObjectName = "DEV8", Id = 8}
            };
            var children2 = new List<Device>
            {
                new Device {ObjectName = "DEV9", Id = 9},
                new Device {ObjectName = "DEV10", Id = 10}
            };
            var children3 = new List<Device>
            {
                new Device {ObjectName = "DEV1", Id = 11 },
                new Device {ObjectName = "DEV12", Id = 12 },
                new Device {ObjectName = "DEV13", Id = 13 },
                new Device {ObjectName = "DEV14", Id = 14 },
            };
            var items = new List<Device>
            {
                new Device{ObjectName = "NAE1", Id = 1, },
                new Device{ObjectName = "NAE2", Id = 2, },
                new Device{ObjectName = "NAE3", Id = 3, },
                new Device{ObjectName = "NAE4", Id = 4, },
                new Device{ObjectName = "NAE5", Id = 5, },
                new Device{ ObjectName = "NAE6", Id = 6 }
            };

            context.Device.AddRange(items);

            context.SaveChanges();
        }
    }
}
