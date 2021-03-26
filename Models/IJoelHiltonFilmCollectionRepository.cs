using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoelHiltonFilmCollection.Models
{
    public interface IJoelHiltonFilmCollectionRepository
    {
        IQueryable<Movie> Movies { get; }
    }
}
