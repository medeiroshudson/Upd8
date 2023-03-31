using Upd8.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Upd8.Web.Repositories.Backend.Customer;

namespace Upd8.Web.Controllers;

public class CustomerController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICustomerRepository _customerRepository;
    public CustomerController(ILogger<HomeController> logger, ICustomerRepository customerRepository)
    {
        _logger = logger;
        _customerRepository = customerRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var customers = await _customerRepository.GetAllAsync();
        return View(customers);
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        return View(customer);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CustomerViewModel model)
    {
        await _customerRepository.CreateAsync(model);
        return RedirectToAction("Index", "Customer");
    }

    [HttpPost]
    public async Task<IActionResult> Update(CustomerViewModel model)
    {
        await _customerRepository.UpdateAsync(model);
        return RedirectToAction("Index", "Customer");
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid customerId)
    {
        await _customerRepository.DeleteAsync(customerId);
        return RedirectToAction("Index", "Customer");
    }

    #region Partials

    [HttpPost]
    public IActionResult CreatePartialView()
    {
        return PartialView("_CreateCustomerPartialView", new CustomerViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> EditPartialView(Guid customerId)
    {
        var customer = await _customerRepository.GetByIdAsync(customerId);
        return PartialView("_EditCustomerPartialView", customer);
    }

    #endregion
}
