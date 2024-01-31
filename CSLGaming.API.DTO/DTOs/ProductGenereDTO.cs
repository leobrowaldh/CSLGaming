namespace CSLGaming.API.DTO;

public class ProductGenerePostDTO
{
    public int GenereId { get; set; }
    public int ProductId { get; set; }
}
public class ProductGenereDeleteDTO : ProductGenerePostDTO
{
}
public class ProductGenereGetDTO : ProductGenerePostDTO
{
}

public class ProductGenereSmallGetDTO
{
    public int GenereId { get; set; }
}