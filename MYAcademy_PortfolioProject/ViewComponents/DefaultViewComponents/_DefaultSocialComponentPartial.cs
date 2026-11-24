using Microsoft.AspNetCore.Mvc;
using MYAcademy_PortfolioProject.Context;

namespace MYAcademy_PortfolioProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultSocialComponentPartial:ViewComponent
    {
        private readonly PortfolioContext _portfolioContext;

        public _DefaultSocialComponentPartial(PortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
