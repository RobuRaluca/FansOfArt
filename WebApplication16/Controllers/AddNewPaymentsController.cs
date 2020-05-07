using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication16.Models;
using WebApplication16.Services.Interfaces;
using WebApplication16.Services;
namespace WebApplication16.Controllers
{
    public class AddNewPaymentsController : Controller
    {
          //private readonly ApplicationContributionPayments _context;
        private IPaymentService PaymentService;

        public AddNewPaymentsController(IPaymentService ContributionPayments)
        {
            this.PaymentService = ContributionPayments;
        }

        /* public AddNewPaymentsController(ApplicationContributionPayments context)
         {
             _context = context;
         }*/

        // GET: AddNewPayments
        public async Task<IActionResult> Index()
        {
            List<AddNewPayment> newContribution_Payments = PaymentService.getAll();

            return View();
        }


        // GET: AddNewPayments/Create
        [HttpPost]
        public IActionResult Create([FromForm]AddNewPayment model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            PaymentService.createPayment(model.ContributionName, model.ContributionPrivilege, model.ContributionDescription, model.UserStatus);

            return Redirect(Url.Action("Index", "AddNewPayments"));
            // return View();
        }
    }
}

        // POST: AddNewPayments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,ContributionName,ContributionPrivilege,ContributionDescription,UserStatus")] AddNewPayment addNewPayment)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(addNewPayment);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(addNewPayment);
        //}

//        // GET: AddNewPayments/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var addNewPayment = await _context.ContributionPayments.FindAsync(id);
//            if (addNewPayment == null)
//            {
//                return NotFound();
//            }
//            return View(addNewPayment);
//        }

//        // POST: AddNewPayments/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ID,ContributionName,ContributionPrivilege,ContributionDescription,UserStatus")] AddNewPayment addNewPayment)
//        {
//            if (id != addNewPayment.ID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(addNewPayment);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!AddNewPaymentExists(addNewPayment.ID))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(addNewPayment);
//        }

//        // GET: AddNewPayments/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var addNewPayment = await _context.ContributionPayments
//                .FirstOrDefaultAsync(m => m.ID == id);
//            if (addNewPayment == null)
//            {
//                return NotFound();
//            }

//            return View(addNewPayment);
//        }

//        // POST: AddNewPayments/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var addNewPayment = await _context.ContributionPayments.FindAsync(id);
//            _context.ContributionPayments.Remove(addNewPayment);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool AddNewPaymentExists(int id)
//        {
//            return _context.ContributionPayments.Any(e => e.ID == id);
//        }
//    }
//}
