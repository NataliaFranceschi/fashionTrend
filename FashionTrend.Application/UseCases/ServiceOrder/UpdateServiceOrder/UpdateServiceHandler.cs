using AutoMapper;
using MediatR;

public class UpdateServiceOrderHandler : IRequestHandler<UpdateServiceOrderRequest, UpdateServiceOrderResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceOrderRepository _serviceOrderRepository;
    private readonly IMapper _mapper;

    public UpdateServiceOrderHandler(IUnitOfWork unitOfWork, IServiceOrderRepository serviceOrderRepository,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _serviceOrderRepository = serviceOrderRepository;
        _mapper = mapper;
    }

    public async Task<UpdateServiceOrderResponse> Handle(UpdateServiceOrderRequest command, CancellationToken cancellationToken)
    {
        var serviceOrder = await _serviceOrderRepository.Get(command.Id, cancellationToken);

        if (serviceOrder is null) return default;

        serviceOrder.Payed = command.Payed;

        serviceOrder.Status = command.Status;

        _serviceOrderRepository.Update(serviceOrder);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<UpdateServiceOrderResponse>(serviceOrder);
    }
}
