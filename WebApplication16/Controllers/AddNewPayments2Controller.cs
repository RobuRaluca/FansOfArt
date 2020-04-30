using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication16.Models;

namespace WebApplication16.Controllers
{
    public class AddNewPayments2Controller : Controller
    {
        private readonly ApplicationContributionPayments2 _context;

        public AddNewPayments2Controller(ApplicationContributionPayments2 context)
        {
            _context = context;
        }

        // GET: AddNewPayments2
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContributionPayments.ToListAsync());
        }

        // GET: AddNewPayments2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addNewPayment = await _context.ContributionPayments
                .FirstOrDefaultAsync(m => m.ID == id);
            if (addNewPayment == null)
            {
                return NotFound();
            }

            return View(addNewPayment);
        }

        // GET: AddNewPayments2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddNewPayments2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ContributionName,ContributionPrivilege,ContributionDescription,UserStatus")] AddNewPayment addNewPayment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addNewPayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addNewPayment);
        }

        // GET: AddNewPayments2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addNewPayment = await _context.ContributionPayments.FindAsync(id);
            if (addNewPayment == null)
            {
                return NotFound();
            }
            return View(addNewPayment);
        }

        // POST: AddNewPayments2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ContributionName,ContributionPrivilege,ContributionDescription,UserStatus")] AddNewPayment addNewPayment)
        {
            if (id != addNewPayment.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addNewPayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddNewPaymentExists(addNewPayment.ID))
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
            return View(addNewPayment);
        }

        // GET: AddNewPayments2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addNewPayment = await _context.ContributionPayments
                .FirstOrDefaultAsync(m => m.ID == id);
            if (addNewPayment == null)
            {
                return NotFound();
            }

            return View(addNewPayment);
        }

        // POST: AddNewPayments2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addNewPayment = await _context.ContributionPayments.FindAsync(id);
            _context.ContributionPayments.Remove(addNewPayment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddNewPaymentExists(int id)
        {
            return _context.ContributionPayments.Any(e => e.ID == id);
        }
    }
}
