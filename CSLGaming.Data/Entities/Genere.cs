
namespace CSLGaming.Data.Entities;

public class Genere : IEntity
{
    public int Id { get; set; }
    public enGenere GenereType { get; set; }
    public List<Product>? Products { get; set; }
    public enOptionType OptionType { get; set; }
}