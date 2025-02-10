using Microsoft.EntityFrameworkCore;
using Backend.Domain.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System;
using System.Runtime.CompilerServices;

namespace Backend.Infrastructure.Data.Seeds
{
    public static class DataExtensions
    {
        public static IApplicationBuilder SeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            if (context.Museums.Any() && context.Cities.Any() && context.Countries.Any())
            {
                return app;
            }

            var countries = LoadFromJson<List<Country>>("countries.json");
            var cities = LoadFromJson<List<City>>("cities.json");

            context.Countries.AddRange(countries);
            context.SaveChanges();

            foreach (var city in cities)
            {
                var country = context.Countries.FirstOrDefault(c => c.CountryId == city.CountryId);
                if (country != null)
                {
                    city.CountryId = country.CountryId;
                    context.Cities.Add(city);
                }
            }
            context.SaveChanges();

            var museumSchedules = LoadFromJson<List<MuseumSchedule>>("museumSchedule.json");

            var museums = LoadFromJson<List<Museum>>("museums.json");

            context.Museums.AddRange(museums);
            context.SaveChanges();

            var features = new List<MuseumFeature>
            {
                new MuseumFeature { FeatureType = "Art" },
                new MuseumFeature { FeatureType = "History" },
                new MuseumFeature { FeatureType = "Science & Technology" },
                new MuseumFeature { FeatureType = "Natural History" },
                new MuseumFeature { FeatureType = "Culture & Ethnograhy" },
                new MuseumFeature { FeatureType = "Other ( ex. Fashion, Cinema, Music, Sport, Perfume )" }
            };

            context.MuseumFeatures.AddRange(features);
            context.SaveChanges();

            AddMuseumFeatureOptions(context);

            AddMuseumFeatureAssociations(context);

            return app;
        }

        private static void AddMuseumFeatureOptions(AppDbContext context)
        {

            var artOptions = new List<MuseumFeatureOption>
            {
                new MuseumFeatureOption { MuseumFeatureOptionId = 1, MuseumFeatureId = 1, OptionName = "Classical ( Renessaince, Baroque, Neoclassical, Romanticism )" },
                new MuseumFeatureOption { MuseumFeatureOptionId = 2, MuseumFeatureId = 1, OptionName = "Impressionism ( Monet, Renoir, Degas )" },
                new MuseumFeatureOption { MuseumFeatureOptionId = 3, MuseumFeatureId = 1, OptionName = "Modern ( Post-Impressionism, Surrealism, Cubism )" },
                new MuseumFeatureOption { MuseumFeatureOptionId = 4, MuseumFeatureId = 1, OptionName = "Contemporary ( Minimalism, Abstract Expressionism )" },
                new MuseumFeatureOption { MuseumFeatureOptionId = 5, MuseumFeatureId = 1, OptionName = "Photography" },
            };

            var historyOptions = new List<MuseumFeatureOption>
            {
                new MuseumFeatureOption { MuseumFeatureOptionId = 6, MuseumFeatureId = 2, OptionName = "Ancient ( Egypt, Greece, Rome, Asia )" },
                new MuseumFeatureOption { MuseumFeatureOptionId = 7, MuseumFeatureId = 2, OptionName = "Medieval" },
                new MuseumFeatureOption { MuseumFeatureOptionId = 8, MuseumFeatureId = 2, OptionName = "Modern ( World Wars, 20th Century )" },
                new MuseumFeatureOption { MuseumFeatureOptionId = 9, MuseumFeatureId = 2, OptionName = "French ( Royal France, Revolution, Napoleonic )" },
            };

            var scienceOptions = new List<MuseumFeatureOption>
            {
                new MuseumFeatureOption { MuseumFeatureOptionId = 10, MuseumFeatureId = 3, OptionName = "Space & Astronomy" },
                new MuseumFeatureOption { MuseumFeatureOptionId = 11, MuseumFeatureId = 3, OptionName = "Physics & Engineering" },
                new MuseumFeatureOption { MuseumFeatureOptionId = 12, MuseumFeatureId = 3, OptionName = "Biology & Medicine" },
                new MuseumFeatureOption { MuseumFeatureOptionId = 13, MuseumFeatureId = 3, OptionName = "Chemistry" },
                new MuseumFeatureOption { MuseumFeatureOptionId = 14, MuseumFeatureId = 3, OptionName = "Geology" },
            };

            var naturalHistoryOptions = new List<MuseumFeatureOption>
            {
                new MuseumFeatureOption { MuseumFeatureOptionId = 15, MuseumFeatureId = 4, OptionName = "Dinosaurs & Prehistoric Life" },
                new MuseumFeatureOption { MuseumFeatureOptionId = 16, MuseumFeatureId = 4, OptionName = "Human Evolution" },
                new MuseumFeatureOption { MuseumFeatureOptionId = 17, MuseumFeatureId = 4, OptionName = "Marine Life & Oceanography" },
                new MuseumFeatureOption { MuseumFeatureOptionId = 18, MuseumFeatureId = 4, OptionName = "Botany & Plant Life" },
                new MuseumFeatureOption { MuseumFeatureOptionId = 19, MuseumFeatureId = 4, OptionName = "Geology & Mineralogy" },
                new MuseumFeatureOption { MuseumFeatureOptionId = 20, MuseumFeatureId = 4, OptionName = "Wildlife & Zoology" },
            };

            var cultureOptions = new List<MuseumFeatureOption>
            {
                new MuseumFeatureOption { MuseumFeatureOptionId = 21, MuseumFeatureId = 5, OptionName = "Ancient Civilizations" },
                new MuseumFeatureOption { MuseumFeatureOptionId = 22, MuseumFeatureId = 5, OptionName = "World Religions & Beliefs" },
                new MuseumFeatureOption { MuseumFeatureOptionId = 23, MuseumFeatureId = 5, OptionName = "Indigineous Cultures" },
                new MuseumFeatureOption { MuseumFeatureOptionId = 24, MuseumFeatureId = 5, OptionName = "Cultural Arfifacts & Traditions" },
            };

            context.MuseumFeatureOptions.AddRange(artOptions.Concat(historyOptions).Concat(scienceOptions).Concat(naturalHistoryOptions).Concat(cultureOptions));
            context.SaveChanges();
        }

        private static void AddMuseumFeatureAssociations(AppDbContext context)
        {
            if (context.MuseumFeatureAssociations.Any()) return;

            var museumFeatureAssociations = LoadFromJson<List<MuseumFeatureAssociation>>("museum_feature_associations.json");

            context.MuseumFeatureAssociations.AddRange(museumFeatureAssociations);
            context.SaveChanges();
        }

        private static T LoadFromJson<T>(string jsonPath) where T : class
        {
            string jsonContent = File.ReadAllText(jsonPath);
            return JsonConvert.DeserializeObject<T>(jsonContent)!;
        }
    }
}
