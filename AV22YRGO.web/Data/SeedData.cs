using System.Text.Json;
using AV22YRGO.web.Data;
using AV22YRGO.web.Models;

namespace WestCoastEdu.web.Data;

public static class SeedData
{
    public static async Task LoadCourseData(AvYrgoContext context)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        // Vill endast ladda data om databasens tabell är tom...
        if (context.Profiles.Any()) return;

        // Läsa in json datat...
        var json = System.IO.File.ReadAllText("Data/json/profiles.json");
        // Konvertera json objekten till en lista av Course objekt...
        var profiles = JsonSerializer.Deserialize<List<Profile>>(json, options);

        if (profiles is not null && profiles.Count > 0)
        {
            await context.Profiles.AddRangeAsync(profiles);
            await context.SaveChangesAsync();
        }
    }
    public static async Task LoadAccountData(AvYrgoContext context)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        // Vill endast ladda data om databasens tabell är tom...
        if (context.Events.Any()) return;

        // Läsa in json datat...
        var json = System.IO.File.ReadAllText("Data/json/events.json");
        // Konvertera json objekten till en lista av Course objekt...
        var events = JsonSerializer.Deserialize<List<Event>>(json, options);

        if (events is not null && events.Count > 0)
        {
            await context.Events.AddRangeAsync(events);
            await context.SaveChangesAsync();
        }
    }
}
