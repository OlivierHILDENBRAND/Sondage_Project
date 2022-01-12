using System;
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
        // Return the Index view of the Sondages Views folder
        // It is the list of all sondages that have been created
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sondages.ToListAsync());
        }

        // GET: Sondages/Details/5
        // This method will return the Details view of the Sondages view folder
        // This view contains the results of the sondage
        // If the id of the sondage is not found, it will return nothing
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
        // This method return the Manual view of the Sondage Views folder
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

        // This method is use to delete the Vote button of the Index View of the Sondages
        // We give to the IsActivated checkbox of the sondage the value false
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
        // This method return the Answer view of the Sondage
        // As no answer has been selected, all answer checkbox are false
        public async Task<IActionResult> Answer(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var sondage = await _context.Sondages.FindAsync(id);

            sondage.answer1check = false;
            sondage.answer2check = false;
            sondage.answer3check = false;
            sondage.answer4check = false;

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
        public async Task<IActionResult> Answer(int id, [Bind("SondageId, Question, Answer_1, Answer_2, Answer_3, Answer_4, answer1check, answer2check, answer3check, answer4check, Counter_1, Counter_2, Counter_3, Counter_4, IsActivated, MultipleAnswer")] Sondage sondage)
        {
            if (sondage.IsActivated == false)
            {
                return Redirect("~/");
            }

            if (id != sondage.SondageId)
            {
                return NotFound();
            }

            if (sondage.MultipleAnswer)
            {
                if (sondage.answer1check)
                {
                    sondage.Counter_1 = sondage.Counter_1 + 1;
                }

                if (sondage.answer2check)
                {
                    sondage.Counter_2 = sondage.Counter_2 + 1;
                }

                if (sondage.answer3check)
                {
                    sondage.Counter_3 = sondage.Counter_3 + 1;
                }

                if (sondage.answer4check)
                {
                    sondage.Counter_4 = sondage.Counter_4 + 1;
                }
            }

            if (!sondage.MultipleAnswer)
            {
                if (sondage.answer1check && sondage.answer2check || sondage.answer3check && sondage.answer4check || sondage.answer1check && sondage.answer3check || sondage.answer1check && sondage.answer4check || sondage.answer2check && sondage.answer4check || sondage.answer2check && sondage.answer3check)
                {
                    throw new Exception("Les choix multiples ne sont pas autorisés.");
                }
                else
                {
                    if (sondage.answer1check)
                    {
                        sondage.Counter_1 = sondage.Counter_1 + 1;
                    }

                    if (sondage.answer2check)
                    {
                        sondage.Counter_2 = sondage.Counter_2 + 1;
                    }

                    if (sondage.answer3check)
                    {
                        sondage.Counter_3 = sondage.Counter_3 + 1;
                    }

                    if (sondage.answer4check)
                    {
                        sondage.Counter_4 = sondage.Counter_4 + 1;
                    }
                }
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
        // This method return the delete view of the Sondage Views folder
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
        // If the button of the Delete view is clicked on, the sondage will be deleted
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
