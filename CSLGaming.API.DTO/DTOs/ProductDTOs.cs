namespace CSLGaming.API.DTO
{
    public class ProductPostDTO
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public double Rating { get; set; }
        public int ReleaseYear { get; set; }
        public string? PictureUrl { get; set; }
        public string Description { get; set; } = string.Empty;
		public int? AgeRestrictionId { get; set; }
	}

    public class ProductPutDTO : ProductPostDTO
    {
        public int Id { get; set; }
    }

    public class ProductGetDTO : ProductPutDTO
    {
        // public List<FilterGetDTO>? Filters { get; set; }
        public AgeRestrictionGetDTO? AgeRestriction { get; set; }
        public List<CategoryGetDTO>? Categories { get; set; }
        public List<GenereGetDTO>? Generes { get; set; }

    }

    public class ProductSmallGetDTO : ProductPutDTO 
    {
        
    }

}
