using Microsoft.AspNetCore.Mvc;
using BloodDonationManagement.Models;

namespace BloodDonationManagement.Controllers
{
    public class QueryController : Controller
    {
        private readonly BloodDonationDbContext _context;

        public QueryController(BloodDonationDbContext context)
        {
            _context = context;
        }


        public IActionResult FilterByBloodGroup(string bloodGroup)
        {
            var donors = _context.Donors
                .Where(d => d.BloodGroup == bloodGroup)
                .ToList();

            return View(donors);
        }

 

        public IActionResult SortByLastDonationDate()
        {
            var donations = _context.Donations
                .OrderByDescending(d => d.DonationDate)
                .ToList();

            return View(donations);
        }
        public IActionResult TotalBloodVolume()
        {
            var totalVolume = _context.Donations
                .Sum(d => d.VolumeMl);

            ViewBag.TotalVolume = totalVolume;

            return View();
        }
    }
}