

namespace CSLGaming.Data;

public class Category : IEntity
{
    public int Id { get; set; }
    public enCategory CategoryType { get; set; }
    public enOptionType OptionType { get; set; }
    public List<Product>? Products { get; set; }
    public List<Filter>? Filters { get; set; }
}