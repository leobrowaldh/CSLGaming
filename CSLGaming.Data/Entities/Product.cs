
namespace CSLGaming.Data.Entities;

public class CategoryProduct : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public double Rating { get; set; }
    public int ReleaseYear { get; set; }
    public List<Category>? Categories { get; set; }
    public List<Genere>? Generes { get; set; }
    public AgeRestriction? AgeRestriction { get; set; } 

}
