using FlightList.Domain;
using Microsoft.EntityFrameworkCore;

namespace FlightList.Persistence;

public static class DbContextDataInit
{
    public static ModelBuilder SeedData(this ModelBuilder modelBuilder)
    {
        List<Coordinates> coordinates = new()
        {
            new Coordinates { Latitude = 33.3675, Longitude = -7.589972 , Id ="5e6c365b-79d7-4324-a614-2cd3b97bb7fd"  },
            new Coordinates { Latitude = 31.6069, Longitude = -8.0363 , Id = "6b20a79e-5092-41b7-b107-9abf8df9bf9f" },
            new Coordinates { Latitude = 30.3250, Longitude = -9.4131 , Id ="f1db0bb6-7991-43b6-bec7-2d597a3214bc" },
            new Coordinates { Latitude = 33.9273, Longitude = -4.9786 , Id = "59ee9bf9-83dc-49ef-9251-d31aea754a87" },
            new Coordinates { Latitude = 34.0514, Longitude = -6.7518 , Id = "9aa05341-bbd9-4514-b0a9-4c77b9048352"},
            new Coordinates { Latitude = 35.7269, Longitude = -5.9197 , Id ="958e968e-c391-4b8a-abf2-f15bcb32dcef"},
            new Coordinates { Latitude = 40.7269, Longitude = -6.9197 , Id ="20a6097c-d79a-40ad-b018-58b0951e7dd0"},
            new Coordinates { Latitude = 99.7269, Longitude = -99.9197 , Id ="85ab417f-3ccd-499b-9341-0957f907a017"},

        };

        List<Airport> airports = new()
        {
            new Airport
            {
                Id = "cdacc6b2-2b7d-43b6-a93d-1d2ed6530ca9",
                Name = "Aéroport Mohammed V de Casablanca",
                Code = "CMN",
                CoordinatesId = coordinates.ElementAt(0).Id,
            },
            new Airport
            {
                Id ="ec604f42-8e8f-43a6-be23-f6cb91c15090",
                Name = "Aéroport Marrakech-Ménara",
                Code = "RAK",
                CoordinatesId = coordinates.ElementAt(1).Id,

            },
            new Airport
            {
                Id ="7b0be66b-b6db-425e-9bee-96c5b7126301",
                Name = "Aéroport Agadir-Al Massira",
                Code = "AGA",
                              CoordinatesId = coordinates.ElementAt(2).Id,

            },
            new Airport
            {
                Id ="a2703280-4fd4-4edc-81dc-b5f8801e833f",
                Name = "Aéroport Fès-Saïss",
                Code = "FEZ",
                CoordinatesId = coordinates.ElementAt(3).Id,

            },
            new Airport
            {
                Id = "5c531852-3334-425b-96c7-b35404a95895",
                Name = "Aéroport Rabat-Salé",
                Code = "RBA",
                CoordinatesId = coordinates.ElementAt(4).Id,

            },
            new Airport
            {
                Id = "7822d982-25ff-423b-8418-41cd6da170fe",
                Name = "Aéroport Tangier Ibn Battuta",
                Code = "TNG",
                CoordinatesId = coordinates.ElementAt(5).Id,

            }
        };

        modelBuilder.Entity<Coordinates>().HasData(coordinates);
        modelBuilder.Entity<Airport>().HasData(airports);
        return modelBuilder;
    }
}
