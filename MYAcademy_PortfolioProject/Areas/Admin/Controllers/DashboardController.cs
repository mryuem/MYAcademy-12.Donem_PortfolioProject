using Microsoft.AspNetCore.Mvc;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Models;
using System.Globalization;

namespace MYAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly PortfolioContext _context;

        public DashboardController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var messages = _context.Messages;

            // Toplam mesaj sayısı
            int total = messages.Count();

            // Okunmamış mesaj sayısı
            int unread = messages.Count(x => !x.IsRead);

            int skills = _context.Skills.Count();

            int experience =_context.Experiences.Count();

            int education =_context.Educations.Count();
            


            // Okunmuş mesaj sayısı
            int read = messages.Count(x => x.IsRead);

            // Okunma oranı
            int rate = total == 0 ? 0 : read * 100 / total;

            // Son 5 mesaj
            var lastMessages = messages
                .OrderByDescending(x => x.SendDate)
                .Take(5)
                .ToList();

            // Son 7 günün başlangıç ve bitiş tarihleri
            DateTime today = DateTime.Today;
            DateTime startDate = today.AddDays(-6);
            DateTime endDate = today.AddDays(1);

            // Son 7 gündeki mesajları getir
            var weeklyMessages = messages
                .Where(x => x.SendDate >= startDate &&
                            x.SendDate < endDate)
                .ToList();

            var labels = new List<string>();
            var counts = new List<int>();

            // Her günün mesaj sayısını hesapla
            for (int i = 0; i < 7; i++)
            {
                DateTime date = startDate.AddDays(i);

                labels.Add(date.ToString("ddd", new CultureInfo("tr-TR")));

                int dailyCount = weeklyMessages.Count(x =>
                    x.SendDate.Date == date.Date);

                counts.Add(dailyCount);
            }

                var categoryStats = _context.Projects
                        .GroupBy(p => p.Category.CategoryName)
                        .Select(g => new CategoryProjectCountViewModel
                     {
                           CategoryName = g.Key,
                           ProjectCount = g.Count()
                    })
                       .OrderByDescending(x => x.ProjectCount)
                       .ToList();

            var model = new DashBoardViewModel
            {
                TotalMessages = total,
                UnreadMessages = unread,
                ReadMessages = read,
                ReadRate = rate,
                WeekLabels = labels,
                WeekCounts = counts,
                LastMessages = lastMessages,
                SkillCount=skills,
                ExperienceCount=experience,
                EducationCount=education,
                CategoryStats = categoryStats
            };

            
            return View(model);
        }
    }
}