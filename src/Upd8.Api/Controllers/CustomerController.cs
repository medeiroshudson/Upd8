using MediatR;
using Microsoft.AspNetCore.Mvc;
using Upd8.Application.Customer.Command;
using Upd8.Application.Customer.Query;
using Upd8.Domain.Customer;

namespace Upd8.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;
    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetAllCustomersQuery());
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Customer customer)
    {
        var command = new CreateCustomerCommand() { Customer = customer };
        var result = await _mediator.Send(command);

        return Ok(result);
    }
}
