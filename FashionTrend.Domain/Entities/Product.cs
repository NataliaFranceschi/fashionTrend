﻿public sealed class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; } 
    public List<Material> Materials { get; set; }
}