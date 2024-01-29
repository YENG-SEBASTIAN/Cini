using Microsoft.EntityFrameworkCore;

namespace MovieAPI.Models
{
    public class MovieDBContext : DbContext
    {
         
        public MovieDBContext(DbContextOptions<MovieDBContext> options)
            : base(options)
        {
            
        }

        public MovieDBContext()
        {
            
        }

        public virtual DbSet <Movie> Movies { get; set; }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Movie>(entity => {
                entity.HasKey(a => a.Id)
                .IsClustered(false);

                entity.ToTable("CiniMovies");

                entity.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(200);

                entity.Property(a => a.Genre);
                entity.Property(a => a.ReleaseYear);
            });
        }
    }
}