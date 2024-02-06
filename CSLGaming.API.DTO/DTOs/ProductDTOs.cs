namespace CSLGaming.API.DTO
{
    public class ProductPostDTO
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public double Rating { get; set; }
        public int ReleaseYear { get; set; }
        public string? PictureUrl { get; set; }
    }

    public class ProductPutDTO : ProductPostDTO
    {
        public int Id { get; set; }
    }

    public class ProductGetDTO : ProductPutDTO
    {
        // public List<FilterGetDTO>? Filters { get; set; } - Kommer användas för att kunna få med allt, beroende på filter
        public AgeRestrictionSmallGetDTO? AgeRestriction { get; set; }
        public List<CategorySmallGetDTO>? Categories { get; set; }
        public List<GenereSmallGetDTO>? Generes { get; set; }

    }

    public class ProductSmallGetDTO : ProductPutDTO 
    {
        
    }

}
