public sealed class Service : BaseEntity
{
    public string Description { get; set; }
    public RequestType Type { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }   
    public double UnitPrice { get; set; } 
    public double TotalPrice { get; set; }
    public bool Available { get; set; }
    public int ServiceDays { get; set; }

    public Service()
    {
        TotalPrice = UnitPrice * Quantity;
        Available = true;
    }
}

