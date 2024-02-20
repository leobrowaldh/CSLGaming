
namespace CSLGaming.API.DTO;

public class GenerePostDTO
{
    public string GenereType { get; set; } = string.Empty;
    //public enOptionType OptionType { get; set; }
}
public class GenerePutDTO : GenerePostDTO
{
    public int Id { get; set; }
}
public class GenereGetDTO : GenerePutDTO
{
    //public List<FilterGetDTO>? Filters { get; set; }
    

}
public class GenereSmallGetDTO : GenerePutDTO
{
    //public List<ProductGetDTO>? Products { get; set; }
}