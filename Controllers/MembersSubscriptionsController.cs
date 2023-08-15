using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GymWeb.Context;
using GymWeb.Models;

namespace GymWeb.Controllers
{
    public class MembersSubscriptionsController : Controller
    {
        private readonly GymContext _context;

        public MembersSubscriptionsController(GymContext context)
        {
            _context = context;
        }

        // GET: MembersSubscriptions
        public async Task<IActionResult> Index()
        {
              return _context.MembersSubscription != null ? 
                          View(await _context.MembersSubscription.ToListAsync()) :
                          Problem("Entity set 'GymContext.MembersSubscription'  is null.");
        }

        // GET: MembersSubscriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MembersSubscription == null)
            {
                return NotFound();
            }

            var membersSubscription = await _context.MembersSubscription
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membersSubscription == null)
            {
                return NotFound();
            }

            return View(membersSubscription);
        }

        // GET: MembersSubscriptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MembersSubscriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MemberId,SubscriptionId,OriginalPrice,DiscountValue,PaidPrice,StartDate,EndDate,RemainingSessions,IsDeleted")] MembersSubscription membersSubscription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membersSubscription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(membersSubscription);
        }

        // GET: MembersSubscriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MembersSubscription == null)
            {
                return NotFound();
            }

            var membersSubscription = await _context.MembersSubscription.FindAsync(id);
            if (membersSubscription == null)
            {
                return NotFound();
            }
            return View(membersSubscription);
        }

        // POST: MembersSubscriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MemberId,SubscriptionId,OriginalPrice,DiscountValue,PaidPrice,StartDate,EndDate,RemainingSessions,IsDeleted")] MembersSubscription membersSubscription)
        {
            if (id != membersSubscription.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membersSubscription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembersSubscriptionExists(membersSubscription.Id))
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
            return View(membersSubscription);
        }

        // GET: MembersSubscriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MembersSubscription == null)
            {
                return NotFound();
            }

            var membersSubscription = await _context.MembersSubscription
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membersSubscription == null)
            {
                return NotFound();
            }

            return View(membersSubscription);
        }

        // POST: MembersSubscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MembersSubscription == null)
            {
                return Problem("Entity set 'GymContext.MembersSubscription'  is null.");
            }
            var membersSubscription = await _context.MembersSubscription.FindAsync(id);
            if (membersSubscription != null)
            {
                _context.MembersSubscription.Remove(membersSubscription);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembersSubscriptionExists(int id)
        {
          return (_context.MembersSubscription?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
