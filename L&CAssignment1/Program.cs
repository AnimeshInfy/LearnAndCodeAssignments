using System;
using System.Collections.Generic;

class Location
{
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

class Program
{
    static void Main()
    {
        List<Location> locations = GenerateRandomLocations(100);
        MakeClusters(locations);
    }

    static List<Location> GenerateRandomLocations(int count)
    {
        List<Location> locations = new List<Location>();
        Random random = new Random();

        for (int i = 1; i <= count; i++)
        {
            double latitude = random.NextDouble() * 180 - 90; 
            double longitude = 60;

            locations.Add(new Location { Name = $"Location {i}", Latitude = latitude, Longitude = longitude });

        }

        locations.Add(new Location { Name = $"Location No 101 TEST", Latitude = 9.87, Longitude = 60.0 });
        locations.Add(new Location { Name = $"Location No 102 TEST", Latitude = -9.17, Longitude = 60.0 });

        return locations;
    }

    static void MakeClusters(List<Location> locations)
    {
        Dictionary<int, List<Location>> clusters = new Dictionary<int, List<Location>>();

        foreach (var location in locations)
        {
            int key = (int)(location.Latitude / 10.0);

            //To Handle a corner case with current logic that when latitude is between -10 to 10
            // then key will be 0 only according to my logic, so there will be a cluster of 20 degree
            // Latitude difference.

            if (key == 0)
            {
                if (location.Latitude > -10 && location.Latitude < 0)
                {
                    key = -9;
                }
                if (location.Latitude < 10 && location.Latitude > 0)
                {
                    key = 9;
                }
            }

            key = key + 9;

            if (clusters.ContainsKey(key))
            {
                clusters[key].Add(location); 
            }
            else
            {
                clusters.Add(key, new List<Location> {location});
            }
        }

        foreach (var cluster in clusters)
        {
            Console.WriteLine($"Cluster {cluster.Key}:");
            Console.WriteLine("\n");

            foreach (var location in cluster.Value)
            {
                Console.WriteLine($"{location.Name} - Latitude: {location.Latitude} deg, Longitude: 60 deg E");
            }
            Console.WriteLine("\n");
        }
    }
}
