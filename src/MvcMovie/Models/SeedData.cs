using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();

            if (context.Database == null)
            {
                throw new Exception("DB is null");
            }

            if (context.ShittyEmployee.Any())
            {
                return; //DB has been seeded
            }


            context.ShittyEmployee.AddRange(
                new ShittyEmployee
                {
                    //ID = 1,
                    Name = "Shitty Employee Name 1",
                    Salary = 60,
                    Employed = 5,
                    Address = "1234 Fake St.",
                    Department = "the dept.",
                    Supervisor = "Rick James"
                },
                new ShittyEmployee
                {
                    Name = "Shitty Employee 2",
                    Salary = 30,
                    Employed = 2,
                    Address = "4321 Fake Lane",
                    Department = "Reception",
                    Supervisor = "Your not my supervisor"
                }            
            );         
            context.SaveChanges();
        }
    }
}
