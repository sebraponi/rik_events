using Microsoft.EntityFrameworkCore;

namespace Events.API.Infrastructure
{
    public class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            context.Database.Migrate();
        }
    }
}
