using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;

namespace MYAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillController : Controller
    {
        private readonly PortfolioContext _context;

        public SkillController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult SkillIndex()
        {
            var values = _context.Skills.Include(x=>x.SkillItems).ToList();
            return View(values);
        }

        public IActionResult CreateSkill()
        {
            ViewBag.SkillItems=_context.SkillItems.ToList();
            return View();
        }

        
        [HttpPost]
        public IActionResult CreateSkill(Skill skill, List<int> selectedSkillItems)
        {
            skill.SkillItems = _context.SkillItems
                .Where(x => selectedSkillItems.Contains(x.SkillItemId))
                .ToList();

            _context.Skills.Add(skill);
            _context.SaveChanges();

            return RedirectToAction("SkillIndex");
        }

        public IActionResult DeleteSkill(int id)
        {
            var value = _context.Skills.Find(id);
            _context.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("SkillIndex");
        }
        public IActionResult UpdateSkill(int id)
        {
            var value = _context.Skills.Find(id);
            ViewBag.SkillItems = new SelectList(_context.SkillItems.ToList(), "SkillItemId", "SkillItemTitle");
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateSkill(Skill skill)
        {
            _context.Update(skill);
            _context.SaveChanges();
            return RedirectToAction("SkillIndex");
        }
    }
}
