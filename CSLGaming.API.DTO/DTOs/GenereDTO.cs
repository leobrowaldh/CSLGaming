
namespace CSLGaming.API.DTO;

public class GenerePostDTO
{
    public enGenere GenereType { get; set; }
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