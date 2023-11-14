public sealed record CreateProductResponse
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Material Material { get; set; }

}