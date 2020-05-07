using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryCurrencies> CountryCurrencies { get; set; }
        public DbSet<CountryLanguages> CountryLanguages { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Locatable> Locatables { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewable> Reviewables { get; set; }
        public DbSet<ReviewImage>ReviewImages { get; set; }
        public DbSet<Tip> Tips { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAchievements> UserAchievements { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=34.67.198.111;database=goingto_db;port=3306;user=GoingTo;password=admin");
        }

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
            builder.Entity<City>().Property(p => p.country_id).IsRequired();
            builder.Entity<City>().Property(p => p.locatable_id).IsRequired();
            builder.Entity<City>()
                .HasMany(p => p.Places)
                .WithOne(p => p.City)
                .HasForeignKey(p => p.city_id);

            //Tabla Country

            builder.Entity<Country>().ToTable("countries");
            builder.Entity<Country>().HasKey(p => p.Id);
            builder.Entity<Country>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Country>().Property(p => p.ShortName).IsRequired().HasMaxLength(3);
            builder.Entity<Country>().Property(p => p.FullName).IsRequired().HasMaxLength(100);
            builder.Entity<Country>().Property(p => p.locatable_id).IsRequired();
            builder.Entity<Country>()
                .HasMany(p => p.Cities)
                .WithOne(p => p.Country)
                .HasForeignKey(p => p.country_id);
            builder.Entity<Country>()
                .HasMany(p => p.Profiles)
                .WithOne(p => p.Country)
                .HasForeignKey(p => p.country_id);

            //Tabla CountryCurrencies

            builder.Entity<CountryCurrencies>().ToTable("country_currencies");
            builder.Entity<CountryCurrencies>().HasKey(p => p.Id);
            builder.Entity<CountryCurrencies>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<CountryCurrencies>()
                .HasOne(p => p.Currency)
                .WithMany(p => p.CountryCurrencies)
                .HasForeignKey(p => p.currency_id);
            builder.Entity<CountryCurrencies>()
               .HasOne(p => p.Country)
               .WithMany(p => p.CountryCurrencies)
               .HasForeignKey(p => p.country_id);

            //Tabla CountryLanguages

            builder.Entity<CountryLanguages>().ToTable("country_languages");
            builder.Entity<CountryLanguages>().HasKey(p => p.Id);
            builder.Entity<CountryLanguages>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<CountryLanguages>()
                .HasOne(p => p.Language)
                .WithMany(p => p.CountryLanguages)
                .HasForeignKey(p => p.language_id);
            builder.Entity<CountryLanguages>()
               .HasOne(p => p.Country)
               .WithMany(p => p.CountryLanguages)
               .HasForeignKey(p => p.country_id);

         
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
            builder.Entity<Favourite>().Property(p => p.user_id).IsRequired();
            builder.Entity<Favourite>().Property(p => p.locatable_id).IsRequired();
            builder.Entity<Favourite>()
                .HasOne(p => p.User)
                .WithMany(p => p.Favourites)
                .HasForeignKey(p => p.user_id);

            //Tabla Language

            builder.Entity<Language>().ToTable("languages");
            builder.Entity<Language>().HasKey(p => p.Id);
            builder.Entity<Language>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Language>().Property(p => p.ShortName).IsRequired().HasMaxLength(45);
            builder.Entity<Language>().Property(p => p.FullName).IsRequired().HasMaxLength(45);

            //Tabla Locatable

            builder.Entity<Locatable>().ToTable("locatables");
            builder.Entity<Locatable>().HasKey(p => p.Id);
            builder.Entity<Locatable>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Locatable>().Property(p => p.Address).IsRequired().HasMaxLength(45);
            builder.Entity<Locatable>().Property(p => p.Latitude);
            builder.Entity<Locatable>().Property(p => p.Longitude);
            builder.Entity<Locatable>().Property(p => p.reviewable_id);

            builder.Entity<Locatable>()
                .HasOne(p => p.Favourite)
                .WithOne(p => p.Locatable)
                .HasForeignKey<Favourite>(p => p.locatable_id);

            builder.Entity<Locatable>()
                .HasOne(p => p.City)
                .WithOne(p => p.Locatable)
                .HasForeignKey<City>(p => p.locatable_id);

            builder.Entity<Locatable>()
                .HasOne(p => p.Country)
                .WithOne(p => p.Locatable)
                .HasForeignKey<Country>(p => p.locatable_id);

            builder.Entity<Locatable>()
                .HasOne(p => p.Place)
                .WithOne(p => p.Locatable)
                .HasForeignKey<Place>(p => p.locatable_id);

            builder.Entity<Locatable>()
                .HasMany(p => p.Tips)
                .WithOne(p => p.Locatable)
                .HasForeignKey(p => p.locatable_id);

            //Tabla Place

            builder.Entity<Place>().ToTable("places");
            builder.Entity<Place>().HasKey(p => p.Id);
            builder.Entity<Place>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Place>().Property(p => p.city_id).IsRequired();
            builder.Entity<Place>().Property(p => p.Name).IsRequired().HasMaxLength(45);
            builder.Entity<Place>().Property(p => p.Stars);
            builder.Entity<Place>().Property(p => p.locatable_id).IsRequired();

          
            //Tabla Profile

            builder.Entity<Profile>().ToTable("profiles");
            builder.Entity<Profile>().HasKey(p => p.Id);
            builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Profile>().Property(p => p.Name).IsRequired().HasMaxLength(45);
            builder.Entity<Profile>().Property(p => p.Surname).IsRequired().HasMaxLength(45);
            builder.Entity<Profile>().Property(p => p.Birthdate).IsRequired();
            builder.Entity<Profile>().Property(p => p.country_id).IsRequired();
            builder.Entity<Profile>().Property(p => p.user_id).IsRequired();

            //Tabla Review

            builder.Entity<Review>().ToTable("reviews");
            builder.Entity<Review>().HasKey(p => p.Id);
            builder.Entity<Review>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Review>().Property(p => p.reviewable_id).IsRequired().HasDefaultValue<int>(null);
            builder.Entity<Review>().Property(p => p.user_id).IsRequired();
            builder.Entity<Review>().Property(p => p.Comment).IsRequired();
            builder.Entity<Review>().Property(p => p.Stars).IsRequired();
            builder.Entity<Review>().Property(p => p.ReviewedAt).IsRequired();
            builder.Entity<Review>()
                .HasMany(p => p.ReviewImages)
                .WithOne(p => p.Review)
                .HasForeignKey(p => p.review_id);

            //Tabla Reviewable

            builder.Entity<Reviewable>().ToTable("reviewables");
            builder.Entity<Reviewable>().HasKey(p => p.Id);
            builder.Entity<Reviewable>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Reviewable>().Property(p => p.Description).HasMaxLength(500);
            builder.Entity<Reviewable>()
                .HasOne(p => p.Review)
                .WithOne(p => p.Reviewable)
                .HasForeignKey<Review>(p => p.reviewable_id);

            builder.Entity<Reviewable>()
                .HasOne(p => p.Locatable)
                .WithOne(p => p.Reviewable)
                .HasForeignKey<Locatable>(p => p.reviewable_id);

            //Tabla ReviewImage
            builder.Entity<ReviewImage>().ToTable("review_images");
            builder.Entity<ReviewImage>().HasKey(p => p.Id);
            builder.Entity<ReviewImage>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ReviewImage>().Property(p => p.Filename).HasMaxLength(45).IsRequired();

            //Tabla Tip

            builder.Entity<Tip>().ToTable("tips");
            builder.Entity<Tip>().HasKey(p => p.Id);
            builder.Entity<Tip>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Tip>().Property(p => p.Text).IsRequired().HasMaxLength(100);
            builder.Entity<Tip>().Property(p => p.locatable_id).IsRequired();
            
            //Tabla User
            builder.Entity<User>().ToTable("users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(45);
            builder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(45);
            builder.Entity<User>().Property(p => p.wallet_id).IsRequired();
            builder.Entity<User>()
                .HasOne(p => p.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<Profile>(p => p.user_id);
            builder.Entity<User>()
                .HasMany(p => p.Reviews)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.user_id);

            //Tabla UserAchievements

            builder.Entity<UserAchievements>().ToTable("user_achievements");
            builder.Entity<UserAchievements>().HasKey(p => p.Id);
            builder.Entity<UserAchievements>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<UserAchievements>().Property(p => p.user_id).IsRequired();
            builder.Entity<UserAchievements>().Property(p => p.AchievementId).IsRequired();
            builder.Entity<UserAchievements>()
                .HasOne(p => p.User)
                .WithMany(p => p.UserAchievements)
                .HasForeignKey(p => p.user_id);
            builder.Entity<UserAchievements>()
                .HasOne(p => p.Achievement)
                .WithMany(p => p.UserAchievements)
                .HasForeignKey(p => p.AchievementId);

            //Tabla Wallet

            builder.Entity<Wallet>().ToTable("wallets");
            builder.Entity<Wallet>().HasKey(p => p.Id);
            builder.Entity<Wallet>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Wallet>().Property(p => p.Points).IsRequired();
            builder.Entity<Wallet>()
                .HasOne(p => p.User)
                .WithOne(p => p.Wallet)
                .HasForeignKey<User>(p => p.wallet_id);

            
        }
    }
    
}
