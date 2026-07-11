using System.Text;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class CreateReview
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://jsonplaceholder.typicode.com/posts";

        // Create JSON body
        string json = """
        {
            "title": "Great Pasta!",
            "body": "Loved this recipe",
            "userId": 1
        }
        """;

        // Create StringContent with JSON and application/json header
        using StringContent content = new StringContent(
            json,
            Encoding.UTF8,
            "application/json"
        );

        // Send POST request
        var response = await client.PostAsync(url, content);

        // Assert status code is 201 Created
        if (response.StatusCode != System.Net.HttpStatusCode.Created)
        {
            throw new Exception($"Expected 201 Created but got {response.StatusCode}");
        }

        // Read response body
        string body = await response.Content.ReadAsStringAsync();

        // Parse JSON response
        using JsonDocument document = JsonDocument.Parse(body);

        JsonElement root = document.RootElement;

        // Assert response contains id field with value
        if (!root.TryGetProperty("id", out JsonElement id) ||
            id.GetInt32() <= 0)
        {
            throw new Exception("Response does not contain a valid id.");
        }

        Console.WriteLine("Create Review test passed!");
        Console.WriteLine($"Created review ID: {id.GetInt32()}");
    }
}