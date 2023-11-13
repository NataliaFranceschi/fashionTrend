using MediatR;

public sealed record CreateServiceOrderRequest(
    Guid SupplierId,
    Guid ServiceId
    ) : IRequest<CreateServiceOrderResponse>;
