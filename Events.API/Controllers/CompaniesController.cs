using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Events.API.Infrastructure;
using Events.Domain;

namespace Events.API.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly DataContext _context;

        public CompaniesController(DataContext context)
        {
            _context = context;
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
              return _context.Companies != null ? 
                          View(await _context.Companies.ToListAsync()) :
                          Problem("Entity set 'DataContext.Companies'  is null.");
        }

        /// <summary>
        /// Companies detail view.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Companies/Details/5
        [HttpGet("Companies/Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Companies == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .FirstOrDefaultAsync(m => m.CompanyId == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates a Company.
        /// </summary>
        /// <param name="company"></param>
        /// <returns>A newly created Event</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Events/Create
        ///       {
        ///            "CompanyId": 1,
        ///            "Name": "Title",
        ///            "Description": "Description",
        ///            "RegistryCode": "234245"
        ///        }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        // POST: Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Companies/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyId,Name,Description,RegistryCode,EventID")] Company company)
        {
            int Id = company.EventID;

            if (ModelState.IsValid)
            {
                _context.Add(company);
                await _context.SaveChangesAsync();

                var eventcompany = new EventCompany
                {
                    EventId = company.EventID,
                    CompanyId = company.CompanyId
                };

                ModelState.Clear();

                var eventCompaniesInDatabase = _context.EventsCompanies.Where(
                    p =>
                        p.Event.EventId == eventcompany.EventId &&
                        p.Company.CompanyId == eventcompany.CompanyId).SingleOrDefault();

                if (eventCompaniesInDatabase == null)
                {
                    _context.EventsCompanies.Add(eventcompany);
                }
                await _context.SaveChangesAsync();

                RedirectToAction("Details", "Events", new { id = Id });
            }
            return RedirectToAction("Details", "Events", new { id = Id });
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Companies == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        /// <summary>
        /// Edits Company.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="company"></param>
        /// <returns>A newly created Event</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Events/Create
        ///       {
        ///            "CompanyId": 1,
        ///            "Name": "Title",
        ///            "Description": "Description",
        ///            "RegistryCode": "234245"
        ///        }
        ///
        /// </remarks>
        /// <response code="201">Returns the edited item</response>
        /// <response code="400">If the item is null</response>
        // POST: Companies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Companies/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyId,Name,Description")] Company company)
        {
            if (id != company.CompanyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.CompanyId))
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
            return RedirectToAction("Index", "Events");
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Companies == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .FirstOrDefaultAsync(m => m.CompanyId == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        /// <summary>
        /// Deletes an Company.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: Companies/Delete/5
        [ValidateAntiForgeryToken]
        [HttpDelete("Companies/Delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Companies == null)
            {
                return Problem("Entity set 'DataContext.Companies'  is null.");
            }
            var company = await _context.Companies.FindAsync(id);
            if (company != null)
            {
                _context.Companies.Remove(company);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Events");
        }

        private bool CompanyExists(int id)
        {
          return (_context.Companies?.Any(e => e.CompanyId == id)).GetValueOrDefault();
        }
    }
}
