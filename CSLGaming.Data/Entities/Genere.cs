
namespace CSLGaming.Data.Entities;

internal class Genere : IEntity
{
    public int Id { get; set; }
    public enGenere GenereType { get; set; }
    public List<Product>? Products { get; set; }
}