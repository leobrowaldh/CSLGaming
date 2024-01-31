namespace CSLGaming.API.DTO;

public class ProductAgeRestrictionPostDTO
{
    public int GenereId { get; set; }
    public int ProductId { get; set; }
}
public class ProductAgeRestrictionDeleteDTO : ProductAgeRestrictionPostDTO
{
}
public class ProductAgeRestrictionGetDTO : ProductAgeRestrictionPostDTO
{
}

public class ProductAgeRestrictionSmallGetDTO
{
    public int GenereId { get; set; }
}