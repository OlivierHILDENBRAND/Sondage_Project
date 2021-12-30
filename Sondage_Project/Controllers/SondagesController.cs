using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
                .FirstOrDefaultAsync(m => m.SondageId == id);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Question,Answer_1,Answer_2,Answer_3,Answer_4, IsActivated, MultipleAnswer")] Sondage sondage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sondage);
                await _context.SaveChangesAsync();
                var id = sondage.SondageId;
                return RedirectToAction(nameof(Manual), new {id});
            }
             return View(sondage);
        }

        // GET : Manual/Id
        public async Task <IActionResult> Manual(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var sondage = await _context.Sondages
                .FirstOrDefaultAsync(m => m.SondageId == id);
            if (sondage == null)
            {
                return NotFound();
            }


            return View(sondage);
        }

        public async Task <IActionResult> DisableLinks(int ?id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sondage = await _context.Sondages
                .FirstOrDefaultAsync(m => m.SondageId == id);
            if (sondage == null)
            {
                return NotFound();
            }

            sondage.IsActivated = false;

            try
            {
                _context.Update(sondage);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SondageExists(sondage.SondageId))
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

        // GET: Sondages/Answer/5
        public async Task<IActionResult> Answer(int? id)
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

            if (sondage.IsActivated == false)
            {
                return Redirect("~/");
            }
            return View(sondage);
        }

        // POST: Sondages/Answer/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Answer(int id, [Bind("SondageId, Question, Answer_1, Answer_2, Answer_3, Answer_4, Counter_1, Counter_2, Counter_3, Counter_4, IsActivated")] Sondage sondage)
        {
            if (sondage.IsActivated == false)
            {
                return Redirect("~/");
            }

            if (id != sondage.SondageId)
            {
                return NotFound();
            }

            sondage.Counter_1 = sondage.Counter_1 + 1;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sondage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SondageExists(sondage.SondageId))
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
                .FirstOrDefaultAsync(m => m.SondageId == id);
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
            return _context.Sondages.Any(e => e.SondageId == id);
        }
    }
}
