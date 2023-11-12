using MediatR;

public sealed record CreateProductRequest(
    string Name,
    string Description,
    List<Material> Materials
    ) : IRequest<CreateProductResponse>;
