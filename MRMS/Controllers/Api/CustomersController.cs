using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MRMS.Dtos;
using MRMS.Models;
using System.Data.Entity;

namespace MRMS.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // Get   Api/Customers
        public IHttpActionResult GetCustomers(string query=null)
        {
            // divide the function into two parts ,one for list customer to admin another to typeahead
            var customersquery = _context.Customers.Include(c => c.MembershipType);
            if (!string.IsNullOrWhiteSpace(query))
                customersquery = customersquery.Where(c=>c.Name.Contains(query));


            var customerDtos = customersquery
                .ToList().Select(Mapper.Map<Customer, CustomerDto>);



            return Ok(customerDtos);
        }

        // Get   Api/Customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer= _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                 return NotFound(); // return the standard http not found response
            return Ok(Mapper.Map<Customer,CustomerDto>(customer));  /// may use the id of this customer that is why return customer .
        }

        //Post Api/Customers 
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                  return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri+"/" + customer.Id), customerDto);

        }


        // Put Api/Customers
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDb);
            _context.SaveChanges();


        }

        // Delete Api/Customers
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }






        }
    }
