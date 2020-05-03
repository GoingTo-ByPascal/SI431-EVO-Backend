using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoingTo_API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GoingTo_API.Domain.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Achievement> achievements { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<Currency> currencies { get; set; }
        public DbSet<Favourite> favourites { get; set; }
        public DbSet<Language> languages { get; set; }
        public DbSet<Locatable> locatables { get; set; }
        public DbSet<LocatableType> locatable_types { get; set; }
        public DbSet<Place> places { get; set; }
        public DbSet<Profile> profiles { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<Reviewable> reviewables { get; set; }
        public DbSet<ReviewImage>review_images { get; set; }
        public DbSet<Tip> tips { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Wallet> wallets { get; set; }

    }
}
