using Microsoft.AspNetCore.Mvc;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;

namespace MYAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("admin")]
    public class EducationController : Controller
    {
        private readonly PortfolioContext _context;

        public EducationController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult EducationIndex()
        {
            var values=_context.Educations.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateEducation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateEducation(Education education) 
        {
           _context.Educations.Add(education);
            _context.SaveChanges();
         return   RedirectToAction("EducationIndex");
        }

        public IActionResult UpdateEducation(int id)
        {
            var value=_context.Educations.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateEducation(Education education)
        {
            _context.Educations.Update(education);
            _context.SaveChanges();
            return RedirectToAction("EducationIndex");
        }
        public IActionResult DeleteEducation(int id) {

            var value = _context.Educations.Find(id);
            _context.Educations.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("EducationIndex");

        }
    }
}
