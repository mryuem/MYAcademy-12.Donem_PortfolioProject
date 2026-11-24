using Microsoft.AspNetCore.Mvc;
using MYAcademy_PortfolioProject.Context;

namespace MYAcademy_PortfolioProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultAboutComponentViewPartial:ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultAboutComponentViewPartial(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var value=  _context.Abouts.FirstOrDefault() ?? new Entities.About();
            return View(value);
        }
    }
}
