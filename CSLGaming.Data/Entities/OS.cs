﻿
namespace CSLGaming.Data.Entities;

internal class OS : IEntity
{
    public int Id { get; set; }
    public enOS OSType { get; set; }
    public List<Product>? Products { get; set; }
}