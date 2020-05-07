using System;
using System.Collections.Generic;
using System.IO;
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
        public DbSet<UserAchievements> user_achievements { get; set; }
        public DbSet<Wallet> wallets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Tabla Achievements
            builder.Entity<Achievement>().ToTable("achievements");
            builder.Entity<Achievement>().HasKey(p => p.Id);
            builder.Entity<Achievement>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Achievement>().Property(p => p.Name).IsRequired().HasMaxLength(45);
            builder.Entity<Achievement>().Property(p => p.Text).IsRequired().HasMaxLength(100);
            builder.Entity<Achievement>().Property(p => p.Points).HasDefaultValue<int>(null);

            //Tabla City

            builder.Entity<City>().ToTable("cities");
            builder.Entity<City>().HasKey(p => p.Id);
            builder.Entity<City>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<City>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<City>().Property(p => p.CountryId).IsRequired();
            builder.Entity<Country>().Property(p => p.LocatableId).IsRequired();
            builder.Entity<City>()
                .HasMany(p => p.Places)
                .WithOne(p => p.City)
                .HasForeignKey(p => p.CityId);



            //Tabla Country

            builder.Entity<Country>().ToTable("countries");
            builder.Entity<Country>().HasKey(p => p.Id);
            builder.Entity<Country>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Country>().Property(p => p.ShortName).IsRequired().HasMaxLength(3);
            builder.Entity<Country>().Property(p => p.FullName).IsRequired().HasMaxLength(100);
            builder.Entity<Country>().Property(p => p.LocatableId).IsRequired();
            builder.Entity<Country>()
                .HasMany(p => p.Cities)
                .WithOne(p => p.Country)
                .HasForeignKey(p => p.CountryId);


            //Tabla CountryCurrencies

            //Tabla CountryLanguages

            //Tabla Currency

            builder.Entity<Currency>().ToTable("currencies");
            builder.Entity<Currency>().HasKey(p => p.Id);
            builder.Entity<Currency>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Currency>().Property(p => p.ShortName).IsRequired().HasMaxLength(3);
            builder.Entity<Currency>().Property(p => p.Unit).IsRequired().HasMaxLength(45);

            //Tabla Favourite

            builder.Entity<Favourite>().ToTable("favourites");
            builder.Entity<Favourite>().HasKey(p => p.Id);
            builder.Entity<Favourite>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Favourite>().Property(p => p.Description).HasMaxLength(45);
            builder.Entity<Favourite>().Property(p => p.UserId).IsRequired();//Esta y la linea de abajo van?
            builder.Entity<Favourite>().Property(p => p.LocatableId).IsRequired();
            builder.Entity<Favourite>()
                .HasOne(p => p.User)
                .WithMany(p => p.Favourites)
                .HasForeignKey(p => p.UserId);
           

            //Tabla Language

            builder.Entity<Language>().ToTable("languages");
            builder.Entity<Language>().HasKey(p => p.Id);
            builder.Entity<Language>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Language>().Property(p => p.ShortName).IsRequired().HasMaxLength(45);
            builder.Entity<Language>().Property(p => p.FullName).IsRequired().HasMaxLength(45);
            //No estoy seguro si faltan otras foreigns acá, consideraria necesario por la lista, creo

            //Tabla Locatable

            builder.Entity<Locatable>().ToTable("locatables");
            builder.Entity<Locatable>().HasKey(p => p.Id);
            builder.Entity<Locatable>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Locatable>().Property(p => p.Address).IsRequired().HasMaxLength(45);
            builder.Entity<Locatable>().Property(p => p.Latitude);
            builder.Entity<Locatable>().Property(p => p.Longitude);
            builder.Entity<Locatable>().Property(p => p.ReviewableId);
            builder.Entity<Locatable>()
                .HasOne(p => p.Favourite)
                .WithOne(p => p.Locatable)
                .HasForeignKey<Favourite>(p => p.LocatableId);
            // Representar el foreign en reviewable
            //Alonso            
            //builder.Entity<Locatable>().Property(p => p.LocatableType); Creo que esto debe quitarse

            //Tabla LocatableType

            //Tabla Place

            //Tabla Profile
            //-------------------------------------------------------------------------

            //Tabla Profile
            builder.Entity<Profile>().ToTable("profiles");
            builder.Entity<Profile>().HasKey(p => p.Id);
            builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Profile>().Property(p => p.Name).IsRequired().HasMaxLength(45);
            builder.Entity<Profile>().Property(p => p.Surname).IsRequired().HasMaxLength(45);
            builder.Entity<Profile>().Property(p => p.Birthdate).IsRequired();
            builder.Entity<Profile>().Property(p => p.CountryId).IsRequired();
            builder.Entity<Profile>().Property(p => p.UserId).IsRequired();

            //Tabla Review
            builder.Entity<Review>().ToTable("reviews");
            builder.Entity<Review>().HasKey(p => p.Id);
            builder.Entity<Review>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Review>().Property(p => p.ReviewableId).IsRequired().HasDefaultValue<int>(null);
            builder.Entity<Review>().Property(p => p.UserId).IsRequired().HasMaxLength(45);
            builder.Entity<Review>().Property(p => p.Birthdate).IsRequired();
            builder.Entity<Review>().Property(p => p.CountryId).IsRequired();
            builder.Entity<Review>().Property(p => p.UserId).IsRequired();

            //Tabla Reviewable


            builder.Entity<Reviewable>
            //Tabla ReviewImage


            //-------------------------------------------------------------------------
            //Tabla Tip

            builder.Entity<Tip>().ToTable("tips");
            builder.Entity<Tip>().HasKey(p => p.Id);
            builder.Entity<Tip>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Tip>().Property(p => p.Text).IsRequired().HasMaxLength(100);
            builder.Entity<Tip>().Property(p => p.Locatable).IsRequired();
          //  builder.Entity<Tips>()
          //.HasOne(p => p.User)
          //.WithMany(p => p.Favourites)
          //.HasForeignKey(p => p.UserId);





            //Tabla User


            builder.Entity<User>()
                .HasOne(p => p.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<Profile>(p => p.UserId);
            builder.Entity<User>()
                .HasOne(p => p.Review)
                .WithOne(p => p.User)
                .HasForeignKey<Review>(p => p.UserId);

            //Tabla UserAchievements
            builder.Entity<UserAchievements>().ToTable("user_achievements");
            builder.Entity<UserAchievements>().HasKey(p => p.Id);
            builder.Entity<UserAchievements>().HasKey(p => p);


            //Tabla Wallet

            builder.Entity<Wallet>().ToTable("wallets");
            builder.Entity<Wallet>().HasKey(p => p.Id);
            builder.Entity<Wallet>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Wallet>().Property(p => p.Points).IsRequired();

        }
    }
    
}
