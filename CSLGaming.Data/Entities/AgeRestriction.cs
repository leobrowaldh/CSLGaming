
namespace CSLGaming.Data;

public class AgeRestriction : IEntity
{
    public int Id { get; set; }
    public int Age { get; set; }
    public enOptionType OptionType { get; set; }
    public List<Product>? Products { get; set; }
}