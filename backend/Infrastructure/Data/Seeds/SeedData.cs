using Microsoft.EntityFrameworkCore;
using Backend.Domain.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System;

namespace Backend.Infrastructure.Data.Seeds
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider, bool isDevelopment)
        {
            using var context = new MuseumContext(
                serviceProvider.GetRequiredService<DbContextOptions<MuseumContext>>());

            if (context.Museums.Any() && context.Cities.Any() && context.Countries.Any())
            {
                return;
            }

            var countries = LoadCountriesFromJson("countries.json");
            var cities = LoadCitiesFromJson("cities.json");

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

            var museumSchedules = LoadOpeningHoursFromJson("museumSchedule.json");

            var museums = new List<Museum>();
            for (int i = 0; i < 150; i++)
            {
                var museum = new Museum
                {
                    Name = $"Museum {i + 1}",
                    Location = $"Location {i + 1}",
                    Description = $"Description for Museum {i + 1}",
                    Palace = i % 2 == 0,
                    IndoorOrOutdoor = i % 2 == 0 ? "Indoor" : "Outdoor",
                    Accessibility = "Wheelchair accessible",
                    GuidedTours = i % 2 == 0,
                    Languages = new List<string> { "English, French, Spanish" },
                    CityId = 1,
                };
                var openingHoursForMuseum = museumSchedules.FirstOrDefault(o => o.MuseumId == i + 1);
                

                museums.Add(museum);
            }

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

            AddMuseumFeatureOptions(contex);
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

        private static List<Country> LoadCountriesFromJson(string filePath)
        {
            string jsonContent = File.ReadAllText(filePath);

            List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(jsonContent);

            return countries;
        }

        private static List<City> LoadCitiesFromJson(string filePath)
        {
            string jsonContent = File.ReadAllText(filePath);

            List<City> cities = JsonConvert.DeserializeObject<List<City>>(jsonContent);

            return cities;
        }

        private static List<MuseumSchedule> LoadOpeningHoursFromJson(string filePath)
        {
            string jsonContent = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<MuseumSchedule>>(jsonContent);
        }
    }
}
