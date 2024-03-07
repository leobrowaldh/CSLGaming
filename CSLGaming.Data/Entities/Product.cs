
namespace CSLGaming.Data;

public class Product : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; } = 0;
    public double Rating { get; set; } = 0;
    public int ReleaseYear { get; set; } = 0;
    public string Description { get; set; } = string.Empty;
    public string PictureUrl { get; set; } = string.Empty;
    public int? AgeRestrictionId { get; set; } 
    public AgeRestriction? AgeRestriction { get; set; } 
    public List<Category>? Categories { get; set; }
    public List<Genere>? Generes { get; set; }
    
}
