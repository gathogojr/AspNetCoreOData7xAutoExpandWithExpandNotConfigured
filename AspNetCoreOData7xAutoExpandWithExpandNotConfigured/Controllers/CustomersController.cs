using System.Collections.Generic;
using System.Linq;
using AspNetCoreOData7xAutoExpandWithExpandNotConfigured.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreOData7xAutoExpandWithExpandNotConfigured.Controllers
{
    public class CustomersController : ODataController
    {
        private static readonly List<Customer> customers = GetCustomers();

        private static List<Customer> GetCustomers()
        {
            var customer1 = new Customer { Id = 1, Name = "Sue" };
            var customer2 = new Customer { Id = 2, Name = "Joe" };
            var order1 = new Order { Id = 1, Amount = 130, Customer = customer1 };
            var order2 = new Order { Id = 2, Amount = 70, Customer = customer1 };
            var order3 = new Order { Id = 3, Amount = 110, Customer = customer2 };
            var order4 = new Order { Id = 4, Amount = 170, Customer = customer2 };

            customer1.Orders = new List<Order> { order1, order2 };
            customer2.Orders = new List<Order> { order3, order4 };

            return new List<Customer>
            {
                customer1,
                customer2
            };
        }

        [EnableQuery]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return customers;
        }

        [EnableQuery]
        public ActionResult<Customer> Get(int key)
        {
            var customer = customers.SingleOrDefault(d => d.Id == key);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }
    }
}
