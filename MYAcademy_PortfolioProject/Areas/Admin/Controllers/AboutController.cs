using Microsoft.AspNetCore.Mvc;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;


namespace MYAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly PortfolioContext _context;
        private readonly IWebHostEnvironment _env;

        public AboutController(PortfolioContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult AboutIndex()
        {
            var value= _context.Abouts.FirstOrDefault() ?? new About();
            return View(value);
        }

        [HttpPost]
        public IActionResult AboutIndex(About about, IFormFile? cvFile,IFormFile? imageFile)
        {
            if(cvFile != null && cvFile.Length > 0)
            {
                
                var extension =Path.GetExtension(cvFile.FileName).ToLowerInvariant();
                if(extension != ".pdf")
                {
                    ViewBag.Error = "Sadece PDF dosyası yükleyebilirsiniz.";
                    return View(about);
                }

                var folder=Path.Combine(_env.WebRootPath,"cv");
                Directory.CreateDirectory(folder);

                var fileName = Guid.NewGuid().ToString() + extension;
                using (var stream = new FileStream(Path.Combine(folder, fileName), FileMode.Create))
                {
                    cvFile.CopyTo(stream);
                }

                about.CvUrl = "/cv/" + fileName;
            }

            if (imageFile != null && imageFile.Length > 0)
            {
                var extension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();

                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp" };

                if (!allowedExtensions.Contains(extension))
                {
                    ViewBag.ImageError = "Sadece JPG, JPEG, PNG ve WEBP dosyaları yükleyebilirsiniz.";
                    return View(about);
                }

                var folder = Path.Combine(_env.WebRootPath, "images", "about");
                Directory.CreateDirectory(folder);

                var fileName = Guid.NewGuid().ToString() + extension;

                using (var stream = new FileStream(Path.Combine(folder, fileName), FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                about.ImageUrl = "/images/about/" + fileName;
            }

            if (about.AboutId == 0)
            {
                _context.Abouts.Add(about);
            }
           else
            {
                 _context.Abouts.Update(about);
            }
            _context.SaveChanges();
            return RedirectToAction("AboutIndex");
        }
    }
}
