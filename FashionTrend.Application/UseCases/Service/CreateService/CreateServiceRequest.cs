using MediatR;

public sealed record CreateServiceRequest(
    string Description,
    RequestType Type,
    Guid ProductId,
    int Quantity,
    double UnitPrice,
    int ServiceDays
    ) : IRequest<CreateServiceResponse>;
