public sealed class Service : BaseEntity
{
    public string Description { get; set; }
    public bool Delivery { get; set; }
    public RequestType Type { get; set; }
    public List<Material> Materials { get; set; }
    public List<SewingMachine> SewingMachines { get; set; }
}

