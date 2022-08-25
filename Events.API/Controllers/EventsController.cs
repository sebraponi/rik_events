
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Events.API.Infrastructure;
using Events.Domain;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Events.API.Controllers
{
    public class EventsController : Controller
    {

        private readonly DataContext _context;

        public EventsController(DataContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return _context.Events != null ?
                        View(await _context.Events.ToListAsync()) :
                        Problem("Entity set 'DataContext.Events'  is null.");
        }

        /// <summary>
        /// Events detail page.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Events/Details/5
        [HttpGet("Events/Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var @event = await _context.Events
                .Include(e => e.EventPersons)
                    .ThenInclude(e => e.Person)
                .Include(e => e.EventCompanies)
                    .ThenInclude(e => e.Company)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.EventId == id);

            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create
        [HttpGet("Events/Create")]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates a Event.
        /// </summary>
        /// <param name="event"></param>
        /// <returns>A newly created Event</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Event/Create
        ///       {
        ///            "EventId": 1,
        ///            "EventTitle": "Title",
        ///            "EventDescription": "Description",
        ///            "EventVenue": "Venue",
        ///            "Date": "24/08/2022 22:14"
        ///        }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Events/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,EventTitle,Date,EventVenue,EventDescription")] Event @event)
        {
            _context.Add(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Events");        
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }
            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }


        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Events/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,EventTitle,EventDescription,Date,EventVenue")] Event @event)
        {
            if (id != @event.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.EventId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Events");
            }
            return View(@event);
        }

        /// <summary>
        /// Deletes an event.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Events
        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        /// <summary>
        /// Deletes an event.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: Events/Delete/5
        [HttpPost("Events/Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Events == null)
            {
                return Problem("Entity set 'DataContext.Events'  is null.");
            }
            var @event = await _context.Events.FindAsync(id);
            if (@event != null)
            {
                _context.Events.Remove(@event);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
          return (_context.Events?.Any(e => e.EventId == id)).GetValueOrDefault();
        }
    }
}
