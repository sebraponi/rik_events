using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Events.API.Infrastructure;
using Events.Domain;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Logging;

namespace Events.API.Controllers
{
    public class PersonsController : Controller
    {
        private readonly DataContext _context;

        public PersonsController(DataContext context)
        {
            _context = context;
        }

        // GET: PrivatePersons
        public async Task<IActionResult> Index()
        {
              return _context.People != null ? 
                          View(await _context.People.ToListAsync()) :
                          Problem("Entity set 'DataContext.EventPersons'  is null.");
        }

        // GET: PrivatePersons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.People == null)
            {
                return NotFound();
            }

            var privatePerson = await _context.People
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (privatePerson == null)
            {
                return NotFound();
            }

            return View(privatePerson);
        }

        // GET: PrivatePersons/Create
/*        public IActionResult Create()
        {
            return View();
        }
*/
        // POST: PrivatePersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId,FirstName,LastName,PersonalCode,PaymentType,Description,EventID")] Person person)
        {
            int Id = person.EventID;
            var pId = person.PersonId;



            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();

                var eventperson = new EventPerson
                {
                    EventId = person.EventID,
                    PersonId = person.PersonId
                };

                ModelState.Clear();

                var eventPersonInDatabase = _context.PublicPeople.Where(
                    p =>
                        p.Event.EventId == eventperson.EventId &&
                        p.Person.PersonId == eventperson.PersonId).SingleOrDefault();

                                if (eventPersonInDatabase == null)
                                {
                                    _context.PublicPeople.Add(eventperson);
                                }
                await _context.SaveChangesAsync();

                RedirectToAction("Details", "Events", new { id = Id });
            }
            return RedirectToAction("Details", "Events", new { id = Id });
        }

        // GET: PrivatePersons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.People == null)
            {
                return NotFound();
            }

            var privatePerson = await _context.People.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("PersonId,FirstName,LastName,Description")] Person privatePerson)
        {
            if (id != privatePerson.PersonId)
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
                    if (!PrivatePersonExists(privatePerson.PersonId))
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
            if (id == null || _context.People == null)
            {
                return NotFound();
            }

            var privatePerson = await _context.People
                .FirstOrDefaultAsync(m => m.PersonId == id);
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
            if (_context.People == null)
            {
                return Problem("Entity set 'DataContext.EventPersons'  is null.");
            }
            var privatePerson = await _context.People.FindAsync(id);
            if (privatePerson != null)
            {
                _context.People.Remove(privatePerson);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Events");
        }

        private bool PrivatePersonExists(int id)
        {
          return (_context.People?.Any(e => e.PersonId == id)).GetValueOrDefault();
        }
    }
}
