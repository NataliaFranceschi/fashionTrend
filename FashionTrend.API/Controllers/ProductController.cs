using Microsoft.AspNetCore.Mvc;
using MediatR;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductRequest request)
    {
        var product = await _mediator.Send(request);
        return Ok(product);
    }
}