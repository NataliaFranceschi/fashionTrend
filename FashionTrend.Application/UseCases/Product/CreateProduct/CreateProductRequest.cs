using MediatR;

public sealed record CreateProductRequest(
    string Name,
    string Description,
    Material Material
    ) : IRequest<CreateProductResponse>;
