
namespace CSLGaming.UI.Models.Link
{
    public class LinkGroup
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<LinkOption> LinkOptions { get; set; } = [];
    }
}
