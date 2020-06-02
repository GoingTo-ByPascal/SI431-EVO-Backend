
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GoingTo_API.Domain.Models;
using GoingTo_API.Extensions;
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
        public DbSet<UserAchievement> UserAchievements { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySQL("server=34.67.198.111;database=goingto_db;port=3306;user=GoingTo;password=admin");
        //}


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Achievements Entity

            builder.Entity<Achievement>().ToTable("Achievements");
            builder.Entity<Achievement>().HasKey(p => p.Id);
            builder.Entity<Achievement>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Achievement>().Property(p => p.Name).IsRequired().HasMaxLength(45);
            builder.Entity<Achievement>().Property(p => p.Text).IsRequired().HasMaxLength(100);
            builder.Entity<Achievement>().Property(p => p.Points).HasDefaultValue<int>(null);

            //City Entity

            builder.Entity<City>().ToTable("Cities");
            builder.Entity<City>().HasKey(p => p.Id);
            builder.Entity<City>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<City>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<City>().Property(p => p.CountryId).IsRequired();
            builder.Entity<City>().Property(p => p.LocatableId).IsRequired();
            builder.Entity<City>()
                .HasMany(p => p.Places)
                .WithOne(p => p.City)
                .HasForeignKey(p => p.CityId);

            //Country Entity

            builder.Entity<Country>().ToTable("Countries");
            builder.Entity<Country>().HasKey(p => p.Id);
            builder.Entity<Country>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Country>().Property(p => p.ShortName).IsRequired().HasMaxLength(3);
            builder.Entity<Country>().Property(p => p.FullName).IsRequired().HasMaxLength(100);
            builder.Entity<Country>().Property(p => p.LocatableId).IsRequired();
            builder.Entity<Country>()
                .HasMany(p => p.Cities)
                .WithOne(p => p.Country)
                .HasForeignKey(p => p.CountryId);
            builder.Entity<Country>()
                .HasMany(p => p.Profiles)
                .WithOne(p => p.Country)
                .HasForeignKey(p => p.CountryId);

            //CountryCurrencies Entity

            builder.Entity<CountryCurrencies>().ToTable("CountryCurrencies");
            builder.Entity<CountryCurrencies>().HasKey(p => p.Id);
            builder.Entity<CountryCurrencies>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<CountryCurrencies>()
                .HasOne(p => p.Currency)
                .WithMany(p => p.CountryCurrencies)
                .HasForeignKey(p => p.CurrencyId);
            builder.Entity<CountryCurrencies>()
               .HasOne(p => p.Country)
               .WithMany(p => p.CountryCurrencies)
               .HasForeignKey(p => p.CountryId);

            //CountryLanguages Entity

            builder.Entity<CountryLanguages>().ToTable("CountryLanguages");
            builder.Entity<CountryLanguages>().HasKey(p => p.Id);
            builder.Entity<CountryLanguages>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<CountryLanguages>()
                .HasOne(p => p.Language)
                .WithMany(p => p.CountryLanguages)
                .HasForeignKey(p => p.LanguageId);
            builder.Entity<CountryLanguages>()
               .HasOne(p => p.Country)
               .WithMany(p => p.CountryLanguages)
               .HasForeignKey(p => p.CountryId);


            //Currency Entity

            builder.Entity<Currency>().ToTable("Currencies");
            builder.Entity<Currency>().HasKey(p => p.Id);
            builder.Entity<Currency>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Currency>().Property(p => p.ShortName).IsRequired().HasMaxLength(3);
            builder.Entity<Currency>().Property(p => p.Unit).IsRequired().HasMaxLength(45);

            //Favourite Entity

            builder.Entity<Favourite>().ToTable("Favourites");
            builder.Entity<Favourite>().HasKey(p => p.Id);
            builder.Entity<Favourite>().HasKey(pt => new { pt.UserId, pt.LocatableId });
            builder.Entity<Favourite>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Favourite>().Property(p => p.Description).HasMaxLength(45);
            builder.Entity<Favourite>().Property(p => p.UserId).IsRequired();
            builder.Entity<Favourite>().Property(p => p.LocatableId).IsRequired();

            builder.Entity<Favourite>()
                .HasOne(p => p.User)
                .WithMany(p => p.Favourites)
                .HasForeignKey(p => p.UserId);
            builder.Entity<Favourite>()
                .HasOne(p => p.Locatable)
                .WithMany(p => p.Favourites)
                .HasForeignKey(p => p.LocatableId);



            //Entity Language

            builder.Entity<Language>().ToTable("Languages");
            builder.Entity<Language>().HasKey(p => p.Id);
            builder.Entity<Language>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Language>().Property(p => p.ShortName).IsRequired().HasMaxLength(45);
            builder.Entity<Language>().Property(p => p.FullName).IsRequired().HasMaxLength(45);

            //Locatable Entity

            builder.Entity<Locatable>().ToTable("Locatables");
            builder.Entity<Locatable>().HasKey(p => p.Id);
            builder.Entity<Locatable>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Locatable>().Property(p => p.Address).IsRequired().HasMaxLength(45);
            builder.Entity<Locatable>().Property(p => p.Description).HasMaxLength(100);
            builder.Entity<Locatable>().Property(p => p.Latitude);
            builder.Entity<Locatable>().Property(p => p.Longitude);
            builder.Entity<Locatable>().Property(p => p.ReviewableId).HasDefaultValue<int>(null);

            builder.Entity<Locatable>()
                .HasOne(p => p.City)
                .WithOne(p => p.Locatable)
                .HasForeignKey<City>(p => p.LocatableId);

            builder.Entity<Locatable>()
                .HasOne(p => p.Country)
                .WithOne(p => p.Locatable)
                .HasForeignKey<Country>(p => p.LocatableId);

            builder.Entity<Locatable>()
                .HasOne(p => p.Place)
                .WithOne(p => p.Locatable)
                .HasForeignKey<Place>(p => p.LocatableId);

            builder.Entity<Locatable>()
                .HasMany(p => p.Tips)
                .WithOne(p => p.Locatable)
                .HasForeignKey(p => p.LocatableId);

            //Place Entity

            builder.Entity<Place>().ToTable("Places");
            builder.Entity<Place>().HasKey(p => p.Id);
            builder.Entity<Place>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Place>().Property(p => p.CityId).IsRequired();
            builder.Entity<Place>().Property(p => p.Name).IsRequired().HasMaxLength(45);
            builder.Entity<Place>().Property(p => p.Stars);
            builder.Entity<Place>().Property(p => p.LocatableId).IsRequired();


            //Profile Entity

            builder.Entity<Profile>().ToTable("Profiles");
            builder.Entity<Profile>().HasKey(p => p.Id);
            builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd().HasMaxLength(11);
            builder.Entity<Profile>().Property(p => p.UserId).IsRequired();
            builder.Entity<Profile>().Property(p => p.Name).IsRequired().HasMaxLength(45);
            builder.Entity<Profile>().Property(p => p.Surname).IsRequired().HasMaxLength(45);
            builder.Entity<Profile>().Property(p => p.BirthDate);
            builder.Entity<Profile>().Property(p => p.Gender).HasMaxLength(6);
            builder.Entity<Profile>().Property(p => p.CreatedAt);
            builder.Entity<Profile>().Property(p => p.CountryId).IsRequired();

            //Review Entity

            builder.Entity<Review>().ToTable("Reviews");
            builder.Entity<Review>().HasKey(p => p.Id);
            builder.Entity<Review>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Review>().Property(p => p.ReviewableId).IsRequired().HasDefaultValue<int>(null);
            builder.Entity<Review>().Property(p => p.UserId).IsRequired();
            builder.Entity<Review>().Property(p => p.Comment).IsRequired();
            builder.Entity<Review>().Property(p => p.Stars).IsRequired();
            builder.Entity<Review>().Property(p => p.ReviewedAt).IsRequired();
            builder.Entity<Review>()
                .HasMany(p => p.ReviewImages)
                .WithOne(p => p.Review)
                .HasForeignKey(p => p.ReviewId);

            //Reviewable Entity

            builder.Entity<Reviewable>().ToTable("Reviewables");
            builder.Entity<Reviewable>().HasKey(p => p.Id);
            builder.Entity<Reviewable>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Reviewable>().Property(p => p.Description).HasMaxLength(500);
            builder.Entity<Reviewable>()
                .HasOne(p => p.Review)
                .WithOne(p => p.Reviewable)
                .HasForeignKey<Review>(p => p.ReviewableId);

            builder.Entity<Reviewable>()
                .HasOne(p => p.Locatable)
                .WithOne(p => p.Reviewable)
                .HasForeignKey<Locatable>(p => p.ReviewableId);

            //ReviewImage Entity
            builder.Entity<ReviewImage>().ToTable("ReviewImages");
            builder.Entity<ReviewImage>().HasKey(p => p.Id);
            builder.Entity<ReviewImage>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ReviewImage>().Property(p => p.Filename).HasMaxLength(45).IsRequired();

            //Tip Entity

            builder.Entity<Tip>().ToTable("Tips");
            builder.Entity<Tip>().HasKey(p => p.Id);
            builder.Entity<Tip>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Tip>().Property(p => p.Text).IsRequired().HasMaxLength(100);
            builder.Entity<Tip>().Property(p => p.LocatableId).IsRequired();
            
            //User Entity
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(45);
            builder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(45);
            builder.Entity<User>().Property(p => p.WalletId);
            builder.Entity<User>()
                .HasOne(p => p.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<Profile>(p => p.UserId);

            builder.Entity<User>()
                .HasMany(p => p.Reviews)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);
            builder.Entity<User>()
                .HasMany(p => p.Favourites)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            //UserAchievements Entity 

            builder.Entity<UserAchievement>().ToTable("UserAchievements");
            builder.Entity<UserAchievement>().HasKey(p => p.Id);
            builder.Entity<UserAchievement>().HasKey(p => new { p.UserId, p.AchievementId});
            builder.Entity<UserAchievement>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<UserAchievement>().Property(p => p.UserId).IsRequired();
            builder.Entity<UserAchievement>().Property(p => p.AchievementId).IsRequired();
            builder.Entity<UserAchievement>()
                .HasOne(p => p.User)
                .WithMany(p => p.UserAchievements)
                .HasForeignKey(p => p.UserId);
            builder.Entity<UserAchievement>()
                .HasOne(p => p.Achievement)
                .WithMany(p => p.UserAchievements)
                .HasForeignKey(p => p.AchievementId);

            //Wallet Entity

            builder.Entity<Wallet>().ToTable("Wallets");
            builder.Entity<Wallet>().HasKey(p => p.Id);
            builder.Entity<Wallet>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Wallet>().Property(p => p.Points);
            builder.Entity<Wallet>()
                .HasOne(p => p.User)
                .WithOne(p => p.Wallet)
                .HasForeignKey<User>(p => p.WalletId);


            ApplySnakeCaseNamingConvention(builder);
        }
        private void ApplySnakeCaseNamingConvention(ModelBuilder builder)
        {
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName().ToSnakeCase());
                foreach (var property in entity.GetProperties())
                    property.SetColumnName(property.GetColumnName().ToSnakeCase());
                foreach (var key in entity.GetKeys())
                    key.SetName(key.GetName().ToSnakeCase());
                foreach (var foreignKey in entity.GetForeignKeys())
                    foreignKey.SetConstraintName(foreignKey.GetConstraintName().ToSnakeCase());
                foreach (var index in entity.GetIndexes())
                    index.SetName(index.GetName().ToSnakeCase());
            }
        }
    }
    
}
