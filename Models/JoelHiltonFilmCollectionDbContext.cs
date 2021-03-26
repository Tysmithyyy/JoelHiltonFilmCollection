using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoelHiltonFilmCollection.Models
{
    public class JoelHiltonFilmCollectionDbContext : DbContext
    {
        public JoelHiltonFilmCollectionDbContext (DbContextOptions<JoelHiltonFilmCollectionDbContext> options) : base (options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
