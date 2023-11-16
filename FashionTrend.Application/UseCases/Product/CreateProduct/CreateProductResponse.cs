﻿public sealed record CreateProductResponse
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ClothingType ClothingType { get; set; }
    public List<Material> Materials { get; set; }

}