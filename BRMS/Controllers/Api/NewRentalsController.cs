using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BRMS.Dtos;
using BRMS.Models;
using System.Data.Entity;

namespace BRMS.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var _context = new ApplicationDbContext();
            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);

            if (customer == null)
                return BadRequest("customer id not valid ");

            if (newRental.MovieIds.Count == 0)
                return BadRequest("No movie ids have been given ");
       
            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();   // select * from movies where id in (1,2,3)

            if (movies.Count != newRental.MovieIds.Count)
                return BadRequest(" one or more movie ids not valid ");
            foreach (var movie in movies)
            {
                if(movie.NumberAvailable==0)
                    return BadRequest(" Movie is not available ");

                movie.NumberAvailable--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now,


                };
                _context.Rentals.Add(rental);

            }

            _context.SaveChanges();
            return Ok();
        }

    }
}
