using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class FilterByIngredient
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/filter.php?i=chicken_breast";

        // Send GET request
        var response = await client.GetAsync(url);

        // Assert status code is 200 OK
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new Exception($"Expected 200 OK but got {response.StatusCode}");
        }

        // Read response body
        string body = await response.Content.ReadAsStringAsync();

        // Parse JSON
        using JsonDocument document = JsonDocument.Parse(body);

        JsonElement root = document.RootElement;

        // Check meals array exists and has at least 1 item
        if (!root.TryGetProperty("meals", out JsonElement meals) ||
            meals.ValueKind == JsonValueKind.Null ||
            meals.GetArrayLength() < 1)
        {
            throw new Exception("No meals found with ingredient chicken_breast.");
        }

        Console.WriteLine("Filter By Ingredient test passed!");
        Console.WriteLine($"Found {meals.GetArrayLength()} meal(s).");
    }
}