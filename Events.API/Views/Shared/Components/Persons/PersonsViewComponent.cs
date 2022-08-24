using Events.Domain;
using Events.API.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Events.API.Views.Shared.Components.Persons
{
    public class PersonsViewComponent : ViewComponent
    {
        private readonly DataContext _context;
        public PersonsViewComponent(DataContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }

        public IViewComponentResult Invoke(Person person, int id)
        {
            ViewBag.Id = id;
            return View(person);
        }
    }
}
