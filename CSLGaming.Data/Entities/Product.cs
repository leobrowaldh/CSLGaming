
namespace CSLGaming.Data.Entities;

internal class Product : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public double Rating { get; set; }
    public int ReleaseYear { get; set; }

}
