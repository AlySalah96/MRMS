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
  
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // Get   Api/movies
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesquery = _context.Movies.Include(m => m.Genre).Where(m => m.NumberAvailable > 0);
            if (!string.IsNullOrWhiteSpace(query))
                moviesquery = moviesquery.Where(m => m.Name.Contains(query));

            var movieDtos = moviesquery
               .ToList().Select(Mapper.Map<Movie, MovieDto>);


            return Ok(movieDtos);
        }

        // Get   Api/movies/1
        public IHttpActionResult Getmovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return NotFound(); // return the standard http not found response
            return Ok(Mapper.Map<Movie, MovieDto>(movie));  /// may use the id of this movie that is why return movie .
        }

        //Post Api/movies 
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);

        }



        // Put Api/Movies/8
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();


        }

        // Delete Api/Movies/8
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public void DeleteMovie(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }

    }
}
