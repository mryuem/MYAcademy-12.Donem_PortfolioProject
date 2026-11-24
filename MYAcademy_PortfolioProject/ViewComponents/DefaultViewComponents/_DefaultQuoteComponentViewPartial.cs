using Microsoft.AspNetCore.Mvc;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;

namespace MYAcademy_PortfolioProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultQuoteComponentViewPartial:ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultQuoteComponentViewPartial(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var value=_context.Quotes.FirstOrDefault() ?? new Quote(); 
            return View(value);
        }
    }
}
