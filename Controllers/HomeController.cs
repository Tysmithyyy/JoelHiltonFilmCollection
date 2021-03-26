using JoelHiltonFilmCollection.Models;
using JoelHiltonFilmCollection.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JoelHiltonFilmCollection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IJoelHiltonFilmCollectionRepository _repository;

        private JoelHiltonFilmCollectionDbContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, IJoelHiltonFilmCollectionRepository repository, JoelHiltonFilmCollectionDbContext con)
        {
            _logger = logger;

            _repository = repository;
            context = con;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                //update data entered is valid, if not, return the asp-validation summary
                if (movie.Title == "Independence Day")
                {

                }
                else
                {
                    context.Movies.Add(movie);
                    context.SaveChanges();
                }

            }
            return View("Confirmation", movie);
        }

        [HttpPost]
        public IActionResult EditMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                var old = context.Movies.Where(t => t.MovieId == movie.MovieId).FirstOrDefault();
                context.Movies.Remove(old);
                //update data entered is valid, if not, return the asp-validation summary
                if (movie.Title == "Independence Day")
                {

                }
                else
                {
                    context.Movies.Add(movie);
                    context.SaveChanges();
                }

            }
            return View("EditConfirmation", movie);
        }

        public IActionResult MovieList()
        {
            //return the list of all movies
            return View(new MovieListViewModel
            {
                Movies = _repository.Movies
                    .OrderBy(t => t.Title)
            });
        }

        [HttpPost]
        public IActionResult Edit(int MovieID)
        {
            var movie = context.Movies.Where(t => t.MovieId == MovieID).FirstOrDefault();

            return View("EditMovie", movie);
        }

        [HttpPost]
        public IActionResult Delete(int MovieId)
        {
            var movie = context.Movies.Where(t => t.MovieId == MovieId).FirstOrDefault();
            context.Movies.Remove(movie);
            context.SaveChanges();
            return RedirectToAction("MovieList");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
