using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilmDude2.Models;

namespace FilmDude2.Controllers
{
    public class CustomersController : Controller
    {
        // Create an IEnumerable which will store a list of type Customer, then instantiate the lists items
        private IEnumerable<Customer> GetCustomers() => new List<Customer>
        {
            new Customer{Name ="Ferdinand MicroTank", Id=1},
            new Customer{Name ="Jiminy Winklespit", Id =2}
        };

        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }

        public ActionResult Details(int? id)
        {
            // customer = the list of GetCustomer, where Customer.Id matches the passed id param
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}