using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class GetMealById
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/lookup.php?i=52771";

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

        // Get meals array
        if (!root.TryGetProperty("meals", out JsonElement meals) ||
            meals.ValueKind == JsonValueKind.Null ||
            meals.GetArrayLength() == 0)
        {
            throw new Exception("No meal found.");
        }

        // Get first meal's name
        JsonElement meal = meals[0];

        string mealName = meal.GetProperty("strMeal").GetString() ?? "";

        // Assert meal name is Arrabiata
        if (mealName != "Spicy Arrabiata Penne")
        {
            throw new Exception($"Expected meal name 'Arrabiata' but got '{mealName}'.");
        }

        Console.WriteLine("Get Meal By ID test passed!");
        Console.WriteLine($"Meal found: {mealName}");
    }
}