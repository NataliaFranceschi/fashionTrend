
public sealed record GetAllSupplierResponse
{
    public string Name { get; set; }
    public string Email { get; set; }
    public List<Material> Materials { get; set; }
    public List<SewingMachine> SewingMachines { get; set; }
}
