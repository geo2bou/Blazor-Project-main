using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Models
{
    [Index(propertyName: nameof(CompanyName), IsUnique = false)]
    [Index(propertyName: nameof(ContactName), IsUnique = false)]
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
