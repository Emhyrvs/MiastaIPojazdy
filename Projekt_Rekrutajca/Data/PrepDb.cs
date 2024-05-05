using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt_Rekrutajca.Models;

namespace Projekt_Rekrutajca.Data
{
   
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
           
             
            

            if (!context.Vehicles.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Vehicles.AddRange(
                  
                    new VehicleWriteDto() { Id=1, Vehicle_Name = "Bicykle",Min_Population = 1, Max_Population = 1000},
                    new VehicleWriteDto() { Id =2, Vehicle_Name = "Tramp", Min_Population= 500000 , Max_Population = 700000 },
                    new VehicleWriteDto() {Id=3,  Vehicle_Name = "Car", Min_Population = 1000000, Max_Population = 30000000 }
                );


                context.Cities.AddRange
                    (

                    new City { ID = 1, Name = "Wrocław", Population = 600000},
                    new City { ID = 2, Name = "Warsaw" , Population = 2000000 }
                    
                    
                    
                    );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}
