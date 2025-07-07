using BlazorApp.Client.Models;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;

namespace BlazorApp.Client.Services
{
    public class CustomerService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigation;

        public CustomerService(HttpClient http, NavigationManager navigation)
        {
            _http = http;
            _navigation = navigation;
        }

        private string GetBaseUri(Guid? id = null, int page = 0, int pageSize = 0, string? searchTerm = null)
        {
            var baseUri = _navigation.BaseUri;
            string url;

            if (id.HasValue)
            {
                url = $"{baseUri}api/customers/{id}";
            }
            else
            {
                url = $"{baseUri}api/customers";
            }

            var queryParams = new List<string>();

            if (page > 0 && pageSize > 0)
            {
                queryParams.Add($"page={page}");
                queryParams.Add($"pageSize={pageSize}");
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                queryParams.Add($"searchTerm={Uri.EscapeDataString(searchTerm)}");
            }

            if (queryParams.Any())
            {
                url += "?" + string.Join("&", queryParams);
            }

            return url;
        }

        public async Task<CustomerResponse> GetCustomers(int page = 1, int pageSize = 10, string? searchTerm = null)
        {
            try
            {
                var url = GetBaseUri(null, page, pageSize, searchTerm);
                return await _http.GetFromJsonAsync<CustomerResponse>(url) ?? new CustomerResponse();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to load customers.", ex);
            }
        }

        public async Task CreateCustomer(Customer customer)
        {
            try
            {
                var url = GetBaseUri();
                var response = await _http.PostAsJsonAsync(url, customer);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Failed to save customer.", ex);
            }
        }

        public async Task UpdateCustomer(Customer customer)
        {
            try
            {
                var url = GetBaseUri(customer.Id, 0, 0);
                var response = await _http.PutAsJsonAsync(url, customer);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Failed to update customer.", ex);
            }
        }

        public async Task DeleteCustomer(Guid id)
        {
            try
            {
                var url = GetBaseUri(id, 0, 0);
                var response = await _http.DeleteAsync(url);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Failed to delete customer.", ex);
            }
        }
    }

    public class Customer
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Company name is required")]
        [StringLength(100)]
        public string? CompanyName { get; set; }

        [Required(ErrorMessage = "Contact name is required")]
        [StringLength(100)]
        public string? ContactName { get; set; }

        [StringLength(50)]
        public string? Address { get; set; }

        [StringLength(50)]
        public string? City { get; set; }

        [StringLength(50)]
        public string? Region { get; set; }

        [StringLength(50)]
        public string? PostalCode { get; set; }
        
        [StringLength(50)]
        public string? Country { get; set; }

        [Phone]
        [StringLength(20)]
        public string? Phone { get; set; }
    }
}
