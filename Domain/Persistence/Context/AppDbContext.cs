
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
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Locatable> locatables { get; set; }
        public DbSet<LocatableType> LocatableTypes { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewable> Reviewables { get; set; }
        public DbSet<ReviewImage>ReviewImages { get; set; }
        public DbSet<Tip> tips { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
    }
}
