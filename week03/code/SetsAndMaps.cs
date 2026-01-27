using System.Text.Json;

public static class SetsAndMaps
{
    // =========================
    // Problem 1 – Finding Pairs
    // =========================
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var results = new List<string>();

        foreach (var word in words)
        {
            // Ignore same-letter words like "aa"
            if (word[0] == word[1])
                continue;

            var reversed = $"{word[1]}{word[0]}";

            if (seen.Contains(reversed))
            {
                results.Add($"{reversed} & {word}");
            }
            else
            {
                seen.Add(word);
            }
        }

        return results.ToArray();
    }

    // =========================
    // Problem 2 – Degree Summary
    // =========================
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");

            // Degree is column 4 (index 3)
            var degree = fields[3].Trim();

            if (!degrees.ContainsKey(degree))
            {
                degrees[degree] = 0;
            }

            degrees[degree]++;
        }

        return degrees;
    }

    // =========================
    // Problem 3 – Anagrams
    // =========================
    public static bool IsAnagram(string word1, string word2)
    {
        // Normalize input
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length)
            return false;

        var counts = new Dictionary<char, int>();

        foreach (char c in word1)
        {
            if (!counts.ContainsKey(c))
                counts[c] = 0;

            counts[c]++;
        }

        foreach (char c in word2)
        {
            if (!counts.ContainsKey(c))
                return false;

            counts[c]--;

            if (counts[c] < 0)
                return false;
        }

        return true;
    }

    // =========================
    // Problem 5 – Earthquakes
    // =========================
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var results = new List<string>();

        foreach (var feature in featureCollection.features)
        {
            if (feature.properties.place != null && feature.properties.mag != null)
            {
                results.Add($"{feature.properties.place} - Mag {feature.properties.mag}");
            }
        }

        return results.ToArray();
    }
}
