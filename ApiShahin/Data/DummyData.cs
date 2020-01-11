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

                // Look if actors dumme data is set else genrate data
                if (context.Actors != null && context.Actors.Any())
                {
                    return;
                }
                else
                {
                    var actors = GenerateActors().ToArray();
                    context.Actors.AddRange(actors);
                    context.SaveChanges();
                }
                    

                // Look if movies dumme data is set else genrate data
                if (context.Movies != null && context.Movies.Any())
                {
                    return;
                }
                else
                {
                    var movies = GenerateMovies(context).ToArray();
                    context.Movies.AddRange(movies);
                    context.SaveChanges();
                }   
            }
        }

        public static List<Actor> GenerateActors()
        {
            List<Actor> ailments = new List<Actor>() {
                new Actor {Name="Arnold", LastName="Schwarzenegger", Address="", City="California", Phonenumber="+1326548723", Zipcode=""},
                new Actor {Name="Scarlett", LastName="Johansson", Address="4th Street", City="LA", Phonenumber="645321657", Zipcode="LA54B4"},
                new Actor {Name="Sylvester", LastName="Stallone", Address="", City="Lasvegas", Phonenumber="32655147", Zipcode=""},
                new Actor {Name="Arnold", LastName="Schwarzenegger", Address="Washingtonstreet", City="Texas", Phonenumber="782117465", Zipcode="BN445"}
            };
            return ailments;
        }

        public static List<Movie> GenerateMovies(ApiContext db)
        {
            var actores = db.Actors.ToArray();
            List<Movie> movies = new List<Movie>() {
                new Movie {Name="Jojo Rabbit", Year="2019", Rating=4.2f, Actor = new List<Actor>(db.Actors.Take(1))},
                new Movie {Name="Predator", Year="1987", Rating=4.1f, Actor = new List<Actor>(db.Actors.Take(1))},
                new Movie {Name="The 6th Day", Year="2000", Rating=3.6f, Actor = new List<Actor>(db.Actors.Take(1))},
                new Movie {Name="Rocky", Year="1976", Rating=4.6f, Actor = new List<Actor>(db.Actors.Take(1))},
            };
            return movies;
        }
    }
}
