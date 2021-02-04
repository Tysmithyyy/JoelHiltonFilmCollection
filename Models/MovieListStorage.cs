using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoelHiltonFilmCollection.Models
{
    public static class MovieListStorage
    {
        private static List<NewMovieResponse> movies = new List<NewMovieResponse>();

        public static IEnumerable<NewMovieResponse> Movies => movies;

        public static void AddMovie(NewMovieResponse movie)
        {
            movies.Add(movie);
        }
    }
}
