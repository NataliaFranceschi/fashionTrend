using AutoMapper;
using MediatR;


public class CreateDraftContractHandle : IRequestHandler<CreateDraftContractRequest, CreateDraftContractResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly IDraftContractRepository _repository;

    private readonly IMapper _mapper;
    public CreateDraftContractHandle(IUnitOfWork unitOfWork, IDraftContractRepository draftContract, IMapper mapper )
    {
        _mapper = mapper;
        _repository = draftContract;
        _unitOfWork = unitOfWork;

    }

    public async Task<CreateDraftContractResponse> Handle(CreateDraftContractRequest request, CancellationToken cancellationToken)
    {
        //validar se o usuário que esta sendo inserido no contrato existe no banco
        var draft = _mapper.Map<DraftContract>(request);
        _repository.Create(draft);

        await _unitOfWork.Commit(cancellationToken);

        var notificaton = new CreateNotificationHandler("AC705875abfac3bd8ffe96712d2184af3f",
            "754eb0223d1b2e287f97a26dc12d4743", "+14842763066");

        notificaton.SendSMS("+5514997784271", "Olá, temos uma minuta de contrato disponível para assinatura");
        //request.User.Telephone,

        return _mapper.Map<CreateDraftContractResponse>(draft);

    }
}