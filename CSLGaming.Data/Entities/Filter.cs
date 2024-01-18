
using CSLGaming.Data.Shared.Enums;

namespace CSLGaming.Data.Entities;

public class Filter : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string TypeName { get; set; }
    public enOptionType OptionType { get; set; }
}