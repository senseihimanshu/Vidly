using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController: Controller
    {
        private readonly List<Customer> _customers;

        public CustomersController()
        {
            _customers = new List<Customer>()
            {
                new Customer() { Id = 1, Name = "Himanshu Sharma" },
                new Customer() { Id = 2, Name = "Shivani Bansal" }
            };
        }
        
        public IActionResult Index()
        {
            return View(_customers);
        }
        
        [Route("Customers/{id}")]
        public IActionResult Show(int? id)
        {
            Customer customer = _customers.Find((customer) => customer.Id == id);

            if (!id.HasValue || customer == null)
            {
                return Content("Customer with this id doesn't exist");
            }
            
            return View(customer);
        }
    }
}