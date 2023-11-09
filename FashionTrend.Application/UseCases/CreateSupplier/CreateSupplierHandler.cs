using AutoMapper;
using MediatR;

public class CreateUserHandler : IRequestHandler<CreateSupplierRequest, CreateSupplierResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISupplierRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUserHandler(IUnitOfWork unitOfWork, ISupplierRepository userRepository,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<CreateSupplierResponse> Handle(CreateSupplierRequest request, CancellationToken cancellationToken)
    {
        var supplier = _mapper.Map<Supplier>(request);

        _userRepository.Create(supplier);

        await _unitOfWork.Commit(cancellationToken);
        return _mapper.Map<CreateSupplierResponse>(supplier);
    }
}