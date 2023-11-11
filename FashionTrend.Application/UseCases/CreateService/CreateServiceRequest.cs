using MediatR;

public sealed record CreateServiceRequest(
    string Description,
    bool Delivery,
    RequestType Type,
    List<Material> Materials,
    List<SewingMachine> SewingMachines
    ) : IRequest<CreateServiceResponse>;
