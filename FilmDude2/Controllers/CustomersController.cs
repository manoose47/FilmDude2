using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using FilmDude2.Models;

namespace FilmDude2.Controllers
{
    public class CustomersController : Controller
    {

        // private var of type ApplicationDbContext
        private ApplicationDbContext _context;

        public CustomersController()
        {
          // instantiate ApplicationDbContext class
            _context = new ApplicationDbContext();
        }

        // I won't begin to pretend I know what this is, I think it's something to do with closing the _context when it's not being used.
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // Create an IEnumerable which will store a list of type Customer, which is populated from the DB Customer record
        private IEnumerable<Customer> GetCustomers()
        {

            // Adding the Include extension method from Data.Entities to include the MembershipType object in the List, I think this is possible because we defined membershipType as a foreign key on Customer
            return _context.Customers.Include(c => c.MembershipType).ToList();   
        }

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