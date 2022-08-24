using Events.Domain;
using Events.API.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Events.API.Views.Shared.Components.Companies
{
    public class CompaniesViewComponent : ViewComponent
    {
        private readonly DataContext _context;
        public CompaniesViewComponent(DataContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }

        public IViewComponentResult Invoke(Company company, int id)
        {
            ViewBag.Id = id;
            return View(company);
        }
    }
}
