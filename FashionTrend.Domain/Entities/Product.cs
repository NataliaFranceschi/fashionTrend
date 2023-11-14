public sealed class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; } 
    public string Material { get; set; }
    public ClothingType ClothingType { get; set; }
}