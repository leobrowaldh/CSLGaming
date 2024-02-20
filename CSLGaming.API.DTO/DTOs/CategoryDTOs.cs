
namespace CSLGaming.API.DTO;

public class CategoryPostDTO
{
    public string CategoryType { get; set; } = string.Empty;
    //public enOptionType OptionType { get; set; }
}
public class CategoryPutDTO : CategoryPostDTO
{
    public int Id { get; set; }
}
public class CategoryGetDTO : CategoryPutDTO
{
    //public List<FilterGetDTO>? Filters { get; set; }

}
public class CategorySmallGetDTO : CategoryPutDTO
{

}