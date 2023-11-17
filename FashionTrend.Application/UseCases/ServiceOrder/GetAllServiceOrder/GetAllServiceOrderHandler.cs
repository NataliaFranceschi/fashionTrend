﻿using AutoMapper;
using MediatR;


public sealed class GetAllServiceOrderHandler : IRequestHandler<GetAllServiceOrderRequest, List<GetAllServiceOrderResponse>>
{
    private readonly IServiceOrderRepository _serviceOrderRepository;
    private readonly IMapper _mapper;

    public GetAllServiceOrderHandler(IServiceOrderRepository serviceOrderRepository, IMapper mapper)
    {
        _serviceOrderRepository = serviceOrderRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllServiceOrderResponse>> Handle(GetAllServiceOrderRequest request, CancellationToken cancellationToken)
    {
        var serviceOrder = await _serviceOrderRepository.GetAll(cancellationToken);
        return _mapper.Map<List<GetAllServiceOrderResponse>>(serviceOrder);
    }
}
