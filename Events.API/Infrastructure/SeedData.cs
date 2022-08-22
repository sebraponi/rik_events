using Events.Domain;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Events.API.Infrastructure
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DataContext(
                serviceProvider.GetRequiredService<DbContextOptions<DataContext>>()))

            {
                if (context.Events.Any())
                {
                    return;
                }

                context.Events.Add(
                new Event
                {
                    EventTitle = "Rakvere Suvi",
                    EventVenue = "Rakvere",
                    Date = DateTime.Now            
                });

               

                context.PrivatePeople.AddRange(
                    new PrivatePerson
                    {
                        FirstName = "Katri",
                        LastName = "Mutri"
                    },
                    new PrivatePerson
                    {
                        FirstName = "Mari",
                        LastName = "Muri",
                    },
                    new PrivatePerson
                    {
                        FirstName = "Paul",
                        LastName = "Saul"
                    }
                );

                context.Companies.AddRange(
                    new Company
                    {
                        Name = "Krakov OY"
                    },
                    new Company
                    {
                        Name = "AS London"
                    },
                    new Company
                    {
                        Name = "Kreem OY"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
