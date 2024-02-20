

namespace CSLGaming.Data;

public class Category : IEntity
{
    public int Id { get; set; }
    public string CategoryType { get; set; } = string.Empty;
    public enOptionType? OptionType { get; set; }
    public List<Product>? Products { get; set; }
    public List<Filter>? Filters { get; set; }
}