namespace MYAcademy_PortfolioProject.Entities
{
    public class ProjectItem
    {
        public int ProjectItemId { get; set; }
        public string ProjectItemTitle { get; set; }

        public List<Project> Projects { get; set; }

    }
}
