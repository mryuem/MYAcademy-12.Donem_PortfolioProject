using Microsoft.AspNetCore.Mvc;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;

namespace MYAcademy_PortfolioProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultMessageComponentPartial:ViewComponent
    {


        public IViewComponentResult Invoke()
        {
            return View(new Message());
        }
    }
}
