﻿using Backend.CoreLayer;
using Backend.CoreLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Backend.DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<MovieSeriesTag> MovieSeriesTags { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Movie> movies { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>().HasKey(t => t.tag_id);

            modelBuilder.Entity<MovieSeriesTag>()
                .HasKey(mst => new { mst.MovieSeriesId, mst.TagId });

            modelBuilder.Entity<MovieSeriesTag>()
                .HasOne(mst => mst.Movie)
                .WithMany(ms => ms.MovieSeriesTags)
                .HasForeignKey(mst => mst.MovieSeriesId);

            modelBuilder.Entity<MovieSeriesTag>()
                .HasOne(mst => mst.Tag)
                .WithMany(t => t.MovieSeriesTags)
                .HasForeignKey(mst => mst.TagId);
        }
    }
}
