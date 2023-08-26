using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GymWeb.Context;
using GymWeb.Entities;
using Microsoft.AspNetCore.Authorization;

namespace GymWeb.Controllers;


public class MembersSubscriptionsController : Controller
{
    private readonly GymManagementContext _context;

    public MembersSubscriptionsController(GymManagementContext context)
    {
        _context = context;
    }

    // GET: MembersSubscriptions
    public async Task<IActionResult> Index()
    {
          return    _context.MembersSubscriptions != null ? 
                      View(await _context.MembersSubscriptions.ToListAsync()) :
                      Problem("Entity set 'GymContext.MembersSubscription'  is null.");
    }

    // GET: MembersSubscriptions/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.MembersSubscriptions == null)
        {
            return NotFound();
        }

        var membersSubscription = await _context.MembersSubscriptions
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
    public async Task<IActionResult> Create([Bind("MemberId,SubscriptionId,OriginalPrice,DiscountValue,PaidPrice,StartDate,EndDate,RemainingSessions,IsDeleted")] MembersSubscription membersSubscription)
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
        if (id == null || _context.MembersSubscriptions == null)
        {
            return NotFound();
        }

        var membersSubscription = await _context.MembersSubscriptions.FindAsync(id);
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
        if (id == null || _context.MembersSubscriptions == null)
        {
            return NotFound();
        }

        var membersSubscription = await _context.MembersSubscriptions
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
        if (_context.MembersSubscriptions == null)
        {
            return Problem("Entity set 'GymContext.MembersSubscription'  is null.");
        }
        var membersSubscription = await _context.MembersSubscriptions.FindAsync(id);
        if (membersSubscription != null)
        {
            _context.MembersSubscriptions.Remove(membersSubscription);
        }
        
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MembersSubscriptionExists(int id)
    {
      return (_context.MembersSubscriptions?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
