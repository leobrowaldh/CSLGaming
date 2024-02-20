
namespace CSLGaming.Data;

public class Genere : IEntity
{
    public int Id { get; set; }
    public string GenereType { get; set; } = string.Empty;
    public enOptionType OptionType { get; set; }
    public List<Product>? Products { get; set; }
}