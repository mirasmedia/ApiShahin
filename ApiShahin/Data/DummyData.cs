using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiShahin.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ApiShahin.Data
{
    public class DummyData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApiContext>();
                context.Database.EnsureCreated();
                //context.Database.Migrate();

                // Look for any ailments
                if (context.Users != null && context.Users.Any())
                    return;   // DB has already been seeded

                var ailments = SetUsers().ToArray();
                context.Users.AddRange(ailments);
                context.SaveChanges();
            }
        }

        public static List<User> SetUsers()
        {
            List<User> ailments = new List<User>() {
                new User {Name="Arnold", LastName="Schwarzenegger", Address="", City="California", Phonenumber="+1326548723", Zipcode=""},
                new User {Name="Rocky", LastName="Balboa ", Address="4th Street", City="LA", Phonenumber="645321657", Zipcode="LA54B4"},
                new User {Name="Sylvester", LastName="Stallone", Address="", City="Lasvegas", Phonenumber="32655147", Zipcode=""},
                new User {Name="Arnold", LastName="Schwarzenegger", Address="Washingtonstreet", City="Texas", Phonenumber="782117465", Zipcode="BN445"}
            };
            return ailments;
        }
    }
}
