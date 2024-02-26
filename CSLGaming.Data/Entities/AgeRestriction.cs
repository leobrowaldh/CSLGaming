
namespace CSLGaming.Data;

public class AgeRestriction : IEntity
{
    public int Id { get; set; }
    //3, 7, 12, 16, 18 are the possible age restrictions
    public int Age { get; set; }
    public enOptionType OptionType { get; set; }
    public List<Product>? Products { get; set; }
}