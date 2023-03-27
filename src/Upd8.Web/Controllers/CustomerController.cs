using Upd8.Web.Models;
using Upd8.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult Index()
    {
        var customers = _customerRepository.GetAll();
        return View(customers);
    }

    public IActionResult Details(Guid id)
    {
        var customer = _customerRepository.GetById(id);
        return View(customer);
    }

    [HttpPost]
    public IActionResult Edit(Guid customerId)
    {
        var customer = _customerRepository.GetById(customerId);

        return PartialView("_EditCustomerPartialView", customer);
    }

    [HttpPost]
    public IActionResult Update(CustomerViewModel model)
    {
        _customerRepository.Update(model);

        Console.WriteLine(model.Id);
        Console.WriteLine(model.Name);
        Console.WriteLine(model.Document);
        Console.WriteLine(model.BirthDate);
        Console.WriteLine(model.Address?.StreetName);

        return RedirectToAction("Index", "Customer");
    }

    [HttpDelete]
    public IActionResult Delete(Guid customerId)
    {
        _customerRepository.Delete(customerId);
        return RedirectToAction("Index", "Customer");
    }
}
