using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sondage_Project.Data;
using Sondage_Project.Data.Models;


namespace Sondage_Project.Controllers
{
    [Authorize]
    public class SondagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SondagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sondages
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sondages.ToListAsync());
        }

        // GET: Sondages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sondage = await _context.Sondages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sondage == null)
            {
                return NotFound();
            }

            return View(sondage);
        }

        // GET: Sondages/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Sondages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Question,Answer_1,Answer_2,Answer_3,Answer_4, IsActivated, MultipleAnswer")] Sondage sondage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sondage);
                await _context.SaveChangesAsync();
                var id = sondage.Id;
                return RedirectToAction(nameof(Manual), new {id});
            }
             return View(sondage);
        }

        public async Task <IActionResult> Manual(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var sondage = await _context.Sondages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sondage == null)
            {
                return NotFound();
            }


            return View(sondage);
        }

        // GET: Sondages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sondage = await _context.Sondages.FindAsync(id);
            if (sondage == null)
            {
                return NotFound();
            }
            return View(sondage);
        }

        // POST: Sondages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Question,Answer_1,Answer_2,Answer_3,Answer_4,Counter_1,Counter_2,Counter_3,Counter_4,IsActivated,MultipleAnswer")] Sondage sondage)
        {
            if (id != sondage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sondage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SondageExists(sondage.Id))
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
            return View(sondage);
        }

        // GET: Sondages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sondage = await _context.Sondages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sondage == null)
            {
                return NotFound();
            }

            return View(sondage);
        }

        // POST: Sondages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sondage = await _context.Sondages.FindAsync(id);
            _context.Sondages.Remove(sondage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SondageExists(int id)
        {
            return _context.Sondages.Any(e => e.Id == id);
        }
    }
}
