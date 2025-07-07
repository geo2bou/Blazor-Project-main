using BlazorApp.Client.Services;

namespace BlazorApp.Client.Models
{
    public class CustomerResponse
    {
        public List<Customer> Data { get; set; } = new();
        public int TotalCount { get; set; }
    }
}