using MYAcademy_PortfolioProject.Entities;

namespace MYAcademy_PortfolioProject.Models
{
    public class DashBoardViewModel
    {
        public int TotalMessages { get; set; }
        public int UnreadMessages { get; set; }
        public int ReadMessages { get; set; }

        public int SkillCount { get; set; }
        public int ExperienceCount { get; set; }
        public int EducationCount { get; set; }

        public int ReadRate { get; set; }

        public List<string> WeekLabels { get; set; }
        public List<int> WeekCounts { get; set; }

        public List<Message> LastMessages { get; set; }
        public List<CategoryProjectCountViewModel> CategoryStats { get; set; } = new();

    }
}
