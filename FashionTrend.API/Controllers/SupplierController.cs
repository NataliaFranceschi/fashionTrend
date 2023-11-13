﻿using Microsoft.AspNetCore.Mvc;
using MediatR;

[Route("api/[controller]")]
[ApiController]
public class SupplierController : ControllerBase
{
    IMediator _mediator;

    public SupplierController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSupplierRequest request)
    {
        var supplier = await _mediator.Send(request);
        return Ok(supplier);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateSupplierResponse>>
        Update(Guid id, UpdateSupplierRequest request, CancellationToken cancellationToken)
    {
        if (id != request.Id)
        {
            return BadRequest();
        }
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

}