
namespace CSLGaming.Data.Entities;

public class AgeRestriction : IEntity
{
    public int Id { get; set; }
    public enAgeRestriction Age { get; set; }
    public List<Product>? Products { get; set; }
    public enOptionType OptionType { get; set; }
}