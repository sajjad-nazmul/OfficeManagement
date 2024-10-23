namespace OfficeManagement.Components.ViewModels
{
    public class BreadcrumbItem
    {
        public string Text { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }

        public BreadcrumbItem(string text, string link, bool isActive = false)
        {
            Text = text;
            Link = link;
            IsActive = isActive;
        }
    }
}
