using Microsoft.AspNetCore.Mvc;
using MediatR;

[Route("api/[controller]")]
[ApiController]
public class ServiceController : ControllerBase
{
    IMediator _mediator;

    public ServiceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateServiceRequest request)
    {
        var service = await _mediator.Send(request);
        return Ok(service);
    }
}