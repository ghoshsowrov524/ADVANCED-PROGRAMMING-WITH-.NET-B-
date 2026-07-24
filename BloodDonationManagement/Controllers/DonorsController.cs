using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BloodDonationManagement.Models;

public class DonorsController : Controller
{
    private readonly BloodDonationDbContext _context;

    public DonorsController(BloodDonationDbContext context)
    {
        _context = context;
    }

    // GET: Donors
    public async Task<IActionResult> Index()
    {
        return View(await _context.Donors.ToListAsync());
    }

    // GET: Donors/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var donor = await _context.Donors
            .FirstOrDefaultAsync(m => m.DonorId == id);

        if (donor == null)
        {
            return NotFound();
        }

        return View(donor);
    }

    // GET: Donors/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Donors/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("DonorId,Name,Age,BloodGroup,Phone,LastDonationDate")] Donor donor)
    {
        if (ModelState.IsValid)
        {
            _context.Add(donor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(donor);
    }

    // GET: Donors/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var donor = await _context.Donors.FindAsync(id);

        if (donor == null)
        {
            return NotFound();
        }

        return View(donor);
    }

    // POST: Donors/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("DonorId,Name,Age,BloodGroup,Phone,LastDonationDate")] Donor donor)
    {
        if (id != donor.DonorId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(donor);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonorExists(donor.DonorId))
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
        return View(donor);
    }

    // GET: Donors/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var donor = await _context.Donors
            .FirstOrDefaultAsync(m => m.DonorId == id);

        if (donor == null)
        {
            return NotFound();
        }

        return View(donor);
    }

    // POST: Donors/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var donor = await _context.Donors.FindAsync(id);

        if (donor != null)
        {
            _context.Donors.Remove(donor);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    

    private bool DonorExists(int id)
    {
        return _context.Donors.Any(e => e.DonorId == id);
    }
}