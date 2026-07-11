using System.Text;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class UpdateReview
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        string url = "https://jsonplaceholder.typicode.com/posts/1";

        // Create JSON body
        string json = """
        {
            "id": 1,
            "title": "Updated Review",
            "body": "Even better than before!",
            "userId": 1
        }
        """;

        // Create StringContent with JSON
        using StringContent content = new StringContent(
            json,
            Encoding.UTF8,
            "application/json"
        );

        // Send PUT request
        var response = await client.PutAsync(url, content);

        // Assert status code is 200 OK
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new Exception($"Expected 200 OK but got {response.StatusCode}");
        }

        // Read response body
        string body = await response.Content.ReadAsStringAsync();

        // Parse JSON response
        using JsonDocument document = JsonDocument.Parse(body);

        JsonElement root = document.RootElement;

        // Assert title is "Updated Review"
        if (!root.TryGetProperty("title", out JsonElement title) ||
            title.GetString() != "Updated Review")
        {
            throw new Exception(
                $"Expected title 'Updated Review' but got '{title.GetString()}'"
            );
        }

        Console.WriteLine("Update Review test passed!");
        Console.WriteLine($"Updated title: {title.GetString()}");
    }
}