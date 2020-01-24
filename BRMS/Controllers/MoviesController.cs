using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BRMS.Models;
using BRMS.ViewModels;

using System.Data.Entity;


namespace BRMS.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();

        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Index()
        {

           // var movies = _context.Movies.Include(m=>m.Genre).ToList();
           if(User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");

        }


        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m=>m.Genre).SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [HttpPost]
        [Authorize( Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            
            var Genres = _context.Genres.ToList();
            var ViewModel = new MovieFormViewModel
            {
                Genres = Genres
            };
            return View(ViewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult SaveMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var Genres = _context.Genres.ToList();
                var ViewModel = new MovieFormViewModel(movie)
                {
                    
                    Genres = Genres
                };
                return View("New", ViewModel);

            }

            if (movie.Id == 0)
            {
                 movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
                
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;

                
            }

            _context.SaveChanges();
            
            

            return RedirectToAction("Index", "Movies");

        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            var ViewModel = new MovieFormViewModel(movie)
            {
               
                Genres = _context.Genres.ToList()
            };
            return View("New", ViewModel);

        }
    }

}