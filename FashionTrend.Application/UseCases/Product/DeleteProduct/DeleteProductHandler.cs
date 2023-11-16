using AutoMapper;
using MediatR;


public sealed class DeleteProductHandler : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public DeleteProductHandler(IUnitOfWork unitOfWork,
                             IProductRepository productRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<DeleteProductResponse> Handle(DeleteProductRequest request,
                                                 CancellationToken cancellationToken)
    {

        var product = await _productRepository.Get(request.Id, cancellationToken);

        if (product == null) return default;

        _productRepository.Delete(product);
        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<DeleteProductResponse>(product);
    }
}
