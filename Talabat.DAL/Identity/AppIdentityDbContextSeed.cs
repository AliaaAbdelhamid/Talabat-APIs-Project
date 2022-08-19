using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DAL.Entities.Identity;
 
namespace Talabat.DAL.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManger)
        {
            if (!userManger.Users.Any())
            {
                var user = new AppUser()
                {
                    DisplayName = "Aliaa tarek",
                    UserName = "AliaaTarek25",
                    Email = "aliaatarek25@gmail.com",
                    PhoneNumber = "01113137506",
                    address = new Address()
                    {
                        FirstName = "aliaa",
                        LastName = "tarek",
                        Country = "Egypt",
                        City = "Giza",
                        Street = "Bedaya"
                    }
                };
                await userManger.CreateAsync(user, "Pa$$w0rd"); 
            } 
        }
    }
}
