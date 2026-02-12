using Microsoft.EntityFrameworkCore;

namespace Mission06_Mantoan.Models;

public partial class JoelHiltonMovieCollectionContext : DbContext
{
    public JoelHiltonMovieCollectionContext(DbContextOptions<JoelHiltonMovieCollectionContext> options)
        : base(options) { }

    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Movie> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasOne(d => d.Category)
                .WithMany(p => p.Movies)
                .HasForeignKey(d => d.CategoryId);
        });
    }
}