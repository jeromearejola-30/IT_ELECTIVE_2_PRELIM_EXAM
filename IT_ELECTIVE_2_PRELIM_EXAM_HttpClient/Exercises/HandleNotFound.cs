namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

using System.Text.Json;
using System.Text.Json.Serialization;

// EXERCISE 9: GET Handle 404 Not Found
// TheMealDB API: https://themealdb.com/api/json/v1/1/lookup.php?i={id}
//
// Your task:
// 1. Use the HttpClient to look up a meal with an ID that doesn't exist (ID 999999)
// 2. Assert the HTTP status code is 200 OK (TheMealDB always returns 200)
// 3. Parse the JSON and assert that the "meals" field is null
//    (meaning no meal was found for that ID)
//
// This teaches: APIs can return 200 OK but still indicate "not found"
// in the response body via null data.

public static class HandleNotFound
{
    // C# model mirroring the response structure where "meals" can be null
    public class LookupResponse
    {
        [JsonPropertyName("meals")]
        public List<object> Meals { get; set; }
    }

    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/lookup.php?i=999999";

        // 1. Use the HttpClient to look up a meal with an ID that doesn't exist (ID 999999)
        HttpResponseMessage response = await client.GetAsync(url);

        // 2. Assert the HTTP status code is 200 OK (TheMealDB always returns 200)
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new Exception($"Expected status code 200 OK, but got {response.StatusCode}");
        }

        // 3. Parse the JSON and assert that the "meals" field is null
        string jsonString = await response.Content.ReadAsStringAsync();

        LookupResponse lookupResult = JsonSerializer.Deserialize<LookupResponse>(jsonString);

        if (lookupResult == null || lookupResult.Meals != null)
        {
            throw new Exception("Assertion failed: Expected the 'meals' property to be null for an invalid ID.");
        }

        Console.WriteLine("Success: API returned 200 OK, and 'meals' payload was verified as null.");
    }
}