namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

using System.Text.Json;
using System.Text.Json.Serialization;

// EXERCISE 10: GET Deserialize Multiple Meals
// TheMealDB API: https://themealdb.com/api/json/v1/1/search.php?f=a
//
// This endpoint returns ALL meals starting with the letter "a".

public static class DeserializeMeals
{
    // C# classes designed to match the JSON structure for safe deserialization
    public class MealResponse
    {
        [JsonPropertyName("meals")]
        public List<Meal> Meals { get; set; }
    }

    public class Meal
    {
        [JsonPropertyName("strMeal")]
        public string StrMeal { get; set; }
    }

    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/search.php?f=a";

        // 1. Use the HttpClient to fetch meals starting with letter "a"
        HttpResponseMessage response = await client.GetAsync(url);

        // 2. Assert status code is 200 OK
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new Exception($"Expected status code 200 OK, but got {response.StatusCode}");
        }

        // 3. Parse the JSON and get the "meals" array
        string jsonString = await response.Content.ReadAsStringAsync();

        // Configured to be case-insensitive just in case, though JsonPropertyName handles it
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        MealResponse mealResponse = JsonSerializer.Deserialize<MealResponse>(jsonString, options);

        // 4. Assert the array has more than 0 items
        if (mealResponse?.Meals == null || mealResponse.Meals.Count == 0)
        {
            throw new Exception("Assertion failed: The meals array is null or empty.");
        }

        // 5. Loop through each meal and print its name (strMeal)
        Console.WriteLine($"Found {mealResponse.Meals.Count} meals starting with 'a':");
        foreach (var meal in mealResponse.Meals)
        {
            Console.WriteLine($"- {meal.StrMeal}");
        }
    }
}