using Microsoft.EntityFrameworkCore;
using Backend.Domain.Entities;
using Newtonsoft.Json;
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

            if (!context.Countries.Any())
            {
                AddCountries(context, mapper);
            }

            if (!context.Museums.Any())
            {
                AddMuseums(context, mapper);
            }

            if (!context.MuseumSchedules.Any())
            {
                AddMuseumSchedules(context, mapper);
            }

            if (!context.Shops.Any())
            {
                AddShops(context, mapper);
            }
            
            if (!context.MuseumFeatures.Any())
            {
                AddMuseumFeatures(context);
                AddMuseumFeatureOptions(context);
                AddMuseumFeatureAssociations(mapper, context);
            }
            
            return app;
        }

        private static void AddCountries(AppDbContext context, IMapper mapper)
        {
            if (context.Countries.Any()) return;

            var countryDtos = LoadFromJson<List<CountryDto>>("countries.json");
            var countries = mapper.Map<List<Country>>(countryDtos);

            context.Countries.AddRange(countries);
            context.SaveChanges();
        }

        private static void AddMuseums(AppDbContext context, IMapper mapper)
        {
            if (context.Museums.Any()) return;

            var museumDtos = LoadFromJson<List<MuseumDto>>("museums-old.json");
            var museums = mapper.Map<List<Museum>>(museumDtos);

            context.Museums.AddRange(museums);
            context.SaveChanges();
        }

        private static void AddMuseumSchedules(AppDbContext context, IMapper mapper)
        {
            if (context.MuseumSchedules.Any()) return;

            var museumScheduleDtos = LoadFromJson<List<MuseumScheduleDto>>("museumSchedule.json");
            var museumSchedules = mapper.Map<List<MuseumSchedule>>(museumScheduleDtos);

            context.MuseumSchedules.AddRange(museumSchedules);
            context.SaveChanges();
        }

        private static void AddShops(AppDbContext context, IMapper mapper)
        {
            if (context.Shops.Any()) return;

            var museumScheduleDtos = LoadFromJson<List<MuseumScheduleDto>>("museumSchedule.json");
            var shops = new List<Shop>();

            foreach (var dto in museumScheduleDtos)
            {
                if (dto == null || dto.Shop == null)
                {
                    continue;
                }

                var res = mapper.Map<List<Shop>>(dto);
                shops.AddRange(res);
            }

            context.Shops.AddRange(shops);
            context.SaveChanges();
        }

        private static void AddMuseumFeatures(AppDbContext context)
        {
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
            context.SaveChanges();
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
            context.SaveChanges();
        }

        private static void AddMuseumFeatureAssociations(IMapper mapper, AppDbContext context)
        {
            if (context.MuseumFeatureAssociations.Any()) return;

            var museumFeatureAssociationDtos = LoadFromJson<List<MuseumFeatureAssociationDto>>("museum_feature_associations.json");
            var museumFeatureAssociations = new List<MuseumFeatureAssociation>();
            
            foreach (var dto in museumFeatureAssociationDtos)
            {
                var res = mapper.Map<List<MuseumFeatureAssociation>>(dto);
                museumFeatureAssociations.AddRange(res);
            }

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
