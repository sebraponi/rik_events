using Events.Domain;
using Events.API.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Runtime.CompilerServices;

namespace Events.API.Views.Shared.Payments.Components
{
    public class PaymentsViewComponent : ViewComponent
    {
        private readonly DataContext _context;
        public PaymentsViewComponent(DataContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Payments.ToListAsync());
        }

    }
}