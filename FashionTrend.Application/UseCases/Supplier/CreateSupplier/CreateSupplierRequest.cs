using MediatR;

public sealed record CreateSupplierRequest(
    string Email,
    string Name,
    string Password,
    List<Material> Materials,
    List<SewingMachine> SewingMachines
    ) : IRequest<CreateSupplierResponse>;
