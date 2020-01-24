using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BRMS.Models;
using System.Data.Entity;
using BRMS.ViewModels;


namespace BRMS.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();

        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {

           // var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View();

        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }


        public ActionResult New()
        {

            var MembershipTypes = _context.MembershipTypes.ToList();
            // intializing memberships and customer(Id with 0)
            var ViewModel = new CustomerFormViewModel
            {
                Customer =new Customer(),
                MembershipTypes = MembershipTypes
            };
            return View("CustomerForm",ViewModel);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var MembershipTypes = _context.MembershipTypes.ToList();
                var ViewModel = new CustomerFormViewModel
                {
                    Customer= customer,
                    MembershipTypes = MembershipTypes
                };
                return View("CustomerForm", ViewModel);

            }
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                customerInDb.Birthdate = customer.Birthdate;
            }


            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");

        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var ViewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", ViewModel);
        }
    }
}