using MediatR;

public sealed record CreateProductRequest(
    string Name,
    string Description,
    string Material,
    ClothingType ClothingType
    ) : IRequest<CreateProductResponse>;
