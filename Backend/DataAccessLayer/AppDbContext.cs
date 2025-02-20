
using Microsoft.EntityFrameworkCore;
using Backend.CoreLayer.Entities;
using MovieSeries.CoreLayer.Entities;

namespace Backend.DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        public DbSet<MoviesSeries> MoviesSeries { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MovieSeriesTag> MovieSeriesTags { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieSeriesTag>()
                .HasKey(mst => new { mst.MovieSeriesId, mst.TagId });

            modelBuilder.Entity<MovieSeriesTag>()
                .HasOne(mst => mst.MovieSeries)
                .WithMany(m => m.MoviesSeriesTags)
                .HasForeignKey(mst => mst.MovieSeriesId);

            modelBuilder.Entity<MovieSeriesTag>()
                .HasOne(mst => mst.Tag)
                .WithMany(t => t.MovieSeriesTags)
                .HasForeignKey(mst => mst.TagId);

            // Configure User entity
            modelBuilder.Entity<User>()
                .HasMany(u => u.Reviews)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

            // Configure Review entity
            modelBuilder.Entity<Review>()
                .HasOne(r => r.MovieSeries)
                .WithMany()
                .HasForeignKey(r => r.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.MovieSeries)
                .WithMany(ms => ms.Ratings)
                .HasForeignKey(r => r.MovieSeriesId);
        }
   }
}
