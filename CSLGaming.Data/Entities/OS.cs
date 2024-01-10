
namespace CSLGaming.Data.Entities;

public class OS : IEntity
{
    public int Id { get; set; }
    public enOS OSType { get; set; }
    public List<Product>? Products { get; set; }
}