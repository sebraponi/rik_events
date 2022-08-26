using Events.Domain;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
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

                var persons = new Person[] {

                   new Person { FirstName = "Andres", LastName = "Rebane",
                       PersonalCode = 37507090173 },
                   new Person { FirstName = "Urmas", LastName = "Raudsep",
                       PersonalCode = 38305207088 },
                   new Person { FirstName = "Tiina", LastName = "Saar",
                       PersonalCode = 47606154955 },
                   new Person { FirstName = "Katrin", LastName = "Vaher",
                       PersonalCode = 47312294910 },
                   new Person { FirstName = "Priit", LastName = "Sarapuu",
                       PersonalCode = 39912263716 },
                   new Person { FirstName = "Jaan", LastName = "Lepik",
                       PersonalCode = 36607227084 },
                   new Person { FirstName = "Laura", LastName = "Kask",
                       PersonalCode = 49011054762 },
                   new Person { FirstName = "Kadri", LastName = "Kivi",
                       PersonalCode = 45105259563 },
               };

                context.People.AddRange(persons);
                context.SaveChanges();

                var companies = new Company[] {
                    new Company { Name = "Eesti Rahvusraamatukogu", RegistryCode = 74000139 },
                    new Company { Name = "Eesti Huumorimuuseum", RegistryCode = 80402416 },
                    new Company { Name = "Rakvere Linnavalitsus", RegistryCode = 75025064 }
                };

                context.Companies.AddRange(companies);
                context.SaveChanges();

                var events = new Event[] {
                    new Event { EventTitle = "Metsa Festival", EventVenue = "Jõgeva", Date = DateTime.Parse("12/04/2023 12:00", CultureInfo.CreateSpecificCulture("et-EE")) },
                    new Event { EventTitle = "Kadripäev", EventVenue = "Rakvere vallimägi", Date = DateTime.Parse("25/11/2022 14:00", CultureInfo.CreateSpecificCulture("et-EE")) },
                    new Event { EventTitle = "Kevade algus", EventVenue = "Kunda", Date = DateTime.Parse("20/03/2022 17:33", CultureInfo.CreateSpecificCulture("et-EE")) },
                    new Event { EventTitle = "Raasiku väliujula avamine", EventVenue = "Raasiku", Date = DateTime.Parse("10/06/2022 10:00", CultureInfo.CreateSpecificCulture("et-EE")) }
                };

                context.Events.AddRange(events);
                context.SaveChanges();

                var eventpersons = new EventPerson[]
                {
                    new EventPerson
                    {
                        EventId = events.Single(e => e.EventTitle == "Metsa Festival").EventId,
                        PersonId = persons.Single(p => p.LastName == "Kask").PersonId
                    },
                    new EventPerson
                    {
                        EventId = events.Single(e => e.EventTitle == "Metsa Festival").EventId,
                        PersonId = persons.Single(p => p.LastName == "Lepik").PersonId
                    },
                    new EventPerson
                    {
                        EventId = events.Single(e => e.EventTitle == "Metsa Festival").EventId,
                        PersonId = persons.Single(p => p.LastName == "Rebane").PersonId
                    },
                    new EventPerson
                    {
                        EventId = events.Single(e => e.EventTitle == "Kadripäev").EventId,
                        PersonId = persons.Single(p => p.LastName == "Kivi").PersonId
                    },
                    new EventPerson
                    {
                        EventId = events.Single(e => e.EventTitle == "Kadripäev").EventId,
                        PersonId = persons.Single(p => p.LastName == "Raudsep").PersonId
                    },
                    new EventPerson
                    {
                        EventId = events.Single(e => e.EventTitle == "Kevade algus").EventId,
                        PersonId = persons.Single(p => p.LastName == "Vaher").PersonId
                    },
                    new EventPerson
                    {
                        EventId = events.Single(e => e.EventTitle == "Kevade algus").EventId,
                        PersonId = persons.Single(p => p.LastName == "Sarapuu").PersonId
                    }
                };

                foreach (EventPerson e in eventpersons)
                {
                    if (e is not null)
                    {
                        var eventPersonInDatabase = context.PublicPeople.Where(
                            p =>
                                p.Event.EventId == e.EventId &&
                                p.Person.PersonId == e.PersonId).SingleOrDefault();

                        if (eventPersonInDatabase == null)
                        {
                            context.PublicPeople.Add(e);
                        }
                    }
                }
                context.SaveChanges();

                var eventcompanies = new EventCompany[]
                {
                    new EventCompany
                    {
                        EventId = events.Single(e => e.EventTitle == "Raasiku väliujula avamine").EventId,
                        CompanyId = companies.Single(c => c.Name == "Eesti Huumorimuuseum").CompanyId
                    },
                    new EventCompany
                    {
                        EventId = events.Single(e => e.EventTitle == "Raasiku väliujula avamine").EventId,
                        CompanyId = companies.Single(c => c.Name == "Eesti Rahvusraamatukogu").CompanyId
                    }
                };

                foreach (EventCompany e in eventcompanies)
                {
                    if (e is not null)
                    {
                        var eventCompanyInDatabase = context.EventsCompanies.Where(
                            p =>
                                p.Event.EventId == e.EventId &&
                                p.Company.CompanyId == e.CompanyId).SingleOrDefault();

                        if (eventCompanyInDatabase == null)
                        {
                            context.EventsCompanies.Add(e);
                        }
                    }
                }
                context.SaveChanges();

                context.Payments.Add(
                    new Payment { PaymentType = "Kaardimakse" }
                    );

                context.Payments.Add(
                    new Payment { PaymentType = "Sularahas" }
                    );

                context.SaveChanges();
            }
        }
    }
}
