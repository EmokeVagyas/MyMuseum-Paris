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
            using var context = new MuseumContext(
                app.ApplicationServices.GetRequiredService<DbContextOptions<MuseumContext>>());

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

            return app;
        }

        private static void AddMuseumFeatureOptions(MuseumContext context)
        {

            var artOptions = new List<MuseumFeatureOption>
            {
                new MuseumFeatureOption { MuseumFeatureID = 1, OptionName= "Classical ( Renessaince, Baroque, Neoclassical, Romanticism )" },
                new MuseumFeatureOption { MuseumFeatureID = 1, OptionName = "Impressionism ( Monet, Renoir, Degas )" },
                new MuseumFeatureOption { MuseumFeatureID = 1, OptionName = "Modern ( Post-Impressionism, Surrealism, Cubism )" },
                new MuseumFeatureOption { MuseumFeatureID = 1, OptionName = "Contemporary ( Minimalism, Abstract Expressionism )" },
                new MuseumFeatureOption { MuseumFeatureID = 1, OptionName = "Photography" },
            };

            var historyOptions = new List<MuseumFeatureOption>
            {
                new MuseumFeatureOption { MuseumFeatureID = 2, OptionName = "Ancient ( Egypt, Greece, Rome, Asia )" },
                new MuseumFeatureOption { MuseumFeatureID = 2, OptionName = "Medieval" },
                new MuseumFeatureOption { MuseumFeatureID = 2, OptionName = "Modern ( World Wars, 20th Century )" },
                new MuseumFeatureOption { MuseumFeatureID = 2, OptionName = "French ( Royal France, Revolution, Napoleonic )" },
            };

            var scienceOptions = new List<MuseumFeatureOption>
            {
                new MuseumFeatureOption { MuseumFeatureID = 3, OptionName = "Space & Astronomy" },
                new MuseumFeatureOption { MuseumFeatureID = 3, OptionName = "Physics & Engineering" },
                new MuseumFeatureOption { MuseumFeatureID = 3, OptionName = "Biology & Medicine" },
                new MuseumFeatureOption { MuseumFeatureID = 3, OptionName = "Chemistry" },
                new MuseumFeatureOption { MuseumFeatureID = 3, OptionName = "Geology" },
            };

            var naturalHistoryOptions = new List<MuseumFeatureOption>
            {
                new MuseumFeatureOption { MuseumFeatureID = 4, OptionName = "Dinosaurs & Prehistoric Life" },
                new MuseumFeatureOption { MuseumFeatureID = 4, OptionName = "Human Evolution" },
                new MuseumFeatureOption { MuseumFeatureID = 4, OptionName = "Marine Life & Oceanography" },
                new MuseumFeatureOption { MuseumFeatureID = 4, OptionName = "Botany & Plant Life" },
                new MuseumFeatureOption { MuseumFeatureID = 4, OptionName = "Geology & Mineralogy" },
                new MuseumFeatureOption { MuseumFeatureID = 4, OptionName = "Wildlife & Zoology" },
            };

            var cultureOptions = new List<MuseumFeatureOption>
            {
                new MuseumFeatureOption {MuseumFeatureID = 5, OptionName = "Ancient Civilizations" },
                new MuseumFeatureOption {MuseumFeatureID = 5, OptionName = "World Religions & Beliefs" },
                new MuseumFeatureOption {MuseumFeatureID = 5, OptionName = "Indigineous Cultures" },
                new MuseumFeatureOption {MuseumFeatureID = 5, OptionName = "Cultural Arfifacts & Traditions" },
            };

            context.MuseumFeatureOptions.AddRange(artOptions.Concat(historyOptions).Concat(scienceOptions).Concat(naturalHistoryOptions).Concat(cultureOptions));
            context.SaveChanges();
        }

        private static T LoadFromJson<T>(string jsonPath) where T : class
        {
            string jsonContent = File.ReadAllText(jsonPath);
            return JsonConvert.DeserializeObject<T>(jsonContent)!;
        }
    }
}
