using AutoMapper;
using MediatR;


public sealed class DeleteSupplierHandler : IRequestHandler<DeleteSupplierRequest, DeleteSupplierResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISupplierRepository _supplierRepository;
    private readonly IMapper _mapper;

    public DeleteSupplierHandler(IUnitOfWork unitOfWork,
                             ISupplierRepository supplierRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _supplierRepository = supplierRepository;
        _mapper = mapper;
    }

    public async Task<DeleteSupplierResponse> Handle(DeleteSupplierRequest request,
                                                 CancellationToken cancellationToken)
    {

        var user = await _supplierRepository.Get(request.Id, cancellationToken);

        if (user == null) return default;

        _supplierRepository.Delete(user);
        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<DeleteSupplierResponse>(user);
    }
}
