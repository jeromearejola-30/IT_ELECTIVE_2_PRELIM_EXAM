using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class SearchMealByName
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/search.php?s=Arrabiata";

        // Send GET request
        var response = await client.GetAsync(url);

        // Assert status code is 200 OK
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new Exception($"Expected 200 OK but got {response.StatusCode}");
        }

        // Read response content
        string body = await response.Content.ReadAsStringAsync();

        // Parse JSON response
        using JsonDocument document = JsonDocument.Parse(body);

        JsonElement root = document.RootElement;

        // Check if "meals" exists and has at least one item
        if (!root.TryGetProperty("meals", out JsonElement meals) ||
            meals.ValueKind == JsonValueKind.Null ||
            meals.GetArrayLength() < 1)
        {
            throw new Exception("No meals found for Arrabiata.");
        }

        Console.WriteLine("Search Meal By Name test passed!");
        Console.WriteLine($"Found {meals.GetArrayLength()} meal(s).");
    }
}