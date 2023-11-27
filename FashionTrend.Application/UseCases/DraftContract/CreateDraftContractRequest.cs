using MediatR;

public sealed record CreateDraftContractRequest(Supplier User, string Description)
    : IRequest<CreateDraftContractResponse>;