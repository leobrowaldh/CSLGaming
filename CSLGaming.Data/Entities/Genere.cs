﻿
namespace CSLGaming.Data;

public class Genere : IEntity
{
    public int Id { get; set; }
    public enGenere GenereType { get; set; }
    public enOptionType OptionType { get; set; }
    public List<Product>? Products { get; set; }
}