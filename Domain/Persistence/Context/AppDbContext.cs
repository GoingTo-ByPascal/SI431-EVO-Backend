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
        public DbSet<Achievement> achievements { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<CountryCurrencies> country_currencies { get; set; }
        public DbSet<CountryLanguages> country_languages { get; set; }
        public DbSet<Currency> currencies { get; set; }
        public DbSet<Favourite> favourites { get; set; }
        public DbSet<Language> languages { get; set; }
        public DbSet<Locatable> locatables { get; set; }
        public DbSet<Place> places { get; set; }
        public DbSet<Profile> profiles { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<Reviewable> reviewables { get; set; }
        public DbSet<ReviewImage>review_images { get; set; }
        public DbSet<Tip> tips { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<UserAchievements> user_achievements { get; set; }
        public DbSet<Wallet> wallets { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySQL("server=34.67.198.111;database=test;port=3306;user=GoingTo;password=admin");
        //}

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

            builder.Entity<Achievement>().HasData
                (
                    new Achievement { Id = 1, Name = "Reviewed!" , Text = "Review your first place.",Points = 10 },
                    new Achievement { Id = 2, Name = "Dream come true", Text = "Complete all the goals of a routine", Points = 100 },
                    new Achievement { Id = 3, Name = "Welcome, premium" , Text = "You've become a premium user.",Points =0 }
                );


            //Tabla City

            builder.Entity<City>().ToTable("cities");
            builder.Entity<City>().HasKey(p => p.Id);
            builder.Entity<City>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<City>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<City>().Property(p => p.CountryId).IsRequired();
            builder.Entity<City>().Property(p => p.LocatableId).IsRequired();
            builder.Entity<City>()
                .HasMany(p => p.Places)
                .WithOne(p => p.City)
                .HasForeignKey(p => p.CityId);

            builder.Entity<City>().HasData
                (
                    new City { Id = 1, Name = "Cusco", CountryId =  1, LocatableId = 10},
                    new City { Id = 2, Name = "Paris", CountryId = 2, LocatableId = 20 },
                    new City { Id = 3, Name = "Transilvania", CountryId = 3, LocatableId = 30 }
                );


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
            builder.Entity<Country>()
                .HasMany(p => p.Profiles)
                .WithOne(p => p.Country)
                .HasForeignKey(p => p.CountryId);

            builder.Entity<Country>().HasData
                (
                    new Country { Id = 1, ShortName = "PER", FullName = "Peru" , LocatableId = 1 },
                    new Country { Id = 2, ShortName = "FRA", FullName = "France", LocatableId = 7 },
                    new Country { Id = 3, ShortName = "ROU", FullName = "Romania", LocatableId = 3 }
                );

            //Tabla CountryCurrencies

            builder.Entity<CountryCurrencies>().ToTable("country_currencies");
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

            builder.Entity<CountryCurrencies>().HasData
                (
                    new CountryCurrencies { Id = 1, CurrencyId = 1, CountryId = 1 },
                    new CountryCurrencies { Id = 2, CurrencyId = 2, CountryId = 2 },
                    new CountryCurrencies { Id = 3, CurrencyId = 2, CountryId = 2 }
                );

            //Tabla CountryLanguages

            builder.Entity<CountryLanguages>().ToTable("country_languages");
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

            builder.Entity<CountryLanguages>().HasData
                (
                    new CountryLanguages { Id = 1, LanguageId = 1, CountryId = 1 },
                    new CountryLanguages { Id = 2, LanguageId = 2, CountryId = 2 },
                    new CountryLanguages { Id = 3, LanguageId = 2, CountryId = 2 }
                );

            //Tabla Currency

            builder.Entity<Currency>().ToTable("currencies");
            builder.Entity<Currency>().HasKey(p => p.Id);
            builder.Entity<Currency>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Currency>().Property(p => p.ShortName).IsRequired().HasMaxLength(3);
            builder.Entity<Currency>().Property(p => p.Unit).IsRequired().HasMaxLength(45);

            builder.Entity<Currency>().HasData
                (
                    new Currency { Id = 1, ShortName = "PEN", Unit = "Sol" },
                    new Currency { Id = 2, ShortName = "EUR", Unit = "Euro" },
                    new Currency { Id = 3, ShortName = "RON", Unit = "Leu"}
                );


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

           builder.Entity<Favourite>().HasData
                (
                    new Favourite { Id = 1, UserId=1, LocatableId=1, Description = "Interesante"},
                    new Favourite { Id = 2, UserId=2, LocatableId=7, Description = "Posible viaje en familia"},
                    new Favourite { Id = 3, UserId=3, LocatableId=11, Description = "Para ir con mi baby"}
                );

            //Tabla Language

            builder.Entity<Language>().ToTable("languages");
            builder.Entity<Language>().HasKey(p => p.Id);
            builder.Entity<Language>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Language>().Property(p => p.ShortName).IsRequired().HasMaxLength(45);
            builder.Entity<Language>().Property(p => p.FullName).IsRequired().HasMaxLength(45);

            builder.Entity<Language>().HasData
                (
                    new Language { Id = 1, ShortName = "ES" , FullName = "Spanish"},
                    new Language { Id = 2, ShortName = "FR" , FullName = "French"},
                    new Language { Id = 3, ShortName = "RO" , FullName = "Romanian"}
                );

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
            builder.Entity<Locatable>()
                .HasOne(p => p.City)
                .WithOne(p => p.Locatable)
                .HasForeignKey<Favourite>(p => p.LocatableId);
            builder.Entity<Locatable>()
                .HasOne(p => p.Country)
                .WithOne(p => p.Locatable)
                .HasForeignKey<Favourite>(p => p.LocatableId);
            builder.Entity<Locatable>()
                .HasOne(p => p.Place)
                .WithOne(p => p.Locatable)
                .HasForeignKey<Favourite>(p => p.LocatableId);

             builder.Entity<Locatable>().HasData
                (
                    new Locatable { Id = 4, Address = "BCP plaza Cusco" , Latitude = -13.5226 ,Longitude = -71.9673 ,ReviewableId = 2},
                    new Locatable { Id = 5, Address = "The Champ de Mars" , Latitude = 48.8534 ,Longitude = 2.3486 ,ReviewableId = 1},
                    new Locatable { Id = 6, Address = "Cusco" , Latitude = -13.5226 ,Longitude = -71.9673 ,ReviewableId = 3}


                );

            //Tabla Place
            builder.Entity<Place>().ToTable("places");
            builder.Entity<Place>().HasKey(p => p.Id);
            builder.Entity<Place>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Place>().Property(p => p.CityId).IsRequired();
            builder.Entity<Place>().Property(p => p.Name).IsRequired().HasMaxLength(45);
            builder.Entity<Place>().Property(p => p.Stars);
            builder.Entity<Place>().Property(p => p.LocatableId).IsRequired();

             builder.Entity<Place>().HasData
                (
                    new Place { Id = 1, CityId = 1, Name = "Machu Picchu"  ,Stars = 5 ,LocatableId = 4},
                    new Place { Id = 2, CityId = 1, Name = "Rainbow Mountain"  ,Stars = 4 ,LocatableId = 5},
                    new Place { Id = 3, CityId = 1, Name = "Sacsayhuaman"  ,Stars = 4 ,LocatableId = 6}
                );


            //Tabla Profile
            builder.Entity<Profile>().ToTable("profiles");
            builder.Entity<Profile>().HasKey(p => p.Id);
            builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Profile>().Property(p => p.Name).IsRequired().HasMaxLength(45);
            builder.Entity<Profile>().Property(p => p.Surname).IsRequired().HasMaxLength(45);
            builder.Entity<Profile>().Property(p => p.Birthdate).IsRequired();
            builder.Entity<Profile>().Property(p => p.CountryId).IsRequired();
            builder.Entity<Profile>().Property(p => p.UserId).IsRequired();

             builder.Entity<Profile>().HasData
                (
                    new Profile { Id = 1, Name = "Alonso", Surname = "Garrido" ,Birthdate = 1993-05-12 ,CountryId = 1, UserId = 1},
                    new Profile { Id = 2, Name = "Marcio", Surname = "Begazo" ,Birthdate = 1998-04-19 ,CountryId = 1, UserId = 2},
                    new Profile { Id = 3, Name = "Luis" , Surname = "Ordoñez" ,Birthdate = 2000-07-11 ,CountryId = 1, UserId = 3}
                );


            //Tabla Review
            builder.Entity<Review>().ToTable("reviews");
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
                .HasForeignKey(p => p.RewiewId);

             builder.Entity<Review>().HasData
                (
                   new Review { Id=1,ReviewableId=1,UserId=1,Comment="escogi una casa muy cerca al parque y es un agradablel lugar con vistas muy hermosas",Stars=4,ReviewedAt=2020-03-01},
                   new Review { Id=2,ReviewableId=2,UserId=2,Comment="estamos en feriado y afortunadamente no habia mucha cola, aunque no hay aire acondicinado ",Stars=4,ReviewedAt=2020-04-15},
                   new Review { Id=3,ReviewableId=3,UserId=3,Comment="siempre que viajo con latam el vuelo se hace muy comodo aunque cueste un poco mas que otras aerolineas, llegue en solo 2hrs a Cusco",Stars=5,ReviewedAt=2020-04-26}
                );

            //Tabla Reviewable
            builder.Entity<Reviewable>().ToTable("reviewables");
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
                .HasForeignKey<Review>(p => p.ReviewableId);

                builder.Entity<Reviewable>().HasData
               (
                   new Reviewable { Id = 1, Description = "bonita casa" },
                   new Reviewable { Id = 2, Description = "cajeros libres" },
                   new Reviewable { Id = 3, Description = "viaje super rapido" }
               );

            //Tabla ReviewImage
            builder.Entity<ReviewImage>().ToTable("review_images");
            builder.Entity<ReviewImage>().HasKey(p => p.Id);
            builder.Entity<ReviewImage>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ReviewImage>().Property(p => p.Filename).HasMaxLength(45).IsRequired();

            builder.Entity<ReviewImage>().HasData
              (
                  new ReviewImage { Id = 1, Filename = "vista de la plaza.jpg" },
                  new ReviewImage { Id = 2, Filename = "nadie.jpg" },
                  new ReviewImage { Id = 3, Filename = "hola Santiago.jpg" }
              );
            //Tabla Tip

            builder.Entity<Tip>().ToTable("tips");
            builder.Entity<Tip>().HasKey(p => p.Id);
            builder.Entity<Tip>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Tip>().Property(p => p.Text).IsRequired().HasMaxLength(100);
            builder.Entity<Tip>().Property(p => p.Locatable).IsRequired();
            builder.Entity<Tip>()
             .HasOne(p => p.Locatable)
             .WithMany(p => p.Tips)
             .HasForeignKey(p => p.LocatableId);

            builder.Entity<Tip>().HasData
              (
                  new Tip { Id = 1, Text = "Pedir taxi por aplicacion desde el aeropuerto",LocatableId = 1 },
                  new Tip { Id = 2, Text = "Llevar ropa impermeable siempre en la mochila" ,LocatableId= 7}
              );



            //Tabla User
            builder.Entity<User>().ToTable("users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(45);
            builder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(45);
            builder.Entity<User>().Property(p => p.WalletId).IsRequired();
            builder.Entity<User>()
                .HasOne(p => p.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<Profile>(p => p.UserId);
            builder.Entity<User>()
                .HasOne(p => p.Review)
                .WithOne(p => p.User)
                .HasForeignKey<Review>(p => p.UserId);

            builder.Entity<User>().HasData
             (
                 new User { Id = 1, WalletId = 1,Email= "alonso@upc.pe",Password = "Alonso" },
                 new User { Id = 2, WalletId = 2, Email = "marcio@upc.pe", Password = "Marcio" }
             );

            //Tabla UserAchievements
            builder.Entity<UserAchievements>().ToTable("user_achievements");
            builder.Entity<UserAchievements>().HasKey(p => p.Id);
            builder.Entity<UserAchievements>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<UserAchievements>().Property(p => p.UserId).IsRequired();
            builder.Entity<UserAchievements>().Property(p => p.AchievementId).IsRequired();
            builder.Entity<UserAchievements>()
                .HasOne(p => p.User)
                .WithMany(p => p.UserAchievements)
                .HasForeignKey(p => p.UserId);
            builder.Entity<UserAchievements>()
                .HasOne(p => p.Achievement)
                .WithMany(p => p.UserAchievements)
                .HasForeignKey(p => p.AchievementId);

            builder.Entity<UserAchievements>().HasData
             (
                 new UserAchievements { Id = 1, UserId = 1, AchievementId = 1},
                 new UserAchievements { Id = 2, UserId = 2, AchievementId = 2},
                 new UserAchievements { Id = 2, UserId = 2, AchievementId = 3 }
             );

            //Tabla Wallet

            builder.Entity<Wallet>().ToTable("wallets");
            builder.Entity<Wallet>().HasKey(p => p.Id);
            builder.Entity<Wallet>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Wallet>().Property(p => p.Points).IsRequired();
            builder.Entity<Wallet>()
                .HasOne(p => p.User)
                .WithOne(p => p.Wallet)
                .HasForeignKey<User>(p => p.WalletId);

            builder.Entity<Wallet>().HasData
            (
                new Wallet { Id = 1, Points = 530 },
                new Wallet { Id = 2, Points = 1000 }
            );
        }
    }
    
}
