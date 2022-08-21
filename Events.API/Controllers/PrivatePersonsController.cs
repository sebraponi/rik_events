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
    public class PrivatePersonsController : Controller
    {
        private readonly DataContext _context;

        public PrivatePersonsController(DataContext context)
        {
            _context = context;
        }

        // GET: PrivatePersons
        public async Task<IActionResult> Index()
        {
              return _context.PrivatePeople != null ? 
                          View(await _context.PrivatePeople.ToListAsync()) :
                          Problem("Entity set 'DataContext.PrivatePeople'  is null.");
        }

        // GET: PrivatePersons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PrivatePeople == null)
            {
                return NotFound();
            }

            var privatePerson = await _context.PrivatePeople
                .FirstOrDefaultAsync(m => m.PrivatePersonId == id);
            if (privatePerson == null)
            {
                return NotFound();
            }

            return View(privatePerson);
        }

        // GET: PrivatePersons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PrivatePersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrivatePersonId,FirstName,LastName,Description")] PrivatePerson privatePerson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(privatePerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(privatePerson);
        }

        // GET: PrivatePersons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PrivatePeople == null)
            {
                return NotFound();
            }

            var privatePerson = await _context.PrivatePeople.FindAsync(id);
            if (privatePerson == null)
            {
                return NotFound();
            }
            return View(privatePerson);
        }

        // POST: PrivatePersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrivatePersonId,FirstName,LastName,Description")] PrivatePerson privatePerson)
        {
            if (id != privatePerson.PrivatePersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(privatePerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrivatePersonExists(privatePerson.PrivatePersonId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(privatePerson);
        }

        // GET: PrivatePersons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PrivatePeople == null)
            {
                return NotFound();
            }

            var privatePerson = await _context.PrivatePeople
                .FirstOrDefaultAsync(m => m.PrivatePersonId == id);
            if (privatePerson == null)
            {
                return NotFound();
            }

            return View(privatePerson);
        }

        // POST: PrivatePersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PrivatePeople == null)
            {
                return Problem("Entity set 'DataContext.PrivatePeople'  is null.");
            }
            var privatePerson = await _context.PrivatePeople.FindAsync(id);
            if (privatePerson != null)
            {
                _context.PrivatePeople.Remove(privatePerson);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrivatePersonExists(int id)
        {
          return (_context.PrivatePeople?.Any(e => e.PrivatePersonId == id)).GetValueOrDefault();
        }
    }
}
