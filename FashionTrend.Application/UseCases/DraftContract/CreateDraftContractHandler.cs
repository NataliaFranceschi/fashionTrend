using AutoMapper;
using MediatR;


public class CreateDraftContractHandle : IRequestHandler<CreateDraftContractRequest, CreateDraftContractResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDraftContractRepository _repository;
    private readonly IMapper _mapper;
    private readonly ISupplierRepository _supplierRepository;
    public CreateDraftContractHandle(IUnitOfWork unitOfWork, 
                                    IDraftContractRepository draftContract, 
                                    IMapper mapper,
                                    ISupplierRepository supplierRepository)
    {
        _mapper = mapper;
        _repository = draftContract;
        _unitOfWork = unitOfWork;
        _supplierRepository = supplierRepository;

    }

    public async Task<CreateDraftContractResponse> Handle(CreateDraftContractRequest request, CancellationToken cancellationToken)
    {
        var supplier = await _supplierRepository.Get(request.SupplierId, cancellationToken);
        if (supplier == null) { throw new ArgumentException("Supplier not found"); }

        var draft = _mapper.Map<DraftContract>(request);
        _repository.Create(draft);

        await _unitOfWork.Commit(cancellationToken);

        var notificaton = new CreateNotificationHandler("AC705875abfac3bd8ffe96712d2184af3f",
            "754eb0223d1b2e287f97a26dc12d4743", "+14842763066");

        notificaton.SendSMS(supplier.PhoneNumber, "Olá, temos uma minuta de contrato disponível para assinatura");

        return _mapper.Map<CreateDraftContractResponse>(draft);

    }
}