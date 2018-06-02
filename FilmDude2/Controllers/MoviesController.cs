using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilmDude2.Models;
using FilmDude2.ViewModels;

namespace FilmDude2.Controllers
{
    public class MoviesController : Controller
    {
        // Setup some Films for our View

        public IEnumerable<Movies> GetMovies() => new List<Movies>
        {
            new Movies() { Name = "HorseBastards Epiphany", Id = 1 },
            new Movies() {Name = "MegaChunk vs AstroDuff", Id = 2 }
        };

        // GET: Movies
        public ActionResult Random()
        {
            //can use the full declarative or add a using statement to access Movies model : using FilmDude.Models
            var movie = new Movies() { Name = "HorseBastards Epiphany" };

            var customers = new List<Customer>
            {
                new Customer {Name = "Johnboy", Id = 1 },
                new Customer {Name = "Derpinator", Id = 2 }
            };

            //instantiate ViewModel and declare match its populate its properties.
            var randomMovieViewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customer = customers
            };
            return View(randomMovieViewModel);

        }

        public ActionResult Movies(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (string.IsNullOrEmpty(sortBy))
            {
                sortBy = "Name";
            }

            return Content(string.Format("The requested page is {0}, the sorting option is sort by {1}", pageIndex, sortBy));
        }

        //routes.MapMvcAttributeRoutes();
        //[Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2})}")]
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult Release(int year, byte month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }
    }
}