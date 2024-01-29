
namespace CSLGaming.Data;

public class AgeRestriction : IEntity
{
    public int Id { get; set; }
    public enAgeRestriction Age { get; set; }
    public List<CategoryProduct>? Products { get; set; }
    public enOptionType OptionType { get; set; }
}