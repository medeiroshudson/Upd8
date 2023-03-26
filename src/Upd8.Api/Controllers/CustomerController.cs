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
        var query = new GetAllCustomersQuery();
        var customers = await _mediator.Send(query);

        return Ok(customers);
    }

    [HttpGet("{CustomerId}")]
    public async Task<IActionResult> FindById(Guid customerId)
    {
        var query = new GetCustomerByIdQuery(customerId);
        var customer = await _mediator.Send(query);

        return Ok(customer);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Customer customer)
    {
        var command = new CreateCustomerCommand() { Customer = customer };
        var result = await _mediator.Send(command);

        return Ok(result);
    }
}
