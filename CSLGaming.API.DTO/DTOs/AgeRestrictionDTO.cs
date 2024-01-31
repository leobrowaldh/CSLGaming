
namespace CSLGaming.API.DTO;

public class AgeRestrictionPostDTO
{
    public enAgeRestriction Age { get; set; }
    public enOptionType OptionType { get; set; }
}
public class AgeRestrictionPutDTO : AgeRestrictionPostDTO
{
    public int Id { get; set; }
}
public class AgeRestrictionGetDTO : AgeRestrictionPutDTO
{
    //public List<FilterGetDTO>? Filters { get; set; }

}
public class AgeRestrictionSmallGetDTO : AgeRestrictionPutDTO
{

}