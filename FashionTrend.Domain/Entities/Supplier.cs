﻿public sealed class Supplier : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<Material> Materials { get; set; }
    public List<SewingMachine> SewingMachines { get; set; }
}
