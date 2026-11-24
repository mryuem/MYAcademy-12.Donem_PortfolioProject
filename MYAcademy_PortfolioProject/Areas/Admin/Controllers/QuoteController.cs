using Microsoft.AspNetCore.Mvc;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;

namespace MYAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("admin")]
    public class QuoteController : Controller
    {
       private readonly PortfolioContext _context;

        public QuoteController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult QuoteIndex()
        {
            var value = _context.Quotes.FirstOrDefault() ?? new Quote();
            return View(value);
        }
        [HttpPost]
        public IActionResult QuoteIndex(Quote quote) 
        {
            if (quote.QuoteId == 0)
            {
                _context.Quotes.Add(quote);
            }
            else
            {
                _context.Quotes.Update(quote);
            } 
            _context.SaveChanges();
            return RedirectToAction("QuoteIndex");
        }
    }
}
