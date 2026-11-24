using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MYAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly PortfolioContext _context;
        public ProjectController(PortfolioContext context)
        {
            _context = context;
        }
        public IActionResult ProjectList()
        {
            var values = _context.Projects.Include(x => x.Category)
                .Include(x => x.ProjectItems)
                .ToList();
            return View(values);
        }
        public IActionResult CreateProject()
        {
            ViewBag.Categories=new SelectList(_context.Categories.ToList(),"CategoryId","CategoryName");
            ViewBag.ProjectItems=new MultiSelectList(_context.ProjectItems.ToList(),"ProjectItemId","ProjectItemTitle");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProject(Project project,List<int> selectedProjectItem)
        {
            project.ProjectItems= await _context.ProjectItems.Where(x=>selectedProjectItem.Contains(x.ProjectItemId)).ToListAsync();
            _context.Projects.Add(project);
            _context.SaveChanges();
            return RedirectToAction("ProjectList"); 
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProject(int id)
        {
            var value = await _context.Projects.Include(x=>x.ProjectItems).FirstOrDefaultAsync(x=>x.ProjectId==id);
            ViewBag.Categories=new SelectList(_context.Categories.ToList(),"CategoryId","CategoryName", value.CategoryId);
            var selectedProjectItemIds = value.ProjectItems.Select(x => x.ProjectItemId).ToList();
            ViewBag.ProjectItems= new MultiSelectList(_context.ProjectItems.ToList(), "ProjectItemId", "ProjectItemTitle", selectedProjectItemIds);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProject(Project project, List<int> selectedProjectIds)
        {
            var value = await _context.Projects
                .Include(x => x.ProjectItems)
                .FirstOrDefaultAsync(x => x.ProjectId == project.ProjectId);

            if (value == null)
            {
                return NotFound();
            }

            value.ProjectTitle = project.ProjectTitle;
            value.Description = project.Description;
            value.CategoryId = project.CategoryId;
            value.ImageUrl = project.ImageUrl;

            value.ProjectItems.Clear();
           
                var selectProject = await _context.ProjectItems
                    .Where(t => selectedProjectIds.Contains(t.ProjectItemId))
                    .ToListAsync();

                foreach (var tech in selectProject)
                {
                    value.ProjectItems.Add(tech);
                }
           

            _context.Update(value);
            await _context.SaveChangesAsync();

            return RedirectToAction("ProjectList");
        }
        public IActionResult DeleteProject(int id)
        {
            var value = _context.Projects.Find(id);
            _context.Projects.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("ProjectList");
        }
    }
}