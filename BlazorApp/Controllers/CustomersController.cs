using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(ApplicationDbContext context, ILogger<CustomersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string? searchTerm = null)
        {
            var query = _context.Customers.AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                _logger.LogInformation($"Test parameter received: {searchTerm}");
                // You can add additional filtering based on the test parameter if needed
                query = query.Where(c => c.CompanyName.Contains(searchTerm) || c.ContactName.Contains(searchTerm));
            }

            var totalCount = await query.CountAsync();

            var customers = await query //_context.Customers
                .OrderBy(c => c.CompanyName)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var response = new
            {
                Data = customers,
                TotalCount = totalCount
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Invalid or missing Customer ID.");
                return BadRequest("Invalid or missing Customer ID.");
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                _logger.LogError("Customer not found.");
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                _logger.LogError("Customer object is null.");
                return BadRequest("Customer object is null.");
            }

            try
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Database error: {ex.Message}");
                return StatusCode(500, $"Database error: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected error: {ex.Message}");
                return StatusCode(500, $"Unexpected error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(Guid? id, [FromBody] Customer customer)
        {
            if (!id.HasValue /*string.IsNullOrWhiteSpace(id)*/ || customer == null)
            {
                _logger.LogError("Missing ID or customer data.");
                return BadRequest("Missing ID or customer data.");
            }

            if (id != customer.Id)
            {
                _logger.LogError("ID mismatch between route and body.");
                return BadRequest("ID mismatch between route and body.");
            }

            var existing = await _context.Customers.FindAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            existing.CompanyName = customer.CompanyName;
            existing.ContactName = customer.ContactName;
            existing.Address = customer.Address;
            existing.City = customer.City;
            existing.Region = customer.Region;
            existing.PostalCode = customer.PostalCode;
            existing.Country = customer.Country;
            existing.Phone = customer.Phone;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Customers.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Invalid or missing Customer ID.");
                return BadRequest("Invalid or missing Customer ID.");
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
