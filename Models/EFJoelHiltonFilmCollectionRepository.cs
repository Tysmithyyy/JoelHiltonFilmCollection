using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoelHiltonFilmCollection.Models
{
    public class EFJoelHiltonFilmCollectionRepository : IJoelHiltonFilmCollectionRepository
    {
        private JoelHiltonFilmCollectionDbContext _context;

        public EFJoelHiltonFilmCollectionRepository (JoelHiltonFilmCollectionDbContext context)
        {
            _context = context;
        }

        public IQueryable<Movie> Movies => _context.Movies;

    }
}
