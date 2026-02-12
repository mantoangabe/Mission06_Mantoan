using Microsoft.EntityFrameworkCore;

namespace Mission06_Mantoan.Models;

public class MovieContext: DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options): base(options)
    {
        
    }
    public DbSet<Movie1> Movies { get; set; }
}