using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;

namespace MYAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExperienceController : Controller
    {
        private readonly PortfolioContext _context;
        public ExperienceController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult ExperienceList()
        {
            var values = _context.Experiences.Include(x => x.Category).ToList();
            ViewBag.TotalCount = values.Count();
            ViewBag.ActiveCount = values.Count(x => x.IsActive);
            ViewBag.PassiveCount = values.Count(x => !x.IsActive);

            // Hızlı Ekle kartındaki kategori dropdown'ı için eklendi:
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName");

            return View(values);
        }

        [HttpPost]
        public IActionResult QuickAddExperience([FromBody] Experience experience)
        {
            if (string.IsNullOrWhiteSpace(experience.Title) || string.IsNullOrWhiteSpace(experience.CompanyName))
            {
                return BadRequest(new { success = false, message = "Başlık ve Şirket alanları zorunludur." });
            }

            _context.Experiences.Add(experience);
            _context.SaveChanges();

            // Tabloda kategori adını gösterebilmek için kategori bilgisini çekiyoruz
            var categoryName = _context.Categories
                .Where(c => c.CategoryId == experience.CategoryId)
                .Select(c => c.CategoryName)
                .FirstOrDefault() ?? "-";

            return Ok(new
            {
                success = true,
                data = new
                {
                    experienceId = experience.ExperienceId,
                    title = experience.Title,
                    companyName = experience.CompanyName,
                    categoryName = categoryName,
                    description = experience.Description ?? "",
                    isActive = experience.IsActive
                }
            });
        }
        [HttpGet]
        public IActionResult CreateExperience()
        {
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        public IActionResult CreateExperience(Experience experience)
        {
            _context.Add(experience);
            _context.SaveChanges();
            return RedirectToAction("ExperienceList");
        }

        [HttpGet]
        public IActionResult UpdateExperience(int id) 
        {
            var value = _context.Experiences.Find(id);
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName");
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateExperience(Experience experience)
        {
            _context.Update(experience);
            _context.SaveChanges();
            return RedirectToAction("ExperienceList");
        }
        public IActionResult DeleteExperience(int id)
        {
            var value = _context.Experiences.Find(id);
            _context.Experiences.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("ExperienceList");
        }

        public IActionResult ChangeStatus(int id)
        {
            var value=_context.Experiences.Find(id);
            if(value==null) return NotFound();
             value.IsActive= !value.IsActive;
            _context.SaveChanges();
            return RedirectToAction("ExperienceList");
        }
    }

}
