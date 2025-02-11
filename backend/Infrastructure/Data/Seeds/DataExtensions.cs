using Microsoft.EntityFrameworkCore;
using Backend.Domain.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System;
using System.Runtime.CompilerServices;
using Backend.Application.DTOs;
using AutoMapper;

namespace Backend.Infrastructure.Data.Seeds
{
    public static class DataExtensions
    {
        public static IApplicationBuilder SeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

            if (context.Museums.Any() && context.Cities.Any() && context.Countries.Any())
            {
                return app;
            }

            var museumsDto = LoadFromJson<List<MuseumDto>>("museums-old.json");
            var museums = mapper.Map<List<Museum>>(museumsDto);

            var countryDtos = LoadFromJson<List<CountryDto>>("countries.json");
            var countries = mapper.Map<List<Country>>(countryDtos);

            context.Countries.AddRange(countries);
            //context.SaveChanges();

            var museumSchedules = LoadFromJson<List<MuseumScheduleDto>>("museumSchedule.json");

            //context.Museums.AddRange(museums);
            //context.SaveChanges();

            var features = new List<MuseumFeature>
            {
                new() { FeatureType = "Art" },
                new() { FeatureType = "History" },
                new() { FeatureType = "Science & Technology" },
                new() { FeatureType = "Natural History" },
                new() { FeatureType = "Culture & Ethnograhy" },
                new() { FeatureType = "Other ( ex. Fashion, Cinema, Music, Sport, Perfume )" }
            };

            context.MuseumFeatures.AddRange(features);
            //context.SaveChanges();

            AddMuseumFeatureOptions(context);

            AddMuseumFeatureAssociations(context);

            return app;
        }

        private static void AddMuseumFeatureOptions(AppDbContext context)
        {

            var artOptions = new List<MuseumFeatureOption>
            {
                new() { MuseumFeatureOptionId = 1, MuseumFeatureId = 1, OptionName = "Classical ( Renessaince, Baroque, Neoclassical, Romanticism )" },
                new() { MuseumFeatureOptionId = 2, MuseumFeatureId = 1, OptionName = "Impressionism ( Monet, Renoir, Degas )" },
                new() { MuseumFeatureOptionId = 3, MuseumFeatureId = 1, OptionName = "Modern ( Post-Impressionism, Surrealism, Cubism )" },
                new() { MuseumFeatureOptionId = 4, MuseumFeatureId = 1, OptionName = "Contemporary ( Minimalism, Abstract Expressionism )" },
                new() { MuseumFeatureOptionId = 5, MuseumFeatureId = 1, OptionName = "Photography" },
            };

            var historyOptions = new List<MuseumFeatureOption>
            {
                new() { MuseumFeatureOptionId = 6, MuseumFeatureId = 2, OptionName = "Ancient ( Egypt, Greece, Rome, Asia )" },
                new() { MuseumFeatureOptionId = 7, MuseumFeatureId = 2, OptionName = "Medieval" },
                new() { MuseumFeatureOptionId = 8, MuseumFeatureId = 2, OptionName = "Modern ( World Wars, 20th Century )" },
                new() { MuseumFeatureOptionId = 9, MuseumFeatureId = 2, OptionName = "French ( Royal France, Revolution, Napoleonic )" },
            };

            var scienceOptions = new List<MuseumFeatureOption>
            {
                new() { MuseumFeatureOptionId = 10, MuseumFeatureId = 3, OptionName = "Space & Astronomy" },
                new() { MuseumFeatureOptionId = 11, MuseumFeatureId = 3, OptionName = "Physics & Engineering" },
                new() { MuseumFeatureOptionId = 12, MuseumFeatureId = 3, OptionName = "Biology & Medicine" },
                new() { MuseumFeatureOptionId = 13, MuseumFeatureId = 3, OptionName = "Chemistry" },
                new() { MuseumFeatureOptionId = 14, MuseumFeatureId = 3, OptionName = "Geology" },
            };

            var naturalHistoryOptions = new List<MuseumFeatureOption>
            {
                new() { MuseumFeatureOptionId = 15, MuseumFeatureId = 4, OptionName = "Dinosaurs & Prehistoric Life" },
                new() { MuseumFeatureOptionId = 16, MuseumFeatureId = 4, OptionName = "Human Evolution" },
                new() { MuseumFeatureOptionId = 17, MuseumFeatureId = 4, OptionName = "Marine Life & Oceanography" },
                new() { MuseumFeatureOptionId = 18, MuseumFeatureId = 4, OptionName = "Botany & Plant Life" },
                new() { MuseumFeatureOptionId = 19, MuseumFeatureId = 4, OptionName = "Geology & Mineralogy" },
                new() { MuseumFeatureOptionId = 20, MuseumFeatureId = 4, OptionName = "Wildlife & Zoology" },
            };

            var cultureOptions = new List<MuseumFeatureOption>
            {
                new() { MuseumFeatureOptionId = 21, MuseumFeatureId = 5, OptionName = "Ancient Civilizations" },
                new() { MuseumFeatureOptionId = 22, MuseumFeatureId = 5, OptionName = "World Religions & Beliefs" },
                new() { MuseumFeatureOptionId = 23, MuseumFeatureId = 5, OptionName = "Indigineous Cultures" },
                new() { MuseumFeatureOptionId = 24, MuseumFeatureId = 5, OptionName = "Cultural Arfifacts & Traditions" },
            };

            context.MuseumFeatureOptions.AddRange(artOptions.Concat(historyOptions).Concat(scienceOptions).Concat(naturalHistoryOptions).Concat(cultureOptions));
            //context.SaveChanges();
        }

        private static void AddMuseumFeatureAssociations(AppDbContext context)
        {
            if (context.MuseumFeatureAssociations.Any()) return;

            var museumFeatureAssociations = LoadFromJson<List<MuseumFeatureAssociation>>("museum_feature_associations.json");

            context.MuseumFeatureAssociations.AddRange(museumFeatureAssociations);
            //context.SaveChanges();
        }

        private static T LoadFromJson<T>(string jsonPath) where T : class
        {
            string jsonContent = File.ReadAllText(jsonPath);
            return JsonConvert.DeserializeObject<T>(jsonContent)!;
        }
    }
}
