using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder appBuilder)
        {
            using(var serviceScope = appBuilder.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if(!context.Platforms.Any())
            {
                Console.WriteLine("----> started seeding data... ");

                context.Platforms.AddRange(
                    new Platform(){ Name="Dot Net", Publisher="Microsoft", Cost = "Free" },
                    new Platform(){ Name="Sql Server Express", Publisher="Microsoft", Cost = "Free" },
                    new Platform(){ Name="Dot Net", Publisher="Microsoft", Cost = "Free" }
                );

                context.SaveChanges();
            }
            else{
                Console.WriteLine("----> we already have data! ");
            }
        }
    }
}