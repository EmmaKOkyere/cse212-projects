using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// Find symmetric pairs of two-character words in O(n) time.
    /// </summary>
 public static string[] FindPairs(string[] words)
{
    var seen = new HashSet<string>();
    var pairs = new List<string>();

    foreach (var word in words)
    {
        var reversed = $"{word[1]}{word[0]}";

        if (word != reversed && seen.Contains(reversed))
        {
            pairs.Add($"{word} & {reversed}");
        }

        seen.Add(word);
    }

    return pairs.ToArray();
}
    /// <summary>
    /// Read census data and count each education degree.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(',');

            // Education is the 4th column, which is index 3.
            var degree = fields[3];

            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine whether two strings are anagrams.
    /// Ignore spaces and letter case.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        var letters = new Dictionary<char, int>();

        foreach (var character in word1)
        {
            if (character == ' ')
            {
                continue;
            }

            var letter = char.ToLowerInvariant(character);

            if (letters.ContainsKey(letter))
            {
                letters[letter]++;
            }
            else
            {
                letters[letter] = 1;
            }
        }

        foreach (var character in word2)
        {
            if (character == ' ')
            {
                continue;
            }

            var letter = char.ToLowerInvariant(character);

            if (!letters.ContainsKey(letter))
            {
                return false;
            }

            letters[letter]--;

            if (letters[letter] < 0)
            {
                return false;
            }
        }

        foreach (var count in letters.Values)
        {
            if (count != 0)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Read today's earthquake data from USGS and return
    /// formatted location/magnitude descriptions.
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri =
            "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        using var request = new HttpRequestMessage(HttpMethod.Get, uri);
        using var response = client.Send(request);

        response.EnsureSuccessStatusCode();

        using var jsonStream = response.Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);

        var json = reader.ReadToEnd();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var featureCollection =
            JsonSerializer.Deserialize<FeatureCollection>(json, options);

        if (featureCollection == null)
        {
            return Array.Empty<string>();
        }

        var summaries = new List<string>();

        foreach (var feature in featureCollection.Features)
        {
            summaries.Add(
                $"{feature.Properties.Place} - Mag {feature.Properties.Mag}"
            );
        }

        return summaries.ToArray();
    }
}