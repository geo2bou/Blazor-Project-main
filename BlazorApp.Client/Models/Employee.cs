using BlazorApp.Client.Abstractions.Models;

namespace BlazorApp.Client.Models
{
    public class Employee : IPerson
    {
        public string Name { get; set; } = string.Empty;
    }
}
