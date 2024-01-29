
namespace CSLGaming.Data.Entities;

public class Category : IEntity
{
    public int Id { get; set; }
    public enCategory CategoryType { get; set; }
    public List<CategoryProduct>? Products { get; set; }
    public enOptionType OptionType { get; set; }
}