using System.Text;
using Newtonsoft.Json;
using Upd8.Web.Models;

namespace Upd8.Web.Repositories.Backend.Customer;

public class CustomerRepository : ICustomerRepository
{
    private readonly HttpClient _httpClient;
    public CustomerRepository(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient(BackendClient.ClientName);
    }

    public async Task<List<CustomerViewModel>> GetAllAsync()
    {
        var customers = new List<CustomerViewModel>();
        var request = new HttpRequestMessage(HttpMethod.Get, $"customer");

        using (var response = await _httpClient.SendAsync(request))
        {
            if (response.Content == null)
                return customers;

            var json = await response.Content.ReadAsStringAsync();
            customers = JsonConvert.DeserializeObject<List<CustomerViewModel>>(json);
        }

        return customers!;
    }

    public async Task<CustomerViewModel?> GetByIdAsync(Guid customerId)
    {
        var customer = new CustomerViewModel();
        var request = new HttpRequestMessage(HttpMethod.Get, $"customer/{customerId}");

        using (var response = await _httpClient.SendAsync(request))
        {
            if (response.Content == null)
                return customer;

            var json = await response.Content.ReadAsStringAsync();
            customer = JsonConvert.DeserializeObject<CustomerViewModel>(json);
        }

        return customer;
    }

    public async Task CreateAsync(CustomerViewModel customer)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"customer");

        request.Content = new StringContent(
            JsonConvert.SerializeObject(customer), 
            System.Text.Encoding.UTF8, 
            "application/json"
        );

        using (var response = await _httpClient.SendAsync(request))
        {
            if (!response.IsSuccessStatusCode)
                return;
        }
    }

    public async Task UpdateAsync(CustomerViewModel customer)
    {
        var request = new HttpRequestMessage(HttpMethod.Put, $"customer/{customer.Id}");

        request.Content = new StringContent(
            JsonConvert.SerializeObject(customer), 
            Encoding.UTF8, "application/json"
        );

        Console.WriteLine(JsonConvert.SerializeObject(customer));

        using (var response = await _httpClient.SendAsync(request))
        {
            if (!response.IsSuccessStatusCode)
                return;
        }
    }

    public async Task DeleteAsync(Guid customerId)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, $"customer/{customerId}");

        using (var response = await _httpClient.SendAsync(request))
        {
            if (!response.IsSuccessStatusCode)
                return;
        }
    }
}
