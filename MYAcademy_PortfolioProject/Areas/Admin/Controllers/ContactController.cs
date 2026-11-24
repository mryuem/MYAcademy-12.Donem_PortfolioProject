using Microsoft.AspNetCore.Mvc;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;

namespace MYAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly PortfolioContext _context;
        public ContactController(PortfolioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ContactIndex()
        {
            var value = _context.Contacts.FirstOrDefault() ?? new Contact();
            return View(value);
        }
        [HttpPost]
        public IActionResult ContactIndex(Contact contact)
        {
            if (contact.ContactId == 0)
            {
                _context.Contacts.Add(contact);
            }
            else
            {
                _context.Contacts.Update(contact);
            }
            _context.SaveChanges();
            return RedirectToAction("ContactIndex");
        }

    }
}
