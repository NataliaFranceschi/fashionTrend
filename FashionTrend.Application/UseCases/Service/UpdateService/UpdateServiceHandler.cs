using AutoMapper;
using MediatR;

public class UpdateServiceHandler : IRequestHandler<UpdateServiceRequest, UpdateServiceResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceRepository _serviceRepository;
    private readonly IMapper _mapper;

    public UpdateServiceHandler(IUnitOfWork unitOfWork, IServiceRepository serviceRepository,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _serviceRepository = serviceRepository;
        _mapper = mapper;
    }

    public async Task<UpdateServiceResponse> Handle(UpdateServiceRequest command, CancellationToken cancellationToken)
    {
        try
        {
            var service = await _serviceRepository.Get(command.Id, cancellationToken);

            if (service is null) { throw new ArgumentException("Service not found");}

                service.Description = command.Description;
            service.Type = command.Type;
            service.ProductId = command.ProductId;
            service.SewingMachines = command.SewingMachines;
            service.Quantity = command.Quantity;
            service.UnitPrice = command.UnitPrice;
            service.ServiceDays = command.ServiceDays;

            _serviceRepository.Update(service);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<UpdateServiceResponse>(service);

        } catch (Exception) { throw; }
    }
}
