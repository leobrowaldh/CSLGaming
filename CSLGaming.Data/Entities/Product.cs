﻿
namespace CSLGaming.Data;

public class Product : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public double Rating { get; set; }
    public int ReleaseYear { get; set; }
    public string? PictureUrl { get; set; }
    public int? AgeRestrictionId { get; set; } // Denna är inte nullable så crashar
    public AgeRestriction? AgeRestriction { get; set; } 
    public List<Category>? Categories { get; set; }
    public List<Genere>? Generes { get; set; }
    
}
