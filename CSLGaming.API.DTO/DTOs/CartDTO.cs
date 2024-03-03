namespace CSLGaming.API.DTO;

public class CartDTO
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? PictureUrl { get; set; }
    public CategoryGetDTO SelectedCategory { get; set; }
}
