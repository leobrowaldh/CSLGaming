
namespace CSLGaming.Data.Entities;

internal class AgeRestriction : IEntity
{
    public int Id { get; set; }
    public enAgeRestriction Age { get; set; }
    public List<Product>? Products { get; set; }
}